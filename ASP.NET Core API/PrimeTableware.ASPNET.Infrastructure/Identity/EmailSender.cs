using Microsoft.AspNetCore.Identity.UI.Services;

namespace PrimeTableware.ASPNET.Infrastructure.Identity
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }
    }
}
