using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Abstractions.Services.Authentications
{
    public interface IInternalAuthentications
    {
        Task<DTOs.Token> LoginAsync(string usernameOrEmail,string password,int accessTokenLifeTime);
        Task<DTOs.Token> RefreshTokenLoginAsync(string refreshToken);



    }
}
