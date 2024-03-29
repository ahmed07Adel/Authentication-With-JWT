﻿using APIJWT.Model;
using APIJWT.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProducts productsRepo;

        public ProductController(IProducts productsRepo)
        {
            this.productsRepo = productsRepo;
        }
        [HttpPost]
        [Route("CreateProduct")]
        public async Task<ActionResult<ProductsModel>> CreateProduct(ProductsModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                var res = await productsRepo.CreateProduct(model);
                return res;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");

            }
        }
        [HttpGet("GetProductById/{id:int}")]
        public async Task<ActionResult<ProductsModel>> GetProductById(int id)
        {
            try
            {
                var res = await productsRepo.GetProductById(id);
                if (res == null)
                {
                    return NotFound();
                }
                return res;
            }
            catch (Exception)
            {   

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
            }
        }
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts([FromQuery]Specifications.ParameterSpecification parameterSpecification)
        {
            try
            {
                return Ok(await productsRepo.GetProducts(parameterSpecification));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
            }
        }
        [HttpPut("UpdateProduct/{id:int}")]
        public async Task<ActionResult<ProductsModel>> UpdateProduct([FromBody]ProductsModel productsModel, int id)
        {
            try
            {

               
                var Prod = await productsRepo.GetProductById(productsModel.Id);
                if (Prod == null)
                {
                    return NotFound($"this product = {productsModel.Id} Can not found");
                }
                return await productsRepo.UpdateProduct(productsModel);
                    
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating data");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductsModel>> DeleteProduct(int id)
        {          
            try
            {
               return await productsRepo.DeleteProduct(id);
            }
          
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
               
            }
        }

        [HttpGet("GetClothesProducts")]
        public async Task<ActionResult<ProductsModel>> GetClothesProducts()
        {
            try
            {
                var res = await productsRepo.GetClothesProducts();
                return Ok(res);
            }

            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");

            }
        }
        [HttpGet("GetElectronicsProducts")]
        public async Task<ActionResult<ProductsModel>> GetElectronicsProducts()
        {
            try
            {
                var res = await productsRepo.GetElectronicsProducts();
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
    }
}
