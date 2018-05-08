using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.Models
{
    public interface IProductsRepository
    {
        IList<ProductDto> ListAllProducts();

        IList<ProductDto> ListProductsByName(string name);

        ProductDto GetProductById(Guid id);

        bool IsNew(Guid id);
    }
}
