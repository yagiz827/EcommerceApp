using Core.Uti.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busi.Abstract
{
    public interface ICategoryService
    {
        IDataResult <List<Category>> GetAll();
        IDataResult <Category> GetById(int id);
        IDataResult <Category> GetByName(string name);
        
    }
}
