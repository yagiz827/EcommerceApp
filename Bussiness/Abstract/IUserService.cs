using Core.Uti.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IUserService
    {
        IResults Add(User user);
        IDataResult<List<User>> GetAll();
        IResults Register(User user);
        IDataResult<string> Login(User user);
        IResults BuyTheBasket(List<ProductBasket> pros);
        IResults AddToBasket(Product product, int Count, string Id);
        IResults GetOrderDetails(OrderDetail det);
        IResults ShowBasket();
        IResults Delete(User user);

    }
}
