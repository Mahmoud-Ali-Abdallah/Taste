using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taste.Models.DTO.Account
{
    public class RegisterDTO
    {

        [Required]
        public string Email { get; set; }

        /*
         * [Required]
        public string UserName { get; set; }
        */

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password" , ErrorMessage = "The password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
