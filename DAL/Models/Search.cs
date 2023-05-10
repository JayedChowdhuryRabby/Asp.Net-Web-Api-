using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Search
    {

        [Key]
        public int search_Id { get; set; }

        [ForeignKey("Customer")]
        public int cust_id { get; set; }

        public string search_text { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
