using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Promotion
    {
        [Key]
        public int prompid { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }

        public DateTime start_date { get; set; }


        public DateTime end_date { get; set; }
        [Required]
        public int discount_amount { get; set; }


    }
}
