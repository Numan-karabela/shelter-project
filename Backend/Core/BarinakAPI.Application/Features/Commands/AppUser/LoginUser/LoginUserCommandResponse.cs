using BarinakAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandResponse
    {



    }
    public class LoginUserSuccessCommanResponse: LoginUserCommandResponse
    {
        public Token Token { get; set; }

    }

    public class LoginUserErrorCommanResponse: LoginUserCommandResponse
    {
        public string Message { get; set; }
    }
}
