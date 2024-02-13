using BarinakAPI.Application.Abstractions.Services;
using BarinakAPI.Application.DTOs.User;
using BarinakAPI.Application.Exceptions;
using BarinakAPI.Application.ViewModel.Animals;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BarinakAPI.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {

           CreateUserResponse response= await _userService.CreateAsync(new()
            {
                Email = request.Email,
                NameSurname = request.NameSurname,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,
                Username = request.Username,
                 
            });

            return new()
            {
                Message = response.Message,
                Succeeded = response.Succeeded,
            };

        }
    }
}
