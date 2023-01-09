using ApiProject.Dtos;
using ApiProject.Models;

namespace ApiProject.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> Login(UserDto request);
        Task<ServiceResponse<int>> Register(UserDto request);
    }
}
