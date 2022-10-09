using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Uti.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string Mes) : base(false, Mes)
        {
        }public ErrorResult() : base(false)
        {
        }
    }
}
