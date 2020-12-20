namespace Amoozeshyar.Models.Responses
{
    public class LoginResponse
    {
        public bool IsAuthenticated { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        
        
        
        
    }
}