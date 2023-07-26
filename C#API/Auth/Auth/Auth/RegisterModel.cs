using System.ComponentModel.DataAnnotations;

namespace JWTAuth.Auth
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username Required")]
        public string? Username { get; set; } 

        [Required(ErrorMessage = "Email Required")]

        public string? Email { get; set; } 

        [Required(ErrorMessage ="Password Required")]
        public string? Password { get; set; }

    }
}
