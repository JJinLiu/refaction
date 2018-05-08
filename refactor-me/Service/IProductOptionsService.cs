using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.Service
{
    public interface IProductOptionsService
    {
        void Save(Guid productId, ProductOption option);

        void Update(Guid id, ProductOption option);

        void Delete(Guid id);
    }
}
