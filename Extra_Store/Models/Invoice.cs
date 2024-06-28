using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Extra_Store.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [DisplayName("Ngày lập hóa đơn")]
        [DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set; } = DateTime.Now;

        [DisplayName("Tổng tiền")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public decimal TotalAmount { get; set; }

        // Navigation reference property cho khóa ngoại đến Account
        public Account Customer { get; set; }

        // Collection reference property cho khóa ngoại từ InvoiceDetail
        public List<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
