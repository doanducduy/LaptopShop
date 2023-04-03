using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaptopShop.Models.EF
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(50)")]
        public string CustomerName { get; set; } // họ tên người nhận hàng

        [Column(TypeName = "nvarchar(70)")]
        public string? CustomerEmail { get; set; } // email người nhận hàng

        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(20)")]
        public string CustomerPhone { get; set; } // số điện thoại nhận hàng

        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(250)")]
        public string CustomerAddress { get; set; } // địa chỉ nhận hàng

        [Required(ErrorMessage = "This field is required")]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(50)")]
        public string Status { get; set; } // đã đặt | đã huỷ đơn

        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
