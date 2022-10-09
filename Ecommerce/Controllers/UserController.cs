using Microsoft.AspNetCore.Mvc;
using Bussiness.Abstract;
using Bussiness.Concrete;
using DataAccessLayer.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

using System;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using Core.Hashing;
using StackExchange.Redis;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Caching.Distributed;

namespace Ecommerce.Controllers
{
    
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        uIUserService _uIUserService;
        private readonly IConnectionMultiplexer _redis;

        public UserController(IUserService userService, uIUserService uIUserService)
        {
            _userService = userService;
            _uIUserService = uIUserService;
        }
        
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(UserRegDto reg)
        {
            User _user= new User();
            Hashing.hash(reg.password, out byte[] PasHash, out byte[] PasSalt);

            _user.Name = reg.name;
            _user.PasswordSalt = PasSalt;
            _user.PasswordHash = PasHash;
            var r = _userService.Add(_user);

            if (r.Succes)
            {
                return Ok(r);
            }
            return BadRequest(r);
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult LogIn(UserRegDto reg)
        {
            List<User> users = _userService.GetAll().Data;
            var i = users.Where(x => x.Name == reg.name).SingleOrDefault();
            if (i!=null)
            {
                Hashing.VerifyPass(reg.password, i.PasswordHash, i.PasswordSalt);
                var R = _userService.Login(i);
                return Ok(R);


            }
            return BadRequest();
        }
        [HttpPost]
        [Route("addToCart")]
        //[Authorize(Roles="User")]
        public IActionResult Cart(ProductDto pro,int count)
        {
            using(var db=new Database())
            {
                var t=db.products.Where(x => x.Name == pro.ProductName).SingleOrDefault();
            

            string Id = _uIUserService.GetUserId();
            

            var m=_userService.AddToBasket(t, count,"1");
            return Ok(m);}
        }
        [HttpGet]
        [Route("BuyTheCart")]
        public IActionResult BuyCart()
        {
           using(var db=new Database())
            {
                //var y=db.productBaskets.Where(x => x.UserID.ToString() == _uIUserService.GetUserId()).ToList();
                var y=db.productBaskets.Where(x => x.UserID.ToString() == "1").ToList();
                _userService.BuyTheBasket(y);
                return Ok(y);


            }


        }
        [HttpGet]
        [Route("ShowTheCart")]
        public IActionResult Cart()
        {
            return Ok(_userService.ShowBasket());
        }
    }

}
