using Core.Uti.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IProductmenService
    {
        IResults Register(User user);
        IDataResult<string> Login(User user);
        IResults Add(Product Pro);
        IResults Update(Product Pro);
        IResults Delete(Product Pro);


    }
}
