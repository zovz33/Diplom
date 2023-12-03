namespace Diplom.ASPNET.Application.Items.Auth.Registartion
{
    public class RegistrationCommand
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string ConfirmPasswordHash { get; set; }
    }
}
