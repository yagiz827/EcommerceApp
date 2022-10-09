using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    
    public interface IUserDal:IEntityRepository<User>
    {
        ProductBasket AddToBasket(Product Pro,string Id,int Count, RedisCache Cart);
        string BuyTheBasket(List<ProductBasket> baskets);

        OrderDetail GetOrderDetail(OrderDetail orderDetail);
        string Login(User user);
    }
}
