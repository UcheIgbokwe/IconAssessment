using System.ComponentModel.DataAnnotations;

namespace Application.Contracts.Domain.DTOs
{
    public class AuthenticateRequest
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}