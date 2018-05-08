using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_me.Models
{
    public class ProductsRepository : IProductsRepository
    {

        private DatabaseEntities Context;

        public ProductsRepository()
        {
            Context = new DatabaseEntities();
        }

        public void Dispose() { }

        //List all the products
        public IList<ProductDto> ListAllProducts()
        {
            return Context.Products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                DeliveryPrice = p.DeliveryPrice
            }).ToList();
        }

        //List all the products containing the given name
        public IList<ProductDto> ListProductsByName(string name)
        {
            return Context.Products.Where(p => p.Name.Contains(name)).Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                DeliveryPrice = p.DeliveryPrice
            }).ToList();
        }

        //Get specific product
        public ProductDto GetProductById(Guid id)
        {
            return Context.Products.Where(p => p.Id == id).Select(p => new ProductDto {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                DeliveryPrice = p.DeliveryPrice
            }).FirstOrDefault();
        }

        //Check if the product exists or not
        public bool IsNew(Guid id)
        {
            return Context.Products.Count(p => p.Id == id) < 1;
        }
    }
}