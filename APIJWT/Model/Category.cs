using APIJWT.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJWT.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductsModel> Products { get; set; }

    }
}
