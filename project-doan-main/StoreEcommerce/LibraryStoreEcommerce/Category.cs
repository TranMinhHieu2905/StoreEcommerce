using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStoreEcommerce
{
    public class Category
    {
        public int STT { get; set; } = 0;
        public int ID { get; set; } = 0;
        public Guid ObjectGuid { get; set; } = Guid.Empty;
        [Required(ErrorMessage = "Hãy nhập tên danh mục")]
        public string NameCategory { get; set; } = string.Empty;
        [Required(ErrorMessage = "Hãy nhập nội dung")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Hãy chọn ảnh cho danh mục vừa chọn")]
        public string PictureLink { get; set; } = string.Empty;
        public int IsActive { get; set; } = 0;

    }
    public class SearchInput
    {
        public string TextSearch { get; set; } = string.Empty;
    }
    public class CategoryInput
    {
        public int ID { get; set; } = 0;
    }
   // public class EmployeeDataService
   // {
   //     public string IEmployeeDataService { get; set; } = "successful delete";
   //}

}
