using BarinakAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.Role.CreateRole
{
    public class CreateRoleCommanHandler : IRequestHandler<CreateRoleCommanRequest, CreateRoleCommanResponse>
    {
        readonly IRoleService _roleService;

        public CreateRoleCommanHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<CreateRoleCommanResponse> Handle(CreateRoleCommanRequest request, CancellationToken cancellationToken)
        {
          var result= await _roleService.CreateRole(request.Name);
            return new()
            {
                Succeeded= result
            };
             
        }
    }
}
