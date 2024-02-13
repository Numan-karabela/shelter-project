using Azure.Core;
using BarinakAPI.Application.Abstractions.Services;
using BarinakAPI.Application.DTOs.User;
using BarinakAPI.Application.Exceptions;
using BarinakAPI.Application.Features.Commands.AppUser.CreateUser;
using BarinakAPI.Application.Helpers;
using BarinakAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUser model)
        { 
            
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Username,
                Email = model.Email,
                NameSurname = model.NameSurname
            }, model.Password);

            CreateUserResponse response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
                response.Message = "Kullanıcı başarıyla eklendi.";

            else

                foreach (var error in result.Errors)
                {
                    response.Message += $"{error.Code}-{error.Description}<br>";
                }
            return response;
        
        
        
        
        }

        public async Task UpdatePasswordAsync(string userId, string resetToken, string newPassword)
        {
           AppUser user=await _userManager.FindByIdAsync(userId);

            if(user != null)
            {
                resetToken = resetToken.UrlDecode();
                IdentityResult result = await _userManager.ResetPasswordAsync(user,resetToken,newPassword);
                if (result.Succeeded)
                    await _userManager.UpdateSecurityStampAsync(user);
                else
                    throw new Exception();

            }

        }

        public async Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate,int addOnAccessTokenDate)
        {
             if(user!=null)
            {
                user.RefreshToken=refreshToken;
                user.RefleshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);

                await _userManager.UpdateAsync(user);
            }
             else
                throw new NotFoundUserException();


        }


    }
}
