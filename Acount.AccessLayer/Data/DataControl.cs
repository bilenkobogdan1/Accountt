using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acount.Entities.Models;
namespace Acount.AccessLayer.Data
{
    public class DataControl
    {
        public static List<Account> accounts;

        public static void Inisilize()
        {
            if (accounts == null)
            {
                accounts = new List<Account>();
            }
        }
    }
}
