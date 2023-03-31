using APIJWT.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJWT.Services
{
   public interface IProducts
    {
        Task<ProductsModel> CreateProduct(ProductsModel newproduct);
        Task<IEnumerable> GetProducts(Specifications.ParameterSpecification parameterSpecification);
        Task<ProductsModel> GetProductById(int Productid);
        Task<ProductsModel> UpdateProduct(ProductsModel product);
        Task<ProductsModel> DeleteProduct(int ProductId);
        Task<List<ProductsModel>> GetClothesProducts();
        Task<List<ProductsModel>> GetElectronicsProducts();
    }
}
