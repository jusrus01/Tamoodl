using System.ComponentModel.DataAnnotations;

namespace TamoodlApi.Models
{
    public class TokenResponseModel
    {
        public string Token { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Message { get; set; }

        public void Error(string message)
        {
            Token = null;
            IsAuthenticated = false;
            Message = message;
        }

        public void Authenticated(string token)
        {
            Token = token;
            IsAuthenticated = true;
            Message = "Logged in";
        }
    }
}