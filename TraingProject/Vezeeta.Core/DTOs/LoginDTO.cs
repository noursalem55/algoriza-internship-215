using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Core.Dtos
{
    public class LoginDTO
    {
        [Required]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; } = string.Empty;
        //public bool RememberMe { get; set; }
        //public string Role { get; set; } = string.Empty;
    }
}
