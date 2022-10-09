using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Uti.Results
{
    public class Result : IResults
    {

        public Result(bool success, string Mes):this(success)
        {
            this.Message = Mes;
            this.Succes = success;
        }
        public Result(bool succes)
        {
            Succes = succes;

        }

        public bool Succes { get; }

        public string Message { get; }
    }
}
