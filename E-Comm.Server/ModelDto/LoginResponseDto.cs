using E_Comm.Server.Entities;

namespace E_Comm.Server.ModelDto
{
    public class LoginResponseDto
    {
        public string Email { get; set; }
        public string UserId { get; set; }
        public UserRole eRole { get; set; }
        public string Token { get; set; }
    }

    public class LoginErrorResponse()
    {
        public bool isSuccess { get; set; }
        public string error { get; set; }
    }
}
