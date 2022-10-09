using Bussiness.Abstract;
using Bussiness.Cons;
using Core.Uti.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Entities.Concrete;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{

    public class UserManagement : IUserService
    {
        IUserDal _userDal;
        public UserManagement(IUserDal userDal)
        {
             _userDal= userDal;
        }

        public IResults Add(User user)
        {
            _userDal.Add(user);
            return new SuccesResult(Message.AllGot);


        }

        public IResults AddToBasket(Product product,int Count,string Id)
        {
            var Cart = new RedisCache(new RedisCacheOptions
            {
                Configuration = "127.0.0.1:6379"
            });
            _userDal.AddToBasket(product,Id,Count,Cart);
            return new SuccesResult(Message.AllGot);
        }



        public IResults BuyTheBasket(List<ProductBasket> pros)
        {
            _userDal.BuyTheBasket(pros);
            return new SuccesResult(Message.AllGot);

        }

        public IResults Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetAll()
        {
            _userDal.GetAll();
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Message.AllGot); ;
        }

        public IResults GetOrderDetails(OrderDetail det)
        {
            throw new NotImplementedException();
        }

        public IDataResult<string> Login(User user)
        {
            var u=_userDal.Login(user).ToString();
            return new SuccessDataResult<string>(u,Message.AllGot);
        }

        public IResults Register(User user)
        {
            throw new NotImplementedException();
        }

        public IResults ShowBasket()
        {
            var Cart = new RedisCache(new RedisCacheOptions
            {
                Configuration = "127.0.0.1:6379"
            });
            var t = Cart.GetString("1");
            var y=JsonConvert.DeserializeObject<List<ProductBasket>>(t);
            return new SuccessDataResult<List<ProductBasket>>( y,Message.ProAdded);
        }
    }
}
