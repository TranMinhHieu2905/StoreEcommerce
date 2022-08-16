using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStoreEcommerce
{
    public class Ship
    {

    }
    public class ShipInput
    {
        public int ProvinceCode { get; set; } = 0;
        public int DistrictCode { get; set; } = 0;
        public int ProductShip { get; set; } = 0;
    }
    public class ShipOutput
    {
        public int PriceShip { get; set; } = 0;
    }
    public class TypeProductInsert
    {
        public int ID { get; set; } = 0;
        [Required(ErrorMessage = "Hãy điền loại vận chuyển")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Hãy điền mô tả nội dung")]
        public string Description { get; set; } = string.Empty; 
    }
    public class TypeProductDelete
    {
        public int ID { get; set; } = 0;
    }
}
