using refactor_me.Models;
using refactor_me.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace refactor_me.Controllers
{
    public class ProductOptionsController : ApiController
    {
        private IProductOptionsRepository _productOptionsRepository;
        private IProductOptionsService _productOptionsService;

        public ProductOptionsController()
        {
            _productOptionsRepository = new ProductOptionsRepository();
            _productOptionsService = new ProductOptionsService();
        }

        //List all the product options belonging to a product
        [Route("products/{productId}/options")]
        [HttpGet]
        public IEnumerable<ProductOptionDto> ListAll(Guid productId)
        {
            var productOptionsList = _productOptionsRepository.ListProductOptionsByProductId(productId);
            return productOptionsList;
        }

        //Get the specific product option by productid and optionid
        [Route("products/{productId}/options/{id}")]
        [HttpGet]
        public ProductOptionDto Get(Guid productId, Guid id)
        {
            //If the option doesn't exists, throw exception
            if (_productOptionsRepository.IsNew(id))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var option = _productOptionsRepository.GetOptionById(productId, id);

            return option;
        }

        //Create a new product option
        [Route("products/{productId}/options")]
        [HttpPost]
        public void Create(Guid productId, ProductOption option)
        {
            _productOptionsService.Save(productId, option);
        }

        //Update an existing product option
        [Route("products/{productId}/options/{id}")]
        [HttpPut]
        public void Update(Guid id, ProductOption option)
        {
            _productOptionsService.Update(id, option);
        }

        //Delete an existing product option
        [Route("products/{productId}/options/{id}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            _productOptionsService.Delete(id);
        }
    }
}