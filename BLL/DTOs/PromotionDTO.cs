using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PromotionDTO
    {
        public int prompid { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public DateTime start_date { get; set; }


        public DateTime end_date { get; set; }
        public int discount_amount { get; set; }
    }
}
