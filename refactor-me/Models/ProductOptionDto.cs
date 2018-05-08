using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_me.Models
{
    public class ProductOptionDto
    {
        public System.Guid Id { get; set; }
        public System.Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}