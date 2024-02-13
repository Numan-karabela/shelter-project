using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Abstractions.Services.Authentications
{
    public interface IExternalAuthentications
    {

        Task<DTOs.Token> GoogleLoginAsync(string idToken,int accessTokenLifeTime);
        Task<DTOs.Token> FacebookLoginAsync(string authToken, int accessTokenLifeTime); 


    }
}
