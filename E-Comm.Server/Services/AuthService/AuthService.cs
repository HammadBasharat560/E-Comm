using E_Comm.Server.Entities;
using E_Comm.Server.Helper;
using E_Comm.Server.ModelDto;
using E_Comm.Server.Repositories;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace E_Comm.Server.Services.AuthService
    {
        public class AuthService : IAuthService
        {
            private readonly IConfiguration _configuration;
            private readonly AppDbContext _appDbContext;
            private readonly JwtTokenHelper _jwtTokenHelper;
        private readonly E_Comm.Server.Services.Email.EmailService _emailService;
        // Constructor to inject dependencies
        public AuthService(IConfiguration configuration, AppDbContext appDbContext,JwtTokenHelper jwtTokenHelper)
            {
                _configuration = configuration;
                _appDbContext = appDbContext;
                _jwtTokenHelper = jwtTokenHelper;

            }

            public async Task<LoginResponseDto> Login(LoginRequestDto loginRequest)
            {
                 var response = new LoginErrorResponse();
                if (loginRequest == null)
                {
                    throw new ArgumentNullException(nameof(loginRequest), "Login request cannot be null");
                }
                var userDetail = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == loginRequest.Email && u.Password == loginRequest.Password);
                if(userDetail == null)
                {
                    throw new UnauthorizedAccessException("Invalid email or password");
                }

                if(userDetail.IsApproved == false)
                {
                    response.isSuccess = false;
                    response.error = "User is not active";
                }

                if (userDetail.IsEmailConfirmed == false)
                {
                    response.isSuccess = false;
                    response.error = "please verify you email and active your status";
                }

                var token  = _jwtTokenHelper.GenerateToken(userDetail);

                return new LoginResponseDto
                {
                    UserId = userDetail.Id.ToString(),
                    Email = userDetail.Email,
                    eRole = userDetail.Role,
                    Token = token
                };
            }

        public async Task<bool> CheckEmailExist(string email)
        {
            return await _appDbContext.Users.AnyAsync(u => u.Email == email);
             
        }
        public async Task<ResponseDto> Register(User user)
        {
            if(user == null){
                throw new ArgumentNullException("User connot be null");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password); //password encrypt
            var emailToken = Guid.NewGuid().ToString();  // genrate token for email verification

            var OTP = _jwtTokenHelper.GenerateOTP(); // for future

            user = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = passwordHash,
                PhoneNumber = user.PhoneNumber,
                CompanyName = user.CompanyName,
                Role = user.Role,
                IsApproved = false,
                IsEmailConfirmed = false,
                EmailVerificationExpiry = DateTime.UtcNow.AddDays(5),
                EmailVerificationCode = emailToken,
                IsDeleted = false,
                IsTwoFactorEnabled = false,
                CreatedAt = DateTime.UtcNow,
                ApprovedAt = null
            };

            var result = await _appDbContext.Users.AddAsync(user);
           await _appDbContext.SaveChangesAsync();

          var isEmailSend =  this.SendWelcomeEmail(user);


            return new ResponseDto{
                isSuccess = true,
                errorMessage = null,
                data = null
            };
        }


        private string SendWelcomeEmail(User user)
        {
            return $@"
        <!DOCTYPE html>
        <html>
        <body>
            <style>
            body {{
                font-family: Arial, sans-serif;
                background-color: #f4f4f4;
                color: #333;
                padding: 20px;
            }}
            h1 {{
                color: #4CAF50;
            }}
            a {{
                color: #4CAF50;
                text-decoration: none;
            }}
            </style>    
            <h1> h1, {user.Name}</h1>
            <h2>Welcome to E-Comm</h2>
            <p>Click below to verify your email:</p>
            <a href=""https://yourdomain.com/api/auth/verify-email?token={user.EmailVerificationCode}"">Verify Email</a>
        </body>
        </html>";
        }

        //private async Task SendOTPSms(string phoneNumber, string otp)
        //{
        //    var message = $"Your verification code is: {otp}. It will expire in 10 minutes.";
        //    await _smsService.SendSmsAsync(phoneNumber, message);
        //}
    }
    }
