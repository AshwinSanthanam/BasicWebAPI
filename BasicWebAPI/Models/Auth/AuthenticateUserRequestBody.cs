namespace BasicWebApi.Models.Auth
{
    public class AuthenticateUserRequestBody
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
