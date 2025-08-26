namespace E_Comm.Server.Services.EmailService
{
    public interface IEmailSerice
    {
        Task SendEmailAsync(string to, string subject, string htmlBody);
    }
}
