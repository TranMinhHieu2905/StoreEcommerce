using LibraryStoreEcommerce;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static StoreEcommerceaApi.Database.DbSQLUtils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreEcommerceaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // GET: api/<CategoryController>
        [HttpPost("GetList")]
        public IActionResult GetList([FromBody] SearchInput input)
        {
            List<Category> categories = new List<Category>();
            Parameter parameters = new Parameter() { parameter = "@TextSearch", length = 0, type = "nvarchar", value = input.TextSearch };
            DAStoreEcommerce.Category.GetList(parameters,out DataTable ds);
            int i =0;
            foreach (DataRow row in ds.Rows)
            {

                Category category = new Category();
                category.STT = i+1;
                i++;
                category.ID = (int)row["ID"];
                category.ObjectGuid = (Guid)row["ObjectGuid"];
                category.NameCategory= (string)row["NameCategory"];
                category.PictureLink= (string)row["PictureLink"];
                category.IsActive = (int)row["IsActive"];
                category.Description=(string)row["Description"];
                categories.Add(category);
            }
            return Ok(categories);
        }
        //[HttpPost("GetListProductbyID")]
        //public IActionResult GetDetail([FromBody] ProductDetail product)
        //{
        //    int Total = 0;
        //    List<Product> Products = new List<Product>();
        //    List<Parameter> parameters = new List<Parameter>();
        //    parameters.Add(new Parameter { parameter = "@ID", length = 0, type = "int", value = product.ID });
        //    parameters.Add(new Parameter { parameter = "@Screen", length = 0, type = "nvarchar", value = product.Screen });
        //    parameters.Add(new Parameter { parameter = "@MoneyDown", length = 0, type = "bigint", value = product.MoneyDown });
        //    parameters.Add(new Parameter { parameter = "@MoneyUp", length = 0, type = "bigint", value = product.MoneyUp });
        //    DAStoreEcommerce.Category.GetListProductByID(parameters, out DataTable ds);
        //    Total = ds.Rows.Count;
        //    foreach (DataRow row in ds.Rows)
        //    {
        //        Product product_output = new Product();
        //        product_output.ID = (int)row["ID"];
        //        product_output.Code = row["Code"] == DBNull.Value ? "" : (string)row["Code"];
        //        product_output.NameProduct = row["NameProduct"] == DBNull.Value ? "" : (string)row["NameProduct"];
        //        product_output.Descriptions = row["Descriptions"] == DBNull.Value ? "" : (string)row["Descriptions"];
        //        product_output.Likes = row["Likes"] == DBNull.Value ? 0 : (int)row["Likes"];
        //        product_output.Tax = row["Tax"] == DBNull.Value ? 0 : (int)row["Tax"];
        //        product_output.Number = row["Number"] == DBNull.Value ? 0 : (int)row["Number"];
        //        product_output.Price = row["Price"] == DBNull.Value ? "" : (string)row["Price"];
        //        product_output.TotalSearch = Total;
        //        Products.Add(product_output);
        //    }           
        //    return Ok(Products);
        //}
        [HttpPost("Delete")]
        public IActionResult Delete([FromBody] ObjectGuidID objectGuidID)
        {          Category category = new Category();
            Parameter parameters = new Parameter() { parameter = "@ObjectGuid", length = 0, type = "uniqueidentifier", value = objectGuidID.ObjectGuid };
            DAStoreEcommerce.Category.GetOne(parameters, out DataTable ds);
            foreach (DataRow row in ds.Rows)
            {
                category.ID = (int)row["ID"];
            }
            if(category.ID <1)
            {
                return BadRequest("Lỗi");
            }
            Parameter param = new Parameter() { parameter = "@ID", length = 0, type = "int", value = category.ID };
            DAStoreEcommerce.Category.Delete(param);
            return Ok();
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Category category)
        {
            // Category category = new Category();

            Parameter parameter = new Parameter() { parameter = "@ObjectGuid", length = 0, type = "uniqueidentifier", value = category.ObjectGuid };
            DAStoreEcommerce.Category.GetOne(parameter, out DataTable ds);
            foreach (DataRow row in ds.Rows)
            {
                category.ID = (int)row["ID"];
            }
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@ID", length = 0, type = "int", value = category.ID });
            parameters.Add(new Parameter { parameter = "@NameCategory", length = 0, type = "nvarchar", value = category.NameCategory });
            parameters.Add(new Parameter { parameter = "@Description", length = 0, type = "nvarchar", value = category.Description });
            parameters.Add(new Parameter { parameter = "@PictureLink", length = 0, type = "nvarchar", value = category.PictureLink });
            DAStoreEcommerce.Category.Update(parameters);
            return Ok();

        }
        [HttpPost("GetListProductbyID")]
        public IActionResult GetDetail([FromBody] ProductDetail product)
        {
            int Total = 0;
            List<Product> Products = new List<Product>();
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@ID", length = 0, type = "int", value = product.ID });
            parameters.Add(new Parameter { parameter = "@Screen", length = 0, type = "nvarchar", value = product.Screen });
            parameters.Add(new Parameter { parameter = "@MoneyDown", length = 0, type = "bigint", value = product.MoneyDown });
            parameters.Add(new Parameter { parameter = "@MoneyUp", length = 0, type = "bigint", value = product.MoneyUp });
            DAStoreEcommerce.Category.GetListProductByID(parameters, out DataTable ds);
            Total = ds.Rows.Count;
            int i = 0;
            foreach (DataRow row in ds.Rows)
            {
                Product product_output = new Product();
                product_output.STT = i + 1;
                i++;
                product_output.ID = (int)row["ID"];
                product_output.Code = row["Code"] == DBNull.Value ? "" : (string)row["Code"];
                product_output.PictureLink = row["PictureLink"] == DBNull.Value ? "" : (string)row["PictureLink"];
                product_output.NameProduct = row["NameProduct"] == DBNull.Value ? "" : (string)row["NameProduct"];
                product_output.Descriptions = row["Descriptions"] == DBNull.Value ? "" : (string)row["Descriptions"];
                product_output.Likes = row["Likes"] == DBNull.Value ? 0 : (int)row["Likes"];
                product_output.Tax = row["Tax"] == DBNull.Value ? 0 : (int)row["Tax"];
                product_output.Number = row["Number"] == DBNull.Value ? 0 : (int)row["Number"];
                product_output.Price = row["Price"] == DBNull.Value ? "" : (string)row["Price"];
                product_output.TotalSearch = Total;
                Products.Add(product_output);
            }
            return Ok(Products);
        }

        [HttpPost("GetListProductbyCategoryID")]
        public IActionResult GetListProductbyCategoryID([FromBody] ProductAdminInput product)
        {
            int Total = 0;
            List<Product> Products = new List<Product>();
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@ID", length = 0, type = "int", value = product.ID });
            parameters.Add(new Parameter { parameter = "@TextSearch", length = 0, type = "nvarchar", value = product.TextSearch});
            DAStoreEcommerce.Category.GetListProductByCategoryID(parameters, out DataTable ds);
            Total = ds.Rows.Count;
            int i = 0;
            foreach (DataRow row in ds.Rows)
            {
                Product product_output = new Product();
                product_output.STT = i + 1;
                i++;
                product_output.ID = (int)row["ID"];
                product_output.Code = row["Code"] == DBNull.Value ? "" : (string)row["Code"];
                product_output.PictureLink = row["PictureLink"] == DBNull.Value ? "" : (string)row["PictureLink"];
                product_output.NameProduct = row["NameProduct"] == DBNull.Value ? "" : (string)row["NameProduct"];
                product_output.Descriptions = row["Descriptions"] == DBNull.Value ? "" : (string)row["Descriptions"];
                product_output.Likes = row["Likes"] == DBNull.Value ? 0 : (int)row["Likes"];
                product_output.Tax = row["Tax"] == DBNull.Value ? 0 : (int)row["Tax"];
                product_output.Number = row["Number"] == DBNull.Value ? 0 : (int)row["Number"];
                product_output.Price = row["Price"] == DBNull.Value ? "" : (string)row["Price"];
                product_output.TotalSearch = Total;
                Products.Add(product_output);
            }
            return Ok(Products);
        }
        [HttpPost("GetCategorybyID")]
        public IActionResult GetCategorybyID([FromBody] CategoryInput categoryinput)
        {
            Parameter parameter = new Parameter() { parameter = "@ID", length = 0, type = "int", value = categoryinput.ID };
            DAStoreEcommerce.Category.GetCategorybyID(parameter , out DataTable ds);
            Category category = new Category();
            foreach (DataRow row in ds.Rows)
            {
                category.ObjectGuid = (Guid)row["ObjectGuid"];
                category.PictureLink = (string)row["PictureLink"];
                category.NameCategory = (string)row["NameCategory"];
                category.Description = (string)row["Description"];
            }           
            return Ok(category);
        }
        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] Category category)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@NameCategory", length = 0, type = "nvarchar", value = category.NameCategory });
            parameters.Add(new Parameter { parameter = "@Description", length = 0, type = "nvarchar", value = category.Description });
            parameters.Add(new Parameter { parameter = "@PictureLink", length = 0, type = "nvarchar", value = category.PictureLink });
            parameters.Add(new Parameter { parameter = "@IsActive", length = 0, type = "nvarchar", value = category.IsActive });
            DAStoreEcommerce.Category.Insert(parameters);
            return Ok();
        }
        [HttpGet("GetCategoryID")]
        public IActionResult GetCategoryID()
        {
            Category category = new Category();
            DAStoreEcommerce.Category.GetCategoryID(out DataTable ds);
            foreach (DataRow row in ds.Rows)
            {
                category.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
            }
            return Ok(category);
        }

    }

}
