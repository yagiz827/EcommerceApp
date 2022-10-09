using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Uti.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T Data, string mes) : base(Data, false, mes)
        {

        }
        public ErrorDataResult(T Data) : base(Data, false)
        {

        }
        public ErrorDataResult(string no) : base(default, false)
        {

        }
    }
}
