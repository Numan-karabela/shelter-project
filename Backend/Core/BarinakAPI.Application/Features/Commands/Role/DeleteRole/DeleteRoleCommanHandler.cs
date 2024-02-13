using BarinakAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.Role.DeleteRole
{
    public class DeleteRoleCommanHandler : IRequestHandler<DeleteRoleCommanRequest, DeleteRoleCommanResponse>
    {
        readonly IRoleService _roleService;

        public DeleteRoleCommanHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<DeleteRoleCommanResponse> Handle(DeleteRoleCommanRequest request, CancellationToken cancellationToken)
        {

          var result= await _roleService.DeleteRole(request.Name);
            return new()
            {
                      Succeeded=result,
            };
        }
    }
}
