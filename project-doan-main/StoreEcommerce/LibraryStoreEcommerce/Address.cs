using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStoreEcommerce
{
    public class Address
    {
        public int STT { get; set; } = 0;
        public int ID { get; set; } = 0;
        public int ProvinceCode { get; set; } = 0;
        public int DistrictCode { get; set; } = 0;
        public string ProvinceName { get; set; } = string.Empty;
        public string DistrictName { get; set; } = string.Empty;
        public string AddressName { get; set; } = string.Empty;
    }
    public class AddressNewInput
    {
        public int ID { get; set; } = 0;
        public string Account { get; set; } = string.Empty;
        public int ProvinceCode { get; set; } = 0;
        public int DistrictCode { get; set; } = 0;
        public string ProvinceName { get; set; } = string.Empty;
        public string DistrictName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
    public class AddressInput
    {
        public int ID { get; set; } = 0;      
    }
    public class Address_SearchInput
    {
        public string TextSearch { get; set; } = string.Empty;
    }
    public class AddressInsert
    {
        [Required(ErrorMessage = "Hãy nhập quận,huyện")]
        public string AddressName { get; set; } = string.Empty;
        public int ParentID { get; set; } = 0;
    }
    public class SupplierInput
    {
        [Required(ErrorMessage = "Hãy điền nhà cung cấp")]
        public string SupplierName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Hãy điền địa chỉ")]
        public string AddressName { get; set; } = string.Empty;
        //[Range(1, int.MaxValue, ErrorMessage = "Hãy chọn thành phố")]
        public int ProvinceCode { get; set; } = 0;
        //[Range(1, int.MaxValue, ErrorMessage = "Hãy chọn quận,huyện")]
        public int DistrictCode { get; set; } = 0;
        public int ID { get; set; } = 0;
    }
}
