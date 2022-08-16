using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStoreEcommerce
{
    public class SystemKey
    {
        public int STT { get; set; } = 0;
        public int ID { get; set; } = 0;
        public string NameType { get; set; } = string.Empty;
        public string Descriptions { get; set; } = string.Empty;
        public bool Edit { get; set; } = false;

    }
    public class SystemKeyTax
    {
        public int ID { get; set; } = 0;
        public string NameTax { get; set; } = string.Empty;
        public string Descriptions { get; set; } = string.Empty;

    }
    public class SystemKeySupplier
    {
        public int STT { get; set; } = 0;
        public int ID { get; set; } = 0;
        public string NameSupplier { get; set; } = string.Empty;

    }
    public class Supplier
    {
        public int STT { get; set; } = 0;
        public int ID { get; set; } = 0;
        public string Address { get; set; } = string.Empty;
        public string NameSupplier { get; set; } = string.Empty;
        public string ProvinceName { get; set; } = string.Empty;
        public string DistrictName { get; set; } = string.Empty;
        public int ProvinceCode { get; set; } = 0;
        public int DistrictCode { get; set; } = 0;

        public bool Edit { get; set; } = false;
    }
    public class SystemKeyProperties
    {
        public int ID { get; set; } = 0;
        public string Name { get; set; } = string.Empty;

    }
    public class DefaultValue
    {
        public int ID { get; set; } = 0;
    }
    public class DefaultOuput
    {
        public int ID { get; set; } = 0;
        public string Value { get; set; } = string.Empty;

    }
}