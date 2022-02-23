using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StoreFront.DATA.EF//.Metadata
{
    [MetadataType(typeof(ProductMetadata))]
    public partial class Product { }

    class ProductMetadata
    {
        [StringLength(100)]
        [Required]
        [Display(Name = "Product")]
        public string ProductName { get; set; }

        [Required]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public Nullable<decimal> Price { get; set; }

        [Required]
        [Display(Name = "Manufacturer")]
        public int ManufacturerID { get; set; }

        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        [Required]
        public int StockStatusID { get; set; }

    }
}
