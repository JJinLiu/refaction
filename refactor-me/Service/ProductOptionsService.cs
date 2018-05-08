using refactor_me.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_me.Service
{
    public class ProductOptionsService : IProductOptionsService
    {
        private DatabaseEntities Context;
        private IProductOptionsRepository _productOptionsRepository;

        public ProductOptionsService()
        {
            Context = new DatabaseEntities();
            _productOptionsRepository = new ProductOptionsRepository();
        }

        public void Save(Guid productId, ProductOption option)
        {
            if (productId != null && option != null)
            {
                var relatedProduct = Context.Products.Find(productId);
                if (relatedProduct != null)
                {
                    option.ProductId = productId;
                    Context.ProductOptions.Add(option);
                    Context.SaveChanges();
                }
                else
                {
                    throw new Exception("Cannot find related product. Productid is {productId}.");
                }
            }
            else
            {
                throw new Exception("ProductId or Option is null.");
            }
        }

        public void Update(Guid id, ProductOption option)
        {
            if (id != null && option != null)
            {
                var existingProductOption = Context.ProductOptions.Find(id);
                if (existingProductOption != null)
                {
                    existingProductOption.Name = option.Name;
                    existingProductOption.Description = option.Description;
                    Context.SaveChanges();
                }
                else
                {
                    throw new Exception("Cannot find the product option. Optionid is {id}.");
                }
            }
            else
            {
                throw new Exception("OptionId or Option is null.");
            }
        }

        public void Delete(Guid id)
        {
            if (id != null)
            {
                var existingProductOption = Context.ProductOptions.Find(id);
                if (existingProductOption != null)
                {
                    Context.ProductOptions.Remove(existingProductOption);
                    Context.SaveChanges();
                }
                else
                {
                    throw new Exception("Cannot find the product option. Optionid is {id}");
                }
            }
            else
            {
                throw new Exception("OptionId is null.");
            }
        }
    }
}