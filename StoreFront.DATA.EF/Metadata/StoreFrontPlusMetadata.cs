using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StoreFront.DATA.EF//.Metadata
{

    class ProductMetadata
    {
        [StringLength(100)]
        [Required(ErrorMessage = ("* Required!"))]
        [Display(Name = "Product")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = ("* Required!"))]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public Nullable<decimal> Price { get; set; }

        [Required(ErrorMessage = ("* Required!"))]
        [Display(Name = "Manufacturer")]
        public int ManufacturerID { get; set; }

        [Required(ErrorMessage = ("* Required!"))]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = ("* Required!"))]
        public int StockStatusID { get; set; }
    }

    [MetadataType(typeof(ProductMetadata))]
    public partial class Product { }

    public class CategoryMetadata
    {
        [Required(ErrorMessage = ("* Required!"))]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = ("* Required!"))]
        [Display(Name = ("Category"))]
        public string Category1 { get; set; }
    }
    [MetadataType(typeof(CategoryMetadata))]
    public partial class Category { }

    public class StockStatusIDMetadata
    {
        [Required(ErrorMessage = ("* Required!"))]
        [Display(Name = ("Stock Status ID"))]
        public int StockStatusID1 { get; set; }

        [Required(ErrorMessage = ("* Required!"))]
        [Display(Name = ("Status"))]
        public string StatusName { get; set; }
    }
    [MetadataType(typeof(StockStatusIDMetadata))]
    public partial class StockStatusID { }

    public class DepartmentMetadata
    {
        [Required(ErrorMessage = ("* Required!"))]
        [Display(Name = ("Department ID"))]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = ("* Required!"))]
        [Display(Name = ("Department"))]
        public string DepartmentName { get; set; }
    }
    [MetadataType(typeof(DepartmentMetadata))]
     public partial class Department { }
}
