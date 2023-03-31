using APIJWT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace APIJWT.Services
{
    public class ProductRepository : IProducts
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<ProductsModel> CreateProduct(ProductsModel newproduct)
        {
            var res = await context.Products.AddAsync(newproduct);
            await context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<ProductsModel> GetProductById(int Productid)
        {
            var res = await context.Products.FirstOrDefaultAsync(x => x.Id == Productid);
            return res;
        }

        public async Task<IEnumerable> GetProducts(Specifications.ParameterSpecification parameterSpecification)
        {

            var res = await context.Products.Include(a => a.Category).
                Skip((parameterSpecification.PageNumber -1) * parameterSpecification.PageSize)
                .Take(parameterSpecification.PageSize)
                .ToListAsync();
            return res;
        }

        public async Task<ProductsModel> UpdateProduct(ProductsModel product)
        {
            var res = await context.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
            if (res != null)
            {
                res.Price = product.Price;
                res.ProductName = product.ProductName;
                res.Description = product.Description;

                await context.SaveChangesAsync();
                return res;

            }
            return null;
        }
        public async Task<ProductsModel> DeleteProduct(int ProductId)
        {
            var res = await context.Products.FirstOrDefaultAsync(e => e.Id == ProductId);
            if (res != null)
            {
                context.Products.Remove(res);
                await context.SaveChangesAsync();
                return res;
            }
            return null;
        }

        public async Task<List<ProductsModel>> GetClothesProducts()
        {
            var res = await context.Products.Where(a => a.Category.Id == 1).ToListAsync();
            return res;
        }
        public async Task<List<ProductsModel>> GetElectronicsProducts()
        {
            var res = await context.Products.Where(a => a.Category.Id == 2).ToListAsync();
            return res;
        }
    }
}
