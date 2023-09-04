using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Application.InterfacesApplication;
using Infraestructure.Dto;

namespace ProductManagement.Api.Controllers
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Errors { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public partial class ProductController : ControllerBase
    {
        private readonly IProductUseCase _productUseCase;

        public ProductController(IProductUseCase productUseCase)
        {
            _productUseCase = productUseCase;
        }

        [HttpPost]
        [Route("/create-product")]
        public async Task<IActionResult> CreateProduct(ProductDto productRequest)
        {
            try
            {
                var create = await _productUseCase.CreateProduct(_productUseCase.CreateProductDomain(productRequest.Name, productRequest.Description, productRequest.Category, productRequest.Price, productRequest.Stock));
                if (create)
                {
                    var result = new Result()
                    {
                        IsSuccess = true,
                        Errors = "Product Created"
                    };
                    return Ok(result);
                }

                return BadRequest();

            }
            catch (Exception ex)
            {
                //logger errors
                return BadRequest(ex.Message);

            }
        }


        [HttpGet]
        [Route("/get-product")]
        public async Task<IActionResult> GetProduct(string name, int price1, int price2)
        {
            var user = await _productUseCase.GetProduct(name, price1, price2);
            return Ok(user);
        }

        [HttpPut]
        [Route("/update-product")]
        public async Task<IActionResult> UpdateProduct(ProductDto productRequest)
        {
            try
            {
                var update = await _productUseCase.UpdateProduct(_productUseCase.CreateProductDomain(productRequest.Name, productRequest.Description, productRequest.Category, productRequest.Price, productRequest.Stock));
                if (update)
                {
                    var result = new Result()
                    {
                        IsSuccess = true,
                        Errors = "Product Updated"
                    };
                    return Ok(result);
                }

                return BadRequest();

            }
            catch (Exception ex)
            {
                //logger errors
                return BadRequest(ex.Message);

            }
        }

        [HttpDelete]
        [Route("/delete-product")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var delete = await _productUseCase.DeleteProduct(id);
                if (delete)
                {
                    var result = new Result()
                    {
                        IsSuccess = true,
                        Errors = "Product Deleted"
                    };
                    return Ok(result);
                }

                return BadRequest();

            }
            catch (Exception ex)
            {
                //logger errors
                return BadRequest(ex.Message);

            }
        }
    }
}
