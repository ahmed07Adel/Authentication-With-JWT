using APIJWT.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJWT.Services
{
   public interface ICategory
    {
        Task<IEnumerable> GetCategories();
        Task<Category> GetCategorieById(int id);
    }
}
