namespace MyTriApp.DTO
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
