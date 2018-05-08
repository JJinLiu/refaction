using refactor_me.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_me.Service
{
    public class ProductsService : IProductsService
    {
        private DatabaseEntities Context;
        private IProductsRepository _productsRepository;

        public ProductsService()
        {
            Context = new DatabaseEntities();
            _productsRepository = new ProductsRepository();
        }


        public void Save(Product product)
        {
            if (product != null)
            {
                Context.Products.Add(product);
                Context.SaveChanges();
            }
            else
            {
                throw new Exception("Product is null.");
            }
        }

        public void Update(Guid id, Product product)
        {
            if (id != null && product != null)
            {
                var existingProduct = Context.Products.Find(id);
                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    existingProduct.DeliveryPrice = product.DeliveryPrice;
                    existingProduct.Description = product.Description;
                    existingProduct.Price = product.Price;
                    Context.SaveChanges();
                }
                else
                {
                    throw new Exception("Cannot find the product. ProducutId is {id}.");
                }
            }
            else
            {
                throw new Exception("ProductId or Product is null.");
            }
        }

        public void Delete(Guid id)
        {
            if (id != null)
            {
                var existingProduct = Context.Products.Find(id);
                if (existingProduct != null)
                {
                    Context.Products.Remove(existingProduct);
                    Context.SaveChanges();
                }
                else
                {
                    throw new Exception("Cannot find the product. ProductId is {id}");
                }
            }
            else
            {
                throw new Exception("ProductId is null.");
            }
        }
    }
}