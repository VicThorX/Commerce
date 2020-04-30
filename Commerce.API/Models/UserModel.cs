using Commerce.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Commerce.API.Models
{
    public class UserModel
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public Address Address { get; set; }
    }
}
