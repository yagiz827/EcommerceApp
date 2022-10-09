using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Uti.Results
{
    public interface IResults
    {
        bool Succes { get; }
        string Message { get; }

    }
}
