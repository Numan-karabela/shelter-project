using BarinakAPI.Application.Abstractions.Services.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Abstractions.Services
{
    public interface IAuthService:IExternalAuthentications,IInternalAuthentications
    {
        Task PasswordResetAsnyc(string email);
        Task<bool> VerifyResetTokenAsync(string resetToken,string userId);

      
    }
}
