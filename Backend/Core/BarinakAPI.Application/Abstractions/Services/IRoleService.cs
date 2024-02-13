using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Abstractions.Services
{
    public interface IRoleService
    {
        Object GetAllRoles(int page,int size);   
        Task<(string id, string name)> GetRoleById(string id);
        Task<bool> CreateRole(string name); 
        Task<bool> DeleteRole(string name);
        Task<bool> UpdateRole(string id, string name);

    }
}
