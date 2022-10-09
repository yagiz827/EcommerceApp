using Core.DataAccess.EntityFramework;
using Core.Uti.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class EFUserDal : EfEntityRepository<User, Database>, IUserDal
    {
        public ProductBasket AddToBasket(Product Pro,string Id, int Count, RedisCache Cart)
        {
            using(var db=new Database())
            {
                
                ProductBasket bas = new ProductBasket();
                bas.UserID = Int32.Parse(Id);
                bas.ProductCount = Count;   
                bas.ProductId = Pro.ProductId;
                
                db.productBaskets.Add(bas);
                db.SaveChanges();
                if (Cart.GetString(Id) == null)
                {
                    var str=JsonConvert.SerializeObject(bas);
                    Cart.SetString(Id, str);
                }
                else
                {
                    var u=db.productBaskets.Where(x => x.UserID.ToString() == Id).ToList();
                    Cart.SetString(Id, JsonConvert.SerializeObject(u));

                    var g =JsonConvert.DeserializeObject(Cart.GetString(Id));
                    Console.WriteLine(g);


                }
                return bas;




            }
        }



        public string BuyTheBasket(List<ProductBasket> baskets)
        {
            
            using(var db=new Database())
            {   int Id=1;
                foreach(var t in baskets)
                {
                    Id = t.UserID;
                    break;
                }
                if(db.orders.Where(x => x.UserId == Id).ToList().Count == 0)
                {
                    Orders _order = new Orders();
                    _order.Created = DateTime.Now;
                    _order.UserId= Id;
                    db.orders.Add(_order);
                    db.SaveChanges();
                    
                }
                var y = db.orders.Where(x => x.UserId == 1).SingleOrDefault();
                //foreach (var Item in baskets)
                //{

                //    OrderDetail _det = new OrderDetail();

                //    _det.products = Item.pros;
                //    _det.Count = Item.ProductCount;

                //    _det.OrderId = y.OrderId;

                //    _det.Adress = "Migros";

                //    y.Detail.Add(_det);

                //    db.orders.Update(y);
                //    db.SaveChanges();
                //}

                return "Bought";
                
                
            }
        }



        public string Login(User stu)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, stu.Name),
                new Claim(ClaimTypes.Role,"User"),
                new Claim(ClaimTypes.Spn,stu.UserId.ToString()),

            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Spider2000spider2000SPIDER2000"));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(29),
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public OrderDetail GetOrderDetail(String pro)
        {
            using(var db=new Database())
            {
                OrderDetail _det=new OrderDetail();
                //_det.OrderId = t;
               // _det.pros = db.orders.Where(x => x.UserId == Id).SingleOrDefault().Products;
                //_det.order.Adress;
                return _det;
            }
        }

        public OrderDetail GetOrderDetail(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }
    }
}
