using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.Service
{
    public interface IProductsService
    {
        void Save(Product product);

        void Update(Guid id, Product product);

        void Delete(Guid id);
    }
}
