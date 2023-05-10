using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class SellerDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Seller_Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Shop_Name { get; set; }
        [Required]
        public string Seller_Email { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Seller_Password { get; set; }
        [Required]
        public string Seller_Address { get; set; }
        [Required]
        public string Seller_Phone { get; set; }
        public DateTime Seller_JoinDate { get; set; }
        public string Seller_Picture { get; set; }
    }
}
