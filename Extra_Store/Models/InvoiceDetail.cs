using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Extra_Store.Models
{
    public class InvoiceDetail
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }

        public int ProductId { get; set; }

        [DisplayName("Số lượng")]
        [DefaultValue(1)]
        public int Quantity { get; set; } = 1;

        [DisplayName("Đơn giá (VNĐ)")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public decimal UnitPrice { get; set; }

        // Navigation reference property cho khóa ngoại đến Invoice
        public Invoice Invoice { get; set; }

        // Navigation reference property cho khóa ngoại đến Product
        public Product Product { get; set; }
    }
}
