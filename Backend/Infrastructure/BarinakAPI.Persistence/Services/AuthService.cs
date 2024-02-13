using Azure.Core;
using BarinakAPI.Application.Abstractions.Services;
using BarinakAPI.Application.Abstractions.Token;
using BarinakAPI.Application.DTOs;
using BarinakAPI.Application.Exceptions;
using BarinakAPI.Application.Features.Commands.AppUser.LoginUser;
using BarinakAPI.Application.Helpers;
using BarinakAPI.Domain.Entities.Identity;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace BarinakAPI.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        readonly SignInManager<Domain.Entities.Identity.AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;
        readonly IConfiguration _configuration;
        readonly IUserService _userService;
        readonly IMailService _mailService;

        public AuthService(UserManager<AppUser> userManagar, ITokenHandler tokenHandler, IConfiguration configuration, SignInManager<AppUser> signInManager, IUserService userService, IMailService mailService)
        {
            _userManager = userManagar;
            _tokenHandler = tokenHandler;
            _configuration = configuration;
            _signInManager = signInManager;
            _userService = userService;
            _mailService = mailService;
        }
        async  Task<Token> CreateUserExternalAsync(AppUser user,string email,string name,UserLoginInfo info,int accessTokenLifeTime)
        {
            bool result = user != null;

            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    user = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = email,
                        UserName = email,
                        NameSurname = email,
                    };
                    var identityResult = await _userManager.CreateAsync(user);
                    result = identityResult.Succeeded;
                }
            }

            if (result)
            {
             await _userManager.AddLoginAsync(user, info);
            Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime);

            await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 5);

            return token;
            }

            throw new Exception("Invalid external authentication");
             
        }

        public async Task<Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime)
        {


            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { _configuration["ExternalLoginSettings:Google:Client_ID"] }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);

            var info = new UserLoginInfo("GOOGLE", payload.Subject, "GOOGLE");
            Domain.Entities.Identity.AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            return await CreateUserExternalAsync(user, payload.Email,payload.Name,info,accessTokenLifeTime);
        
            }
        
        public Task<Token> FacebookLoginAsync(string authToken, int accessTokenLifeTime)
        {
            throw new NotImplementedException();
        }

         
        public async Task<Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime)
        {
            
            Domain.Entities.Identity.AppUser user = await _userManager.FindByNameAsync(usernameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(usernameOrEmail);

            if (user == null)
                throw new NotFoundUserException("Hatalı giriş");

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded)//authentication başarılı
            {
                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime); 
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 15);


                return token; 
            } 

            throw new AbandonedMutexException();
              
        }

        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
         AppUser? user= await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
           
            if (user!=null&&user?.RefleshTokenEndDate>DateTime.UtcNow)
            {
                Token token = _tokenHandler.CreateAccessToken(15);

               await _userService.UpdateRefreshTokenAsync(token.RefreshToken,user, token.Expiration, 300);

                return token;
            }
            else
            throw new NotFoundUserException();

        }

        public async Task PasswordResetAsnyc(string email)
        { 
            AppUser user = await _userManager.FindByEmailAsync(email);

            if (user !=null)
            {
                string  resetToken=await _userManager.GeneratePasswordResetTokenAsync(user);

                //byte[] tokenBytes = Encoding.UTF8.GetBytes(resetToken);
                //resetToken=WebEncoders.Base64UrlEncode(tokenBytes);
               resetToken= resetToken.UrlEncode();
                await _mailService.SendMailAsync(email,user.Id,resetToken);
               
            } 
           

        }

        public async Task<bool> VerifyResetTokenAsync(string resetToken, string userId)
        { 
           AppUser user=await _userManager.FindByIdAsync(userId);
            if (user!=null)
            {
                //byte[] tokenBytes= WebEncoders.Base64UrlDecode(resetToken);
                //resetToken= Encoding.UTF8.GetString(tokenBytes);
                  resetToken = resetToken.UrlDecode();
             return await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider,"ResetPassword", resetToken);
            }
            return false;

        }
    }
}
