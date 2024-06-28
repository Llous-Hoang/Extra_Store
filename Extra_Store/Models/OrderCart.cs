using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Extra_Store.Models
{
    public class OrderCart
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        [DisplayName("Số lượng")]
        [DefaultValue(1)]
        public int Quantity { get; set; } = 1;

        [DisplayName("Ngày thêm vào giỏ")]
        [DataType(DataType.DateTime)]
        public DateTime DateAdded { get; set; } = DateTime.Now;

        // Navigation reference property cho khóa ngoại đến Account
        public Account Customer { get; set; }

        // Navigation reference property cho khóa ngoại đến Product
        public Product Product { get; set; }
    }
}
