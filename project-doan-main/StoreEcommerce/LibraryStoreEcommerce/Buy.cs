using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStoreEcommerce
{
    public class Buy
    {
        public int ID { get; set; } = 0;
        public string UserName { get; set; }= string.Empty;
        public DateTime Date { get; set; }= DateTime.Now;
        public int PriceShip { get; set; } = 0;
        public string Address { get; set; } = string.Empty;
        public int ProvinceCode { get; set; } = 0;
        public int DistrictCode { get; set; } = 0;
        public int PayType { get; set; } = 0;
        public string Code { get; set; } = string.Empty;
        public int Propeties { get; set; } = 0;
        public int Number { get; set; } = 0;
        public string Value { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
    }
    public class BuyInput {
        public string Code { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public int Propeties { get; set; } = 0;

    }
    public class UserOrderProduct
    {
        public string UserName { get; set; } = string.Empty;
    }
    public class BuyOutput
    {
        public int ID { get; set; } = 0;
        public int STT { get; set; } = 0;
        public string Code { get; set; } = string.Empty;
        public string NameProduct { get; set; } = string.Empty;
        public string Descriptions { get; set; } = string.Empty;
        public int Number { get; set; } = 0;
        public int Price { get; set; } = 0;
        public string Value { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public int ProvinceCode { get; set; } = 0;
        public int DistrictCode { get; set; } = 0;
        public string Address { get; set; } = string.Empty;
        public string ProvinceName { get; set; } = string.Empty;
        public string DistrictName { get; set; } = string.Empty;
        public string PictureLink { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public string Pay { get; set; } = string.Empty;

    }
    public class CartDelete
    {
        public int ID { get; set; } = 0;
    }    
}
