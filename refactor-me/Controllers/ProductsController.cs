using System;
using System.Net;
using System.Web.Http;
using refactor_me.Models;
using System.Collections.Generic;
using refactor_me.Service;

namespace refactor_me.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {

        private IProductsRepository _productsRepository;
        private IProductsService _productsService;

        public ProductsController()
        {
            _productsRepository = new ProductsRepository();
            _productsService = new ProductsService();
        } 
        
        //List all the products
        [Route]
        [HttpGet]
        public IEnumerable<ProductDto> ListAll()
        {
            var productsList = _productsRepository.ListAllProducts();
            return productsList;
        }

        //Search product by name
        [Route]
        [HttpGet]
        public IEnumerable<ProductDto> SearchByName(string name)
        {
            var productsList = _productsRepository.ListProductsByName(name);
            return productsList;
        }

        //Get a specific product by productid
        [Route("{id}")]
        [HttpGet]
        public ProductDto Get(Guid id)
        {
            //If the product doesn't exist, throw exception
            if (_productsRepository.IsNew(id))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var product = _productsRepository.GetProductById(id);
            return product;
        }

        //Create a new product
        [Route]
        [HttpPost]
        public void Create(Product product)
        {
            _productsService.Save(product);
        }

        //Update an existing product
        [Route("{id}")]
        [HttpPut]
        public void Update(Guid id, Product product)
        {
            _productsService.Update(id, product);
        }

        //Delete an existing product
        [Route("{id}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            _productsService.Delete(id);
        } 
    }
}
