using LibraryStoreEcommerce;
using Microsoft.AspNetCore.Mvc;
using StoreEcommerceaApi.Database;
using System.Data;
using static StoreEcommerceaApi.Database.DbSQLUtils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreEcommerceaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        public static int CheckExitsCart_InAccount(Cart Cart,out int number)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@Account", length = 0, type = "nvarchar", value = Cart.Account });
            parameters.Add(new Parameter { parameter = "@Code", length = 0, type = "nvarchar", value = Cart.Code });
            parameters.Add(new Parameter { parameter = "@Properties", length = 0, type = "int", value = Cart.Properties });
            parameters.Add(new Parameter { parameter = "@Size", length = 0, type = "nvarchar", value = Cart.Size });
            parameters.Add(new Parameter { parameter = "@Value", length = 0, type = "nvarchar", value = Cart.Color });
            return DAStoreEcommerce.Cart.CheckExitsCart_InAccount(parameters,out number);
        }
        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] Cart cart)
        {
            CheckExitsCart_InAccount(cart, out int result);
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@Account", length = 0, type = "nvarchar", value = cart.Account });
            parameters.Add(new Parameter { parameter = "@Code", length = 0, type = "nvarchar", value = cart.Code });
            parameters.Add(new Parameter { parameter = "@Number", length = 0, type = "int", value = cart.Number });
            parameters.Add(new Parameter { parameter = "@Properties", length = 0, type = "int", value = cart.Properties });
            parameters.Add(new Parameter { parameter = "@Size", length = 0, type = "nvarchar", value = cart.Size });
            parameters.Add(new Parameter { parameter = "@Value", length = 0, type = "nvarchar", value = cart.Color });
            parameters.Add(new Parameter { parameter = "@Check", length = 0, type = "int", value = result });
            DAStoreEcommerce.Cart.Insert(parameters);
            return Ok();
        }

        [HttpPost("GetList")]
        public IActionResult GetList([FromBody] InputAccount input)
        {
            List<Product> products = new List<Product>();
            Parameter parameters = new Parameter() { parameter = "@Account", length = 0, type = "nvarchar", value = input.Account };
            DAStoreEcommerce.Cart.GetListCartbyAccount(parameters, out DataTable ds);
            int i = 0;
            foreach (DataRow row in ds.Rows)
            {
                Product product = new Product();
                product.STT = i + 1;
                i++;
                product.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
                product.ID_Cart = row["ID_Cart"] == DBNull.Value ? 0 : (int)row["ID_Cart"];
                product.Likes = row["Likes"] == DBNull.Value ? 0 : (int)row["Likes"];
                product.Code = row["Code"] == DBNull.Value ? "" : (string)row["Code"];
                product.NameProduct = row["NameProduct"] == DBNull.Value ? "" : (string)row["NameProduct"];
                product.PictureLink = row["PictureLink"] == DBNull.Value ? "" : (string)row["PictureLink"];
                product.Price = row["Price"] == DBNull.Value ? "" : (string)row["Price"];
                product.Size = row["Size"] == DBNull.Value ? "" : (string)row["Size"];
                product.Number = row["Number"] == DBNull.Value ? 0 : (int)row["Number"];
                product.PriceProduct = row["PriceProduct"] == DBNull.Value ? 0 : (int)row["PriceProduct"];
                product.Properties = row["Properties"] == DBNull.Value ? "" : (string)row["Properties"];
                product.Value = row["Color"] == DBNull.Value ? "" : (string)row["Color"];
                product.Property = row["Property"] == DBNull.Value ? 0 : (int)row["Property"];
                product.Total = row["Total"] == DBNull.Value ? 0 : (int)row["Total"];
                products.Add(product);

            }
            return Ok(products);
        }

        [HttpPost("CartNow")]
        public IActionResult BuyNow([FromBody] BuyInput buyInput)
        {
            List<Product> products = new List<Product>();           
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@Properties", length = 0, type = "nvarchar", value = buyInput.Propeties });
            parameters.Add(new Parameter { parameter = "@Code", length = 0, type = "nvarchar", value = buyInput.Code });
            parameters.Add(new Parameter { parameter = "@Value", length = 0, type = "nvarchar", value = buyInput.Value });
            parameters.Add(new Parameter { parameter = "@Size", length = 0, type = "nvarchar", value = buyInput.Size });
            DAStoreEcommerce.Cart.GetListCartNow(parameters, out DataTable ds);
            int i = 0;
            foreach (DataRow row in ds.Rows)
            {
                Product product = new Product();
                product.STT = i + 1;
                i++;
                product.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
                product.Likes = row["Likes"] == DBNull.Value ? 0 : (int)row["Likes"];
                product.Code = row["Code"] == DBNull.Value ? "" : (string)row["Code"];
                product.NameProduct = row["NameProduct"] == DBNull.Value ? "" : (string)row["NameProduct"];
                product.PictureLink = row["PictureLink"] == DBNull.Value ? "" : (string)row["PictureLink"];
                product.Price = row["Price"] == DBNull.Value ? "" : (string)row["Price"];
                product.PriceProduct = row["PriceProduct"] == DBNull.Value ? 0 : (int)row["PriceProduct"];
                product.Properties = row["Properties"] == DBNull.Value ? "" : (string)row["Properties"];
                product.Value = row["Color"] == DBNull.Value ? "" : (string)row["Color"];
                product.Property = row["Property"] == DBNull.Value ? 0 : (int)row["Property"];
                product.Size = row["Size"] == DBNull.Value ? "" : (string)row["Size"];
                products.Add(product);
            }
            return Ok(products);
        }

        [HttpPost("DeleteCart")]
        public IActionResult DeleteCart([FromBody] CartDelete  cartDelete)
        {
            Parameter parameter = new Parameter() { parameter = "@ID", length = 0, type = "int", value = cartDelete.ID };
            DAStoreEcommerce.Cart.DeleteCart(parameter);            
            return Ok();
        }

        [HttpPost("GetListCartNew")]
        public IActionResult GetListCartNew([FromBody] InputAccount input)
        {
            List<Product> products = new List<Product>();
            Parameter parameters = new Parameter() { parameter = "@Account", length = 0, type = "nvarchar", value = input.Account };
            DAStoreEcommerce.Cart.GetListCartbyAccountNew(parameters, out DataTable ds);
            int i = 0;
            foreach (DataRow row in ds.Rows)
            {
                Product product = new Product();
                product.STT = i + 1;
                i++;
                product.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
                product.ID_Cart = row["ID_Cart"] == DBNull.Value ? 0 : (int)row["ID_Cart"];
                product.Likes = row["Likes"] == DBNull.Value ? 0 : (int)row["Likes"];
                product.Code = row["Code"] == DBNull.Value ? "" : (string)row["Code"];
                product.NameProduct = row["NameProduct"] == DBNull.Value ? "" : (string)row["NameProduct"];
                product.PictureLink = row["PictureLink"] == DBNull.Value ? "" : (string)row["PictureLink"];
                product.Price = row["Price"] == DBNull.Value ? "" : (string)row["Price"];
                product.PriceShip = row["PriceShip"] == DBNull.Value ? 0 : (int)row["PriceShip"];
                product.Size = row["Size"] == DBNull.Value ? "" : (string)row["Size"];
                product.Number = row["Number"] == DBNull.Value ? 0 : (int)row["Number"];
                product.PriceProduct = row["PriceProduct"] == DBNull.Value ? 0 : (int)row["PriceProduct"];
                product.Properties = row["Properties"] == DBNull.Value ? "" : (string)row["Properties"];
                product.Value = row["Color"] == DBNull.Value ? "" : (string)row["Color"];
                product.Property = row["Property"] == DBNull.Value ? 0 : (int)row["Property"];
                product.Total = row["Total"] == DBNull.Value ? 0 : (int)row["Total"];
                products.Add(product);

            }
            return Ok(products);
        }
        // Thay đổi phí ship sau khi chọn địa chỉ
        [HttpPost("GetListCartAfterChangeAddress")]
        public IActionResult GetListCartAfterChangeAddress([FromBody] CartInput input)
        {
            List<Product> products = new List<Product>();
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@Account", length = 0, type = "nvarchar", value = input.Account });
            parameters.Add(new Parameter { parameter = "@ProvinceCode", length = 0, type = "int", value = input.ProvinceCode });
            parameters.Add(new Parameter { parameter = "@DistrictCode", length = 0, type = "int", value = input.DistrictCode });
            DAStoreEcommerce.Cart.GetListCartAfterChangeAdress(parameters, out DataTable ds);
            int i = 0;
            foreach (DataRow row in ds.Rows)
            {
                Product product = new Product();
                product.STT = i + 1;
                i++;
                product.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
                product.ID_Cart = row["ID_Cart"] == DBNull.Value ? 0 : (int)row["ID_Cart"];
                product.Likes = row["Likes"] == DBNull.Value ? 0 : (int)row["Likes"];
                product.Code = row["Code"] == DBNull.Value ? "" : (string)row["Code"];
                product.NameProduct = row["NameProduct"] == DBNull.Value ? "" : (string)row["NameProduct"];
                product.PictureLink = row["PictureLink"] == DBNull.Value ? "" : (string)row["PictureLink"];
                product.Price = row["Price"] == DBNull.Value ? "" : (string)row["Price"];
                product.PriceShip = row["PriceShip"] == DBNull.Value ? 0 : (int)row["PriceShip"];
                product.Size = row["Size"] == DBNull.Value ? "" : (string)row["Size"];
                product.Number = row["Number"] == DBNull.Value ? 0 : (int)row["Number"];
                product.PriceProduct = row["PriceProduct"] == DBNull.Value ? 0 : (int)row["PriceProduct"];
                product.Properties = row["Properties"] == DBNull.Value ? "" : (string)row["Properties"];
                product.Value = row["Color"] == DBNull.Value ? "" : (string)row["Color"];
                product.Property = row["Property"] == DBNull.Value ? 0 : (int)row["Property"];
                product.Total = row["Total"] == DBNull.Value ? 0 : (int)row["Total"];
                products.Add(product);

            }
            return Ok(products);
        }
    }
}
