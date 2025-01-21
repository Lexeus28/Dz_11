using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Dz_Tumak_11._2.BankClasses
{
    public class BankTransaction
    {
        public DateTime date { get; }
        public decimal sum { get; }

      public BankTransaction (decimal sum)
        { 
          this.sum = sum;
          this.date = DateTime.Now;
        }
    }
}
