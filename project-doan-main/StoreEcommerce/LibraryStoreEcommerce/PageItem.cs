using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStoreEcommerce
{
    public class PageItem
    {
        public string Text { get; set; } = String.Empty;
        public int PageIndex { get; set; } = 0;
        public bool Enabled { get; set; } = false;
        public bool Active { get; set; } = false;

        public PageItem(int pageIndex, bool enabled, string text)
        {
            this.PageIndex = pageIndex;
            this.Enabled = enabled;
            this.Text = text;
        }
    }
}
