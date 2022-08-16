using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStoreEcommerce
{
    public class Product
    {
        public int ID_Cart { get; set; } = 0;
        public int STT { get; set; } = 0;
        [Range(1, int.MaxValue, ErrorMessage = "Hãy chọn danh mục sản phẩm")]
        public int ID { get; set; } = 0;
        [Required(ErrorMessage = "Hãy nhập mã code")]
        public string Code { get; set; } = string.Empty;
        [Required(ErrorMessage = "Hãy nhập tên sản phẩm")]
        public string NameProduct { get; set; } = string.Empty;
        public int Active { get; set; } = 0;
        public int Brand { get; set; } = 0;
        [Range(1, int.MaxValue, ErrorMessage = "Hãy chọn nhà cung cấp")]
        public int Supplier { get; set; } = 0;
        [Required(ErrorMessage = "Hãy nhập mô tả sản phẩm")]
        public string Descriptions { get; set; } = string.Empty;
        public int Tax { get; set; } = 0;
        public int Activetax { get; set; } = 0;
        public int Enablebuy { get; set; } = 0;
        [Required(ErrorMessage = "Hãy nhập số lượng")]
        public int Number { get; set; } = 0;
        public string Price { get; set; } = string.Empty;
        public string Properties { get; set; } = string.Empty;
        public int Property { get; set; } = 0;
        public int Views { get; set; } = 0;
        public int Likes { get; set; } = 0;
        public int Productship { get; set; } = 0;
        public string PictureLink { get; set; } = string.Empty;
        public int IsActive { get; set; } = 0;
        public int TotalSearch { get; set; } = 0;
        public int TongCong { get; set; } = 0;
        [Required(ErrorMessage = "Hãy nhập giá")]
        public int PriceProduct { get; set; } = 0;
        [Required(ErrorMessage = "Hãy chọn màu sắc")]
        public string Value { get; set; } = string.Empty;
        public int Total { get; set; } = 0;
        public string classCheck { get; set; } = "uncheck";
        [Range(1, int.MaxValue, ErrorMessage = "Hãy chọn thuộc tính sản phẩm")]
        public int Type { get; set; } = 0;
        public int PriceShip { get; set; } = 0;
        [Required(ErrorMessage = "Hãy chọn size")]
        public string Size { get; set; } = string.Empty;
        public string NameSupplier { get; set; } = string.Empty;
        public int Displayorder { get; set; } = 0;
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime EndTime { get; set; } = DateTime.Now;
    }
    public class ProductAddInput
    {
        public int CategoryID { get; set; } = 0;
        public int ID { get; set; } = 0;
        public string Code { get; set; } = string.Empty;
        public string NameProduct { get; set; } = string.Empty;
        public string Descriptions { get; set; } = string.Empty;
        public int PriceProduct { get; set; } = 0;
        public int Type { get; set; } = 0;
        public int IsActive { get; set; } = 0;
        public int Tax { get; set; } = 0;
        public string PictureLink { get; set; } = string.Empty;
        public int Property { get; set; } = 0;
        public string Value { get; set; } = string.Empty;
        public int Number { get; set; } = 0;
        public string Size { get; set; } = string.Empty;
        public int Supplier { get; set; } = 0;
    }
    public class Product_SearchInput
    {
        public string TextSearch { get; set; } = string.Empty;
        public int PageSize { get; set; } = 10;
        public int CurrentPage { get; set; } = 1;
        public int Screen { get; set; } = 0;     
    }
    public class ProductDetail
    {
        public int ID { get; set; } = 0;
        public int Screen { get; set; } = 0;
        public double @MoneyDown { get; set; } = 0;
        public double @MoneyUp { get; set; } = 0;
    }
    public class ProductAdminInput
    {
        public int ID { get; set; } = 0;
        public string TextSearch { get; set; } = string.Empty;
    }
    public class GetImg
    {
        public string Code { get; set; } = string.Empty;
    }
    public class ProductInput
    {
        public int ID { get; set; } = 0;
    }
    public class GetNumberInput
    {
        public string Code { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
    public class GetSize
    {
        public string Size { get; set; } = string.Empty;
        public int Property { get; set; } = 0;
        public string classCheck { get; set; } = "uncheck";
    }
    public class ProductOuputDetail
    {
        public int STT { get; set; } = 0;
        public int ID { get; set; } = 0;
        public string Code { get; set; } = string.Empty;
        public string NameProduct { get; set; } = string.Empty;
        public int Number { get; set; } = 0;
        public string Price { get; set; } = string.Empty;
        public string Properties { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public int PriceProduct { get; set; } = 0;
    }
    public class SaleProductInput
    {
        public string Code { get; set; } = string.Empty;
        public int Price { get; set; } = 0;
        public int Percent { get; set; } = 0;
        public int TypePrice { get; set; } = 0;
        public DateTime EndTime { get; set; } = DateTime.Now;
    }
    public class TypeProduct
    {
        public string TextSearch { get; set; } = string.Empty;
    }
    public class ProductLike
    {
        public string Account { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public int Screen { get; set; } = 0;
    }
    public class ProductCheckLike
    {
        public int Count { get; set; } = 0;
    }
}
