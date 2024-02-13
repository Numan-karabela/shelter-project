using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.AppUser.PasswordReset
{
    public class PasswordResetCommandRequest:IRequest<PasswordResetCommandRespons>
    {
        public string Email { get; set; }


    }
}
