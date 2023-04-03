using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaptopShop.Models.EF
{
    [Table("Laptop")]
    public class Laptop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(50)")]
        public string OperatingSystem { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(100)")]
        public string Monitor { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(100)")]
        public string CPU { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(100)")]
        public string Storage { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(100)")]
        public int RAM { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(100)")]
        public string Graphics { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(50)")]
        public string Color { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(100)")]
        public string BatteryInfor { get; set; } // dung lượng pin

        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? PriceSale { get; set; } // giá khuyến mãi

        [Required(ErrorMessage = "This field is required")]
        public int Quantity { get; set; } // số lượng còn trong kho

        [Required(ErrorMessage = "This field is required")]
        public int Warranty { get; set; } // số tháng bảo hành

        [Column(TypeName = "ntext")]
        public string? ImageUrl { get; set; } // link hình ảnh

        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "ntext")]
        public string DetailDescription { get; set; }

        public int? BrandId { get; set; } // mã nhà sản xuất
        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        public int? LaptopCategoryId { get; set; } // mã danh mục sản phẩm
        [ForeignKey("LaptopCategoryId")]
        public virtual LaptopCategory LaptopCategory { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
