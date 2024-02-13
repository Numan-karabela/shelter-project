using BarinakAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.Role.UpdateRole
{
    public class UpdateRoleCommanHandler : IRequestHandler<UpdateRoleCommanRequest, UpdateRoleCommanResponse>
    {
        readonly IRoleService _roleService;

        public UpdateRoleCommanHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<UpdateRoleCommanResponse> Handle(UpdateRoleCommanRequest request, CancellationToken cancellationToken)
        {
          var result= await _roleService.UpdateRole(request.Id, request.Name);
            return new()
            {
                Succeeded = result
            };

        }
    }
}
