using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Login
{
    public class TokenDTO
    {
        [Required]
        public string TokenString { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        [Required]
        public string UserEmail { get; set; }
    }
}
