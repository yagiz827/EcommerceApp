using Bussiness.Abstract;
using Bussiness.Cons;
using Core.Uti.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class ProductManManagament : IProductmenService
    {
        IProductManDal _productManDal;
            public ProductManManagament(IProductManDal productManDal)
        {
            _productManDal = productManDal;

        }
        public IResults Add(Product Pro)
        {
            using(var db =new Database())
            {

                db.products.Add(Pro);
                db.SaveChanges();
                return new SuccesResult(Message.AllGot);
            }
        }

        public IResults Delete(Product Pro)
        {
            using(var db=new Database())
            {
                db.products.Remove(Pro);
                db.SaveChanges();
                return new SuccesResult(Message.AllGot);


            }
        }

        public IDataResult<string> Login(User user)
        {
            throw new NotImplementedException();
        }

        public IResults Register(User user)
        {
            throw new NotImplementedException();
        }

        public IResults Update(Product Pro)
        {
            throw new NotImplementedException();
        }
    }
}
