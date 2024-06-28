using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Extra_Store.Models
{
    public class Account
    {
        public int Id { get; set; }

        [DisplayName("Tên đăng nhập")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{0} từ 6-20 kí tự")]
        public string Username { get; set; }

        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{0} từ 6-20 kí tự")]
        public string Password { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [EmailAddress(ErrorMessage = "{0} không hợp lệ")]
        public string Email { get; set; }

        [DisplayName("SĐT")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [RegularExpression("0\\d{9}", ErrorMessage = "SĐT không hợp lệ")]
        public string Phone { get; set; }

        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        [DisplayName("Họ và tên")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "{0} từ 6-50 kí tự")]
        public string FullName { get; set; }

        [DisplayName("Ảnh đại diện")]
        public string Avatar { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [DisplayName("Là admin")]
        [DefaultValue(false)]
        public bool IsAdmin { get; set; }

        [DisplayName("Được kích hoạt")]
        [DefaultValue(true)]
        public bool IsActive { get; set; }

        // Collection reference property cho khóa ngoại từ Invoice
        public List<Invoice> Invoices { get; set; }

        // Collection reference property cho khóa ngoại từ Cart
        public List<OrderCart> Carts { get; set; }
    }
}
