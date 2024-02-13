using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.Role.CreateRole
{
    public class CreateRoleCommanRequest:IRequest<CreateRoleCommanResponse>
    {
        public string Name { get; set; }
    }
}
