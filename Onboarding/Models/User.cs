using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.Models
{
    public class User
    {
        public int UserID { get; set; }
        public int UserRole { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Firstname { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Lastname { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        [EmailAddress]
        [RegularExpression(@"^\w+([-+.']\w+)*@tshimologong.joburg$", ErrorMessage = "Invalid Email.")]

        public string UserEmail { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Password{ get; set; }
    }
}
