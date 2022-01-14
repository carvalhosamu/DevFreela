namespace DevFreela.Application.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; private set; }
        public string Token { get; private set; }

        public LoginViewModel(string email, string token)
        {
            Email = email;
            Token = token;
        }
    }
}
