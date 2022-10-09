using Bussiness.Abstract;
using Core.Uti.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class OrderManagement : IOrderService
    {
        public IDataResult<DateTime> GetDate(DateTime i)
        {
            throw new NotImplementedException();
        }
    }
}
