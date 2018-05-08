using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.Models
{
    public interface IProductOptionsRepository
    {
        IList<ProductOptionDto> ListProductOptionsByProductId(Guid productId);

        ProductOptionDto GetOptionById(Guid productId, Guid id);

        bool IsNew(Guid id);
    }
}
