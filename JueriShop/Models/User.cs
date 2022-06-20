using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace JueriShop.Models
{   [NotMapped]
    public class User:IdentityUser
    {
        [Key]
        public int IdUser { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public UserOrder? UserOrder { get; set; }
        [NotMapped]
        public object Ida { get; internal set; }
        [NotMapped]
        public object PasswordHasha
        {
            get; internal set;
        }
    }
}
