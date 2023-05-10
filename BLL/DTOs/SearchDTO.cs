using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class SearchDTO
    {
        public int search_Id { get; set; }


        public int cust_id { get; set; }

        public string search_text { get; set; }
    }
}
