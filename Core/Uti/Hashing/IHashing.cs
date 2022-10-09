using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Uti.Hashing
{
    public interface IHashing
    {
        public void hash(string password, out byte[] PasHash, out byte[] PasSalt);
        public bool VerifyPass(string password, byte[] PasHash, byte[] PasSalt);
    }
}
