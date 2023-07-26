using System.ComponentModel.DataAnnotations;

namespace JWTAuth.Auth
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is invalid")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is invalid")]
        public string? Password { get; set; }

    }
}
