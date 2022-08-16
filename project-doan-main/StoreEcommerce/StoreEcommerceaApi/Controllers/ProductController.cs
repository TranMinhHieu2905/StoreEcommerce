using LibraryStoreEcommerce;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static StoreEcommerceaApi.Database.DbSQLUtils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreEcommerceaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost("GetList")]
        public IActionResult Get([FromBody] Product_SearchInput searchInput)
        {
            int Total = 0;
            List<Product> Products = new List<Product>();
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@TextSearch", length = 0, type = "nvarchar", value = searchInput.TextSearch });
            parameters.Add(new Parameter { parameter = "@Screen", length = 0, type = "int", value = searchInput.Screen });
            searchInput.PageSize = searchInput.PageSize == 0 ? 6 : searchInput.PageSize;
            searchInput.CurrentPage = searchInput.CurrentPage == 0 ? 1 : searchInput.CurrentPage;
            DAStoreEcommerce.Product.GetList(parameters, out DataTable ds);
            Total = ds.Rows.Count;
            int i = 0;
            foreach (DataRow row in ds.Rows)
            {
                Product product_output = new Product();
                product_output.STT = i + 1;
                i++;
                product_output.Likes = row["Likes"] == DBNull.Value ? 0 : (int)row["Likes"];
                product_output.Code = row["Code"] == DBNull.Value ? "" : (string)row["Code"];
                product_output.NameProduct = row["NameProduct"] == DBNull.Value ? "" : (string)row["NameProduct"];
                product_output.PictureLink = row["PictureLink"] == DBNull.Value ? "" : (string)row["PictureLink"];
                product_output.Descriptions = row["Descriptions"] == DBNull.Value ? "" : (string)row["Descriptions"];
                product_output.Tax = row["Tax"] == DBNull.Value ? 0 : (int)row["Tax"];
                product_output.Number = row["Number"] == DBNull.Value ? 0 : (int)row["Number"];
                product_output.Price = row["Price"] == DBNull.Value ? "" : (string)row["Price"];
                product_output.TotalSearch = Total;
                Products.Add(product_output);
            }
            return Ok(Products);
        }
        [HttpPost("GetImage")]
        public IActionResult GetImage([FromBody] GetImg getImg)
        {
            Parameter parameters = new Parameter() { parameter = "@Code", length = 0, type = "nvarchar", value = getImg.Code };
            DAStoreEcommerce.Product.GetImage(parameters, out DataTable ds);
            Product product_output = new Product();
            foreach (DataRow row in ds.Rows)
            {
                product_output.PictureLink = row["PictureLink"] == DBNull.Value ? "" : (string)row["PictureLink"];
                product_output.NameProduct = row["NameProduct"] == DBNull.Value ? "" : (string)row["NameProduct"];
                product_output.Likes = row["Likes"] == DBNull.Value ? 0 : (int)row["Likes"];
                product_output.Price = row["Price"] == DBNull.Value ? "" : (string)row["Price"];
                product_output.Descriptions = row["Descriptions"] == DBNull.Value ? "" : (string)row["Descriptions"];
                product_output.Number = row["Number"] == DBNull.Value ? 0 : (int)row["Number"];
            }
            return Ok(product_output);                  
        }
        //[HttpPost("Insert")]
        //public IActionResult Insert([FromBody] Product product)
        //{
        //    List<Parameter> parameters = new List<Parameter>();
        //    parameters.Add(new Parameter { parameter = "@ID", length = 0, type = "int", value = product.ID });
        //    parameters.Add(new Parameter { parameter = "@Tax", length = 0, type = "int", value = product.Tax });
        //    parameters.Add(new Parameter { parameter = "@Code", length = 0, type = "varchar", value = product.Code });
        //    parameters.Add(new Parameter { parameter = "@PictureLink", length = 0, type = "varchar", value = product.PictureLink });
        //    parameters.Add(new Parameter { parameter = "@NameProduct", length = 0, type = "nvarchar", value = product.NameProduct });
        //    parameters.Add(new Parameter { parameter = "@Supplier", length = 0, type = "int", value = product.Supplier });
        //    parameters.Add(new Parameter { parameter = "@Descriptions", length = 0, type = "nvarchar", value = product.Descriptions });
        //    parameters.Add(new Parameter { parameter = "@Number", length = 0, type = "int", value = product.Number });
        //    parameters.Add(new Parameter { parameter = "@PriceProduct", length = 0, type = "int", value = product.PriceProduct });
        //    parameters.Add(new Parameter { parameter = "@Property", length = 0, type = "int", value = product.Property });
        //    parameters.Add(new Parameter { parameter = "@Type", length = 0, type = "int", value = product.Type });
        //    DAStoreEcommerce.Product.Insert(parameters);
        //    return Ok(); 
        //}
        [HttpPost("InsertNew")]
        public IActionResult InsertNew([FromBody] ProductAddInput productinput)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@ID", length = 0, type = "int", value = productinput.ID});
            parameters.Add(new Parameter { parameter = "@NameProduct", length = 0, type = "nvarchar", value = productinput.NameProduct });
            parameters.Add(new Parameter { parameter = "@Tax", length = 0, type = "int", value = productinput.Tax });
            parameters.Add(new Parameter { parameter = "@Code", length = 0, type = "varchar", value = productinput.Code });
            parameters.Add(new Parameter { parameter = "@IsActive", length = 0, type = "int", value = productinput.IsActive });
            parameters.Add(new Parameter { parameter = "@Descriptions", length = 0, type = "nvarchar", value = productinput.Descriptions });
            parameters.Add(new Parameter { parameter = "@PriceProduct", length = 0, type = "int", value = productinput.PriceProduct });
            parameters.Add(new Parameter { parameter = "@Type", length = 0, type = "int", value = productinput.Type });
            parameters.Add(new Parameter { parameter = "@Supplier", length = 0, type = "int", value = productinput.Supplier });
            DAStoreEcommerce.Product.InsertNew(parameters);
            return Ok();
        }
        [HttpPost("InsertIMG")]
        public IActionResult InsertIMG([FromBody] ProductAddInput productinput)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@PictureLink", length = 0, type = "nvarchar", value = productinput.PictureLink });
            parameters.Add(new Parameter { parameter = "@Code", length = 0, type = "varchar", value = productinput.Code });
            DAStoreEcommerce.Product.InsertIMG(parameters);
            return Ok();
        }
        [HttpPost("InsertColor")]
        public IActionResult InsertColor([FromBody] ProductAddInput productinput)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@Property", length = 0, type = "int", value = productinput.Property });
            parameters.Add(new Parameter { parameter = "@Value", length = 0, type = "nvarchar", value = productinput.Value });
            parameters.Add(new Parameter { parameter = "@Code", length = 0, type = "nvarchar", value = productinput.Code });
            parameters.Add(new Parameter { parameter = "@Number", length = 0, type = "int", value = productinput.Number });
            DAStoreEcommerce.Product.InsertColor(parameters);
            return Ok();
        }
        [HttpPost("InsertProperties")]
        public IActionResult InsertProperties([FromBody] ProductAddInput productinput)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@Property", length = 0, type = "int", value = productinput.Property });
            parameters.Add(new Parameter { parameter = "@Value", length = 0, type = "nvarchar", value = productinput.Size });
            parameters.Add(new Parameter { parameter = "@Code", length = 0, type = "nvarchar", value = productinput.Code });
            DAStoreEcommerce.Product.InsertProperties(parameters);
            return Ok();
        }
        [HttpPost("GetListAdmin")]
        public IActionResult GetListAdmin([FromBody] Product_SearchInput searchInput)
        {
            int Total = 0;
            List<Product> Products = new List<Product>();
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@TextSearch", length = 0, type = "nvarchar", value = searchInput.TextSearch });
            parameters.Add(new Parameter { parameter = "@Screen", length = 0, type = "int", value = searchInput.Screen });
            searchInput.PageSize = searchInput.PageSize == 0 ? 6 : searchInput.PageSize;
            searchInput.CurrentPage = searchInput.CurrentPage == 0 ? 1 : searchInput.CurrentPage;
            DAStoreEcommerce.Product.GetListAdmin(parameters, out DataTable ds);
            Total = ds.Rows.Count;
            int i = 0;
            foreach (DataRow row in ds.Rows)
            {
                Product product_output = new Product();
                product_output.STT = i + 1;
                i++;
                product_output.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
                product_output.Likes = row["Likes"] == DBNull.Value ? 0 : (int)row["Likes"];
                product_output.Code = row["Code"] == DBNull.Value ? "" : (string)row["Code"];
                product_output.NameProduct = row["NameProduct"] == DBNull.Value ? "" : (string)row["NameProduct"];
                product_output.PictureLink = row["PictureLink"] == DBNull.Value ? "" : (string)row["PictureLink"];
                product_output.Descriptions = row["Descriptions"] == DBNull.Value ? "" : (string)row["Descriptions"];
                product_output.Number = row["Number"] == DBNull.Value ? 0 : (int)row["Number"];
                product_output.Price = row["Price"] == DBNull.Value ? "" : (string)row["Price"];
                product_output.TotalSearch = Total;
                Products.Add(product_output);
            }
            return Ok(Products);
        }
        [HttpPost("GetListAdminDetail")]
        public IActionResult GetListAdminDetail([FromBody] GetImg Getdetail)
        {
            List<ProductOuputDetail> Products = new List<ProductOuputDetail>();
            Parameter parameters = new Parameter() { parameter = "@Code", length = 0, type = "nvarchar", value = Getdetail.Code };
            DAStoreEcommerce.Product.GetListDetail(parameters, out DataTable ds);
            int i = 0;
            foreach (DataRow row in ds.Rows)
            {
                ProductOuputDetail product_output = new ProductOuputDetail();
                product_output.STT = i + 1;
                i++;
                product_output.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
                product_output.Code = row["Code"] == DBNull.Value ? "" : (string)row["Code"];
                product_output.Properties = row["Name"] == DBNull.Value ? "" : (string)row["Name"];
                product_output.Value = row["Value"] == DBNull.Value ? "" : (string)row["Value"];
                product_output.NameProduct = row["NameProduct"] == DBNull.Value ? "" : (string)row["NameProduct"];              
                product_output.Number = row["Number"] == DBNull.Value ? 0 : (int)row["Number"];
                product_output.Price = row["Price"] == DBNull.Value ? "" : (string)row["Price"];
                Products.Add(product_output);
            }
            return Ok(Products);
        }
        [HttpPost("GetDetailProductbyCode")]
        public IActionResult GetDetailProduct([FromBody] GetImg getImg)
        {
            Parameter parameters = new Parameter() { parameter = "@Code", length = 0, type = "nvarchar", value = getImg.Code };
            DAStoreEcommerce.Product.GetDetailProductbyCode(parameters, out DataTable ds);
            Product product_output = new Product();
            foreach (DataRow row in ds.Rows)
            {
                product_output.NameProduct = row["NameProduct"] == DBNull.Value ? "" : (string)row["NameProduct"];
                product_output.Likes = row["Likes"] == DBNull.Value ? 0 : (int)row["Likes"];
                product_output.Price = row["Price"] == DBNull.Value ? "" : (string)row["Price"];
                product_output.Descriptions = row["Descriptions"] == DBNull.Value ? "" : (string)row["Descriptions"];
                product_output.Number = row["Number"] == DBNull.Value ? 0 : (int)row["Number"];
            }
            return Ok(product_output);
        }
        [HttpPost("GetListImage")]
        public IActionResult GetListImage([FromBody] GetImg getImg)
        {
            Parameter parameters = new Parameter() { parameter = "@Code", length = 0, type = "nvarchar", value = getImg.Code };
            DAStoreEcommerce.Product.GetListImage(parameters, out DataTable ds);
            List<Product> products = new List<Product>();
            int STT = 0;
            foreach (DataRow row in ds.Rows)
            {
                Product product_output = new Product();
                product_output.STT = STT + 1;
                STT++;
                product_output.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
                product_output.Displayorder = row["Displayorder"] == DBNull.Value ? 0 : (int)row["Displayorder"];
                product_output.PictureLink = row["PictureLink"] == DBNull.Value ? "" : (string)row["PictureLink"];
                products.Add(product_output);
            }
            return Ok(products);
        }
        [HttpPost("GetColor")]
        public IActionResult GetColor([FromBody] GetImg getImg)
        {
            Parameter parameters = new Parameter() { parameter = "@Code", length = 0, type = "nvarchar", value = getImg.Code };
            DAStoreEcommerce.Product.GetListColor(parameters, out DataTable ds);
            List<Product> products = new List<Product>();
            int i = 0;
            foreach (DataRow row in ds.Rows)
            {
                Product product_output = new Product();
                product_output.STT = i + 1;
                i++;
                product_output.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
                product_output.Value = row["Value"] == DBNull.Value ? "" : (string)row["Value"];
                products.Add(product_output);
            }
            return Ok(products);
        }
        [HttpPost("GetNumber")]
        public IActionResult GetNumber([FromBody] GetNumberInput getNumberInput)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@Code", length = 0, type = "nvarchar", value = getNumberInput.Code });
            parameters.Add(new Parameter { parameter = "@Value", length = 0, type = "nvarchar", value = getNumberInput.Value });
            DAStoreEcommerce.Product.GetNumber(parameters, out DataTable ds);
            Product product_output = new Product();
            foreach (DataRow row in ds.Rows)
            {
                product_output.Number = row["Number"] == DBNull.Value ? 0 : (int)row["Number"];
                product_output.Property = row["Properties"] == DBNull.Value ? 0 : (int)row["Properties"];
            }
            return Ok(product_output);
        }
        [HttpPost("GetSize")]
        public IActionResult GetSize([FromBody] GetImg getsize)
        {
            Parameter parameters = new Parameter() { parameter = "@Code", length = 0, type = "nvarchar", value = getsize.Code };
            DAStoreEcommerce.Product.GetSize(parameters, out DataTable ds);
            List<GetSize> sizesoutput = new List<GetSize>();
            foreach (DataRow row in ds.Rows)
            {
                GetSize sizeoutput = new GetSize();
                sizeoutput.Size = row["Size"] == DBNull.Value ? "" : (string)row["Size"];
                sizeoutput.Property = row["Properties"] == DBNull.Value ? 0 : (int)row["Properties"];
                sizesoutput.Add(sizeoutput);
            }
            return Ok(sizesoutput);
        }
        [HttpPost("GetPrice")]
        public IActionResult GetPrice([FromBody] GetNumberInput getNumberInput)
        {
            Parameter parameters = new Parameter() { parameter = "@Code", length = 0, type = "nvarchar", value = getNumberInput.Code };
            DAStoreEcommerce.Product.GetPrice(parameters, out DataTable ds);
            Product product_output = new Product();
            foreach (DataRow row in ds.Rows)
            {
                product_output.PriceProduct = row["Price"] == DBNull.Value ? 0 : (int)row["Price"];
                product_output.Productship = row["Productship"] == DBNull.Value ? 0 : (int)row["Productship"];
            }
            return Ok(product_output);
        }

        [HttpPost("Delete")]
        public IActionResult DeleteProduct([FromBody] ProductInput product)
        {
            Parameter param = new Parameter() { parameter = "@ID", length = 0, type = "int", value = product.ID };
            DAStoreEcommerce.Product.Delete(param);
            return Ok();
        }
        [HttpPost("DeleteImage")]
        public IActionResult DeleteImage([FromBody] ProductInput product)
        {
            Parameter param = new Parameter() { parameter = "@ID", length = 0, type = "int", value = product.ID };
            DAStoreEcommerce.Product.DeleteImage(param);
            return Ok();
        }
        [HttpPost("DeleteProperties")]
        public IActionResult DeleteProperties([FromBody] ProductInput product)
        {
            Parameter param = new Parameter() { parameter = "@ID", length = 0, type = "int", value = product.ID };
            DAStoreEcommerce.Product.DeleteProperties(param);
            return Ok();
        }
        [HttpPost("GetOne")]
        public IActionResult GetOne([FromBody] GetImg Getdetail)
        {
            Product product_output = new Product();
            Parameter parameters = new Parameter() { parameter = "@Code", length = 0, type = "nvarchar", value = Getdetail.Code };
            DAStoreEcommerce.Product.GetOne(parameters, out DataTable ds);
            int i = 0;
            foreach (DataRow row in ds.Rows)
            {
                
                product_output.STT = i + 1;
                i++;              
                product_output.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
                product_output.IsActive = row["IsActive"] == DBNull.Value ? 0 : (int)row["IsActive"];
                product_output.Code = row["Code"] == DBNull.Value ? "" : (string)row["Code"];
                product_output.Productship = row["Productship"] == DBNull.Value ? 0 : (int)row["Productship"];
                product_output.NameProduct = row["NameProduct"] == DBNull.Value ? "" : (string)row["NameProduct"];
                product_output.Likes = row["Likes"] == DBNull.Value ? 0 : (int)row["Likes"];
                product_output.Supplier = row["Supplier"] == DBNull.Value ? 0 : (int)row["Supplier"];
                product_output.NameSupplier = row["NameSupplier"] == DBNull.Value ? "" : (string)row["NameSupplier"];
                product_output.Descriptions = row["Descriptions"] == DBNull.Value ? "" : (string)row["Descriptions"];
            }
            return Ok(product_output);
        }
        [HttpPost("ListPrice")]
        public IActionResult ListPrice([FromBody] GetImg Getdetail)
        {
            List<Product>  products = new List<Product>();
            Parameter parameter = new Parameter() { parameter = "@Code", length = 0, type = "nvarchar", value = Getdetail.Code };
            DAStoreEcommerce.Product.GetListPrice(parameter, out DataTable ds);
            int i = 0;
            foreach (DataRow row in ds.Rows)
            {
                Product product = new Product();
                product.STT = i + 1;
                i++;
                product.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
                product.PriceProduct = row["Price"] == DBNull.Value ? 0 : (int)row["Price"];
                product.CreateTime = row["CreateTime"] == DBNull.Value ? DateTime.Now : (DateTime)row["CreateTime"];
                product.EndTime = row["EndTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)row["EndTime"];
                products.Add(product);
            }
            return Ok(products);
        }
        [HttpPost("ProductUpdate")]
        public IActionResult ProductUpdate([FromBody] ProductAddInput productinput)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@NameProduct", length = 0, type = "nvarchar", value = productinput.NameProduct });
            parameters.Add(new Parameter { parameter = "@IsActive", length = 0, type = "int", value = productinput.IsActive });
            parameters.Add(new Parameter { parameter = "@CategoryID", length = 0, type = "int", value = productinput.CategoryID });
            parameters.Add(new Parameter { parameter = "@ID", length = 0, type = "int", value = productinput.ID });
            parameters.Add(new Parameter { parameter = "@Descriptions", length = 0, type = "nvarchar", value = productinput.Descriptions });
            parameters.Add(new Parameter { parameter = "@ProductShip", length = 0, type = "int", value = productinput.Type });
            parameters.Add(new Parameter { parameter = "@Supplier", length = 0, type = "int", value = productinput.Supplier });
            DAStoreEcommerce.Product.UpdateProduct(parameters);
            return Ok();
        }
        [HttpPost("Random")]
        public IActionResult Random([FromBody] GetImg Getdetail)
        {
            List<Product> Products = new List<Product>();
            Parameter parameters = new Parameter() { parameter = "@Code", length = 0, type = "nvarchar", value = Getdetail.Code };
            DAStoreEcommerce.Product.Random(parameters, out DataTable ds);
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
                Products.Add(product_output);
            }
            return Ok(Products);
        }
        [HttpPost("SalePrice")]
        public IActionResult SalePrice([FromBody] SaleProductInput  saleProductInput)
        {
            List<Product> Products = new List<Product>();
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@Code", length = 0, type = "nvarchar", value = saleProductInput.Code });
            parameters.Add(new Parameter { parameter = "@Price", length = 0, type = "int", value = saleProductInput.Price });
            parameters.Add(new Parameter { parameter = "@EndTime", length = 0, type = "datetime", value = saleProductInput.EndTime });
            parameters.Add(new Parameter { parameter = "@TypePrice", length = 0, type = "int", value = saleProductInput.TypePrice });
            DAStoreEcommerce.Product.SalePrice(parameters);         
            return Ok();
        }
        [HttpPost("LikeProduct")]
        public IActionResult LikeProduct([FromBody] ProductLike Getdetail)
        {
            List<Product> products = new List<Product>();
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@Code", length = 0, type = "nvarchar", value = Getdetail.Code });
            parameters.Add(new Parameter { parameter = "@Screen", length = 0, type = "int", value = Getdetail.Screen });
            DAStoreEcommerce.Product.LikeProduct(parameters);           
            return Ok();
        }
        [HttpPost("CheckLikeUser")]
        public IActionResult CheckLikeUser([FromBody] ProductLike Getdetail)
        {
            ProductCheckLike productCheck = new ProductCheckLike();
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@Code", length = 0, type = "nvarchar", value = Getdetail.Code });
            parameters.Add(new Parameter { parameter = "@Account", length = 0, type = "nvarchar", value = Getdetail.Account });
            DAStoreEcommerce.Product.CheckLike(parameters, out DataTable ds);
            foreach (DataRow row in ds.Rows)
            {
                productCheck.Count = row["Count"] == DBNull.Value ? 0 : (int)row["Count"];
            }
            return Ok(productCheck);
        }
        [HttpPost("InsertLike")]
        public IActionResult InsertLike([FromBody] ProductLike  productLike)
        {
            ProductCheckLike productCheck = new ProductCheckLike();
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@Code", length = 0, type = "nvarchar", value = productLike.Code });
            parameters.Add(new Parameter { parameter = "@Account", length = 0, type = "nvarchar", value = productLike.Account });
            parameters.Add(new Parameter { parameter = "@Screen", length = 0, type = "int", value = productLike.Screen });
            DAStoreEcommerce.Product.InsertLike(parameters);
            return Ok();
        }
    }
}