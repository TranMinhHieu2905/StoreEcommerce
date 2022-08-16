using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStoreEcommerce
{
	public class ImageFile
	{
		public string base64data { get; set; }
		public string contentType { get; set; }
		public string fileName { get; set; }
		public string NameCategory { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string PictureLink { get; set; } = string.Empty;
	}
}
