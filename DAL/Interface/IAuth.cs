using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IAuthIAuth<Ret>
    {
        Ret Authenticate(string email, string password);
    }
}
