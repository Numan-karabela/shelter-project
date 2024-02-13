using BarinakAPI.Application.DTOs.User;
using BarinakAPI.Domain.Entities.Identity;

namespace BarinakAPI.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUser model);
        Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);

        Task UpdatePasswordAsync(string userId,string resetToken,string newPassword);
         

    }
}
