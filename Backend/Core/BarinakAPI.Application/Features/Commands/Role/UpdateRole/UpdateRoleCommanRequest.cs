using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.Role.UpdateRole
{
    public class UpdateRoleCommanRequest:IRequest<UpdateRoleCommanResponse>
    {
        public string Id { get; set; }
        public string Name{ get; set; }  

    }
}
