using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.Role.DeleteRole
{
    public class DeleteRoleCommanRequest:IRequest<DeleteRoleCommanResponse>
    {
        public string Name { get; set; }
    }
}
