using E_Comm.Server.Entities;
using E_Comm.Server.ModelDto;

namespace E_Comm.Server.Services.AuthService
{
    public interface IAuthService
    {
        Task<LoginResponseDto> Login(LoginRequestDto loginRequest);
        Task<bool> CheckEmailExist(string email);
        Task<ResponseDto> Register(User user);
    }
}
