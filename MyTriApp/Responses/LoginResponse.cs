namespace MyTriApp.Responses
{
    public class LoginResponse
    {
        public bool IsSuccess { get; set; }
        public LoginResponse(bool success)
        {
            IsSuccess = success;
        }
    }
}
