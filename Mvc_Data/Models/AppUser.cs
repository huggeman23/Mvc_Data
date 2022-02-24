using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Mvc_Data.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set;}
        [Required]
        public string LastName { get; set;}
        [Required]
        public int Age { get; set;}
    }
}
