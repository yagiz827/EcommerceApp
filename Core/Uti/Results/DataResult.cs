using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Uti.Results
{
    public class DataResult<T> :Result, IDataResult<T>

    {

        public DataResult(T Data, bool succes, string Mes) : base(succes, Mes)
        {
            this.Data = Data;
        }
    public DataResult( T Data, bool succes) : base(succes)
        {
            this.Data = Data;
        }

        public T Data { get; }



    }
}
