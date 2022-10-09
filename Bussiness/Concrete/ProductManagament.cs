using Bussiness.Abstract;
using Core.Uti.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class ProductManagament : IProductService
    {
        public IDataResult<List<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Product>> getByCategory(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Product>> getByUnitPrice(int Limit)
        {
            throw new NotImplementedException();
        }
    }
}
