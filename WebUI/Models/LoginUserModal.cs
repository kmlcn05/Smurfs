using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class LoginUserModal
    {
        [Required]
        public string Mail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
