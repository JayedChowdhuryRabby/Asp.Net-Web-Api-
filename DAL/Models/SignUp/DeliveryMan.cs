using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.SignUp
{
    public class DeliveryMan
    {
        [Key]
        public int DelId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }

        public string Gender { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime Dob { get; set; }
        [Required]
        public int Zip_Code { get; set; }
        [Required]
        public string nid { get; set; }

    }
}
