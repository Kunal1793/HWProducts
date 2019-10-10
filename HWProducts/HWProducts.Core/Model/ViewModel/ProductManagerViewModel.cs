using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWProducts.Core.Model.ViewModel
{
    public class ProductManagerViewModel
    {
        public Product Product { get; set; }

        public IEnumerable<ProductCategory> productCategories { get; set; }
    }
}
