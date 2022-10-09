using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Uti.Results
{
    public class SuccesResult : Result
    {
        public SuccesResult(string Mes) : base(true,Mes)
        {
        }public SuccesResult() : base(true)
        {
        }
    }
}
