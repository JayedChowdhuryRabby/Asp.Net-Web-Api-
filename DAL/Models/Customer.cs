using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Customer
    {
        [Key]
        public int customer_id { get; set; }
        [Required]
        [StringLength(100)]
        public string first_name { get; set; }
        [Required]
        [StringLength(100)]
        public string last_name { get; set; }
        [Required]
        [StringLength(14)]
        public string phone_number { get; set; }
        [Required]
        [StringLength(100)]
        public string email { get; set; }
        [Required]
        [StringLength(100)]
        public string password { get; set; }
        [Required]
        [StringLength(6)]
        public string gender { get; set; }
        [Required]
        public DateTime dob { get; set; }
        [Required]
        [StringLength(100)]
        public string address { get; set; }
        public string picture { get; set; }
        public string review { get; set; }
    }
}
