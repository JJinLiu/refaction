using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_me.Models
{
    public class ProductOptionsRepository : IProductOptionsRepository
    {
        private DatabaseEntities Context;

        public ProductOptionsRepository()
        {
            Context = new DatabaseEntities();
        }

        public void Dispose() { }

        //List all the product options belonging to a product
        public IList<ProductOptionDto> ListProductOptionsByProductId(Guid productId)
        {
            return Context.ProductOptions.Where(o => o.ProductId == productId).Select(o => new ProductOptionDto
            {
                Id = o.Id,
                ProductId = o.ProductId,
                Name = o.Name,
                Description = o.Description
            }).ToList();
        }

        //Get the specific product option by productid and optionid
        public ProductOptionDto GetOptionById(Guid productId, Guid id)
        {
            return Context.ProductOptions.Where(o => o.ProductId == productId && o.Id == id).Select(o => new ProductOptionDto
            {
                Id = o.Id,
                ProductId = o.ProductId,
                Name = o.Name,
                Description = o.Description
            }).FirstOrDefault();
        }

        //Check if the product option is new or not
        public bool IsNew(Guid id)
        {
            return Context.ProductOptions.Count(o => o.Id == id) < 1;
        }
    }
}