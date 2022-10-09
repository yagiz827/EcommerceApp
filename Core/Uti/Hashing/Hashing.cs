
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Uti.Hashing
{
    //public class Hashing:IHashing
    //{
    //    IHashing _hashing;
    //    public Hashing(IHashing hashing)
    //    {
    //        _hashing = hashing;
    //    }

    //    _hashing.
    //    public static void hash(string password, out byte[] PasHash, out byte[] PasSalt)
    //    {
    //        using (var Hmac = new HMACSHA512())
    //        {
    //            PasSalt = Hmac.Key;
    //            PasHash = Hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    //        }
    //    }
    //    public  static bool VerifyPass(string password, byte[] PasHash, byte[] PasSalt)
    //    {
    //        using (var hmac = new HMACSHA512(PasSalt))
    //        {
    //            var compH = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    //            return compH.SequenceEqual(PasHash);
    //        }
    //    }
    //}
}
