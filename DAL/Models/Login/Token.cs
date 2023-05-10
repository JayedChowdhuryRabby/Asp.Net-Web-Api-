using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Login
{
    public class Token
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TokenString { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string UserEmail { get; set; }
    }
}
