using BarinakAPI.Application.Abstractions.Services;
using MediatR;

namespace BarinakAPI.Application.Features.Queries.Role.GetRolesById
{
    public class GetRolesByIdQueryHandler : IRequestHandler<GetRolesByIdQueryRequest, GetRolesByIdQueryResponse>
    {
        readonly IRoleService _roleService;

        public GetRolesByIdQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<GetRolesByIdQueryResponse> Handle(GetRolesByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _roleService.GetRoleById(request.Id);
            return new()
            {
                Id = data.id,
                Name = data.name,
            };
        }
    }
}
