using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStoreEcommerce
{
    public class Tax
    {
        public int STT { get; set; } = 0;
        public int ID { get; set; } = 0;
        public Guid ObjectguidID { get; set; } = Guid.Empty;
        public string NameTax { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty; 
        public int Value { get; set; } = 0;
    }

    public class Tax_SearchInput
    {
        public string TextSearch { get; set; } = string.Empty;
    }
    public class TaxDetail
    {
        public int ID { get; set; } = 0;
    }
    public class TaxInput
    {
        public int ID { get; set; } = 0;
    }
    public class TaxOuputDetail
    {
        public int STT { get; set; } = 0;
        public int ID { get; set; } = 0;
        public string NameTax { get; set; } = string.Empty;
        public int Value { get; set; } = 0;

    }
}
