using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Uti.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T Data, string mes):base(Data, true, mes)
        {
            
        }
        public SuccessDataResult(T Data):base(Data, true)
        {
            
        }public SuccessDataResult():base(default, true)
        {
            
        }
    }
}
