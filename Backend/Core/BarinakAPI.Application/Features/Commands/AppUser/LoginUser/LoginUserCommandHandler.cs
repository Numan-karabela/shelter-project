using BarinakAPI.Application.Abstractions.Services;
using BarinakAPI.Application.Abstractions.Token;
using BarinakAPI.Application.DTOs;
using BarinakAPI.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {

        readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
          var Token=await _authService.LoginAsync(request.UsernameOrEmail, request.Password,900);
            return new LoginUserSuccessCommanResponse()
            {
                Token = Token
            };
           
            
            
        }
    }
}
