using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaptopShop.Models.EF
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(100)")]
        public string Status { get; set; }

        public DateTime? ReceivedDate { get; set; } // ngày nhận hàng

        [Column(TypeName = "ntext")]
        public string? Note { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int? LaptopId { get; set; }
        [ForeignKey("LaptopId")]
        public virtual Laptop Laptop { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int? OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
    }
}
