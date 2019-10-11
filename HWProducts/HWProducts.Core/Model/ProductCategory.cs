using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWProducts.Core.Model
{
    public class ProductCategory
    {
        public string Id { get; set; }
        [Required]
        [DisplayName("Enter Product Category")]
        public string Category { get; set; }

        public ProductCategory()
        {
            this.Id = Guid.NewGuid().ToString(); 
            // Initialising the ID
        }


    }
}
