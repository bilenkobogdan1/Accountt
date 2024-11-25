using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acount.Entities.Models
{
    public class Account
    {
        public string AccountNumber { get; set; }

        public decimal Sum {  get; set; }

        public DateTime DateCreate { get; set; }
    }
}
