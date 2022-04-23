using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterTheDungeon.Data.Models
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(128)]
        [Required]
        public string Username { get; set; }

        [MaxLength(128)]
        [Required]
        public string Email { get; set; }

        [MaxLength(128)]
        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public int Salt { get; set; }
    }
}
