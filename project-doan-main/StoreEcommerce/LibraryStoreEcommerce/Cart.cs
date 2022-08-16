using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStoreEcommerce
{
    public class Cart
    {
        public string Account { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public int Number { get; set; } = 0;
        public int Properties { get; set; } = 0;
        public string Size { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }
    public class InputAccount
    {
        public string Account { get; set; } = string.Empty;
    }
    public class CartInput
    {
        public int ProvinceCode { get; set; } = 0;
        public int DistrictCode { get; set; } = 0;
        public string Account { get; set; } = string.Empty;
    }
}
