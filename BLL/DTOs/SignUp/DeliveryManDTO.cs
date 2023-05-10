using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.SignUp
{
    public class DeliveryManDTO
    {
        public int DelId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Gender { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime Dob { get; set; }

        public int Zip_Code { get; set; }

        public string nid { get; set; }
    }
}
