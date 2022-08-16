using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStoreEcommerce
{
    public class Account
    {
        public int ID { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public int Sex { get; set; } = 0;
        public DateTime Birthday = DateTime.Now;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public int ProvinceCode { get; set; } = 0;
        public int DistrictCode { get; set; } = 0;
        public string Address { get; set; } = string.Empty;
        public DateTime CreatedAt = DateTime.Now;
        public string UserName { get; set; } = string.Empty;
    }
    public class AccountResgiter
    {
        public int ID { get; set; } = 0;
        public int Type { get; set; } = 0;
        public int Sex { get; set; } = 0;
        [Required(ErrorMessage = "Hãy chọn ngày sinh")]
        [Range(typeof(DateTime), minimum: "1975-05-14", maximum: "2002-01-01", ErrorMessage = "Chọn ngày sinh sai, hãy nhập lại")]
        public DateTime Birthday { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Hãy nhập email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Đây không phải là email, hãy nhập lại")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Hãy nhập họ tên")]
        [StringLength(255, ErrorMessage = "Không được nhập quá 255 kí tự")]
        public string FullName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Hãy nhập số điện thoại")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Đây không phải là số điện thoại, hãy nhập lại")]
        public string Phone { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        //[Range(1, int.MaxValue, ErrorMessage = "Hãy chọn thành phố")]
        public int ProvinceCode { get; set; } = 0;
        //[Range(1, int.MaxValue, ErrorMessage = "Hãy chọn quận huyện")]
        public int DistrictCode { get; set; } = 0;
        [Required(ErrorMessage = "Hãy nhập mật khẩu")]
        [StringLength(20, ErrorMessage = "Không được nhập quá 50 kí tự")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Hãy nhập địa chỉ")]
        [StringLength(255, ErrorMessage = "Không được nhập quá 255 kí tự")]
        public string Address { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Hãy nhập tên tài khoản")]
        [StringLength(50, ErrorMessage = "Không được nhập quá 50 kí tự")]
        public string UserName { get; set; } = string.Empty;
    }
    public class AccountOutput
    {
        public int STT { get; set; } = 0;
        public int ID { get; set; } = 0;
        public int IsActive { get; set; } = 0;
        public string ProvinceName { get; set; } = string.Empty;
        public string DistrictName { get; set; } = string.Empty;
        public int ProvinceCode { get; set; } = 0;
        public int DistrictCode { get; set; } = 0;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public DateTime Day { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Sex { get; set; } = 0;
        public int Type { get; set; } = 0;
        public string PasswordNew { get; set; } = string.Empty;
        public string CheckPassword { get; set; } = string.Empty;
        public string PasswordReNew { get; set; } = string.Empty;
    }
    public class AccountInput
    {
        [Required(ErrorMessage = "Hãy nhập tên đăng nhập")]
        [MinLength(6, ErrorMessage = "Tên đăng nhập phải nhập ít nhất 6 kí tự")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Hãy nhập mật khẩu")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải nhập ít nhất 6 kí tự")]
        public string Password { get; set; } = string.Empty;
    }
    public class AccountSearch
    {
        public string TextSearch { get; set; } = string.Empty;
        public int Screen { get; set; } = 0;
    }
    public class AccountDelete
    {
        public int ID { get; set; } = 0;
    }
    public class AccountAddres
    {
        public string UserName { get; set; } = string.Empty;
    }

}
