using LibraryStoreEcommerce;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static StoreEcommerceaApi.Database.DbSQLUtils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreEcommerceaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyController : ControllerBase
    {
        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] Buy buy)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@UserName", length = 0, type = "nvarchar", value = buy.UserName  });
            parameters.Add(new Parameter { parameter = "@PriceShip", length = 0, type = "int", value = buy.PriceShip });
            parameters.Add(new Parameter { parameter = "@Address", length = 0, type = "nvarchar", value = buy.Address });
            parameters.Add(new Parameter { parameter = "@ProvinceCode", length = 0, type = "int", value = buy.ProvinceCode });
            parameters.Add(new Parameter { parameter = "@DistrictCode", length = 0, type = "int", value = buy.DistrictCode });
            parameters.Add(new Parameter { parameter = "@PayType", length = 0, type = "int", value = buy.PayType });
            parameters.Add(new Parameter { parameter = "@Code", length = 0, type = "nvarchar", value = buy.Code });
            parameters.Add(new Parameter { parameter = "@Propeties", length = 0, type = "int", value = buy.Propeties });
            parameters.Add(new Parameter { parameter = "@Number", length = 0, type = "int", value = buy.Number });
            parameters.Add(new Parameter { parameter = "@Value", length = 0, type = "nvarchar", value = buy.Value });
            parameters.Add(new Parameter { parameter = "@Size", length = 0, type = "nvarchar", value = buy.Size });
            DAStoreEcommerce.Buy.Insert(parameters);
            return Ok();
        }
        [HttpPost("DeleteProductAfterBuy")]
        public IActionResult DeleteProductAfterBuy([FromBody] Buy buy)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@Account", length = 0, type = "nvarchar", value = buy.UserName });                  
            parameters.Add(new Parameter { parameter = "@Code", length = 0, type = "nvarchar", value = buy.Code });           
            parameters.Add(new Parameter { parameter = "@Value", length = 0, type = "nvarchar", value = buy.Value });
            parameters.Add(new Parameter { parameter = "@Size", length = 0, type = "nvarchar", value = buy.Size });
            DAStoreEcommerce.Buy.DeleteProductAfterBuy(parameters);
            return Ok();
        }
        [HttpPost("ProductUserOrder")]
        public IActionResult ProductUserOrder([FromBody] UserOrderProduct  userOrderProduct)
        {
            List<Address> listaddress = new List<Address>();
            DAStoreEcommerce.Address.GetList(out DataTable ds);
            foreach (DataRow row in ds.Rows)
            {
                Address address = new Address();
                address.ProvinceCode = row["ProvinceCode"] == DBNull.Value ? 0 : (int)row["ProvinceCode"];
                address.DistrictCode = row["DistrictCode"] == DBNull.Value ? 0 : (int)row["DistrictCode"];
                address.AddressName = row["AddressName"] == DBNull.Value ? "" : (string)row["AddressName"];
                listaddress.Add(address);
            }
            List<BuyOutput> buyOutputs = new List<BuyOutput>();
            Parameter parameters = new Parameter() { parameter = "@Account", length = 0, type = "nvarchar", value = userOrderProduct.UserName };
            DAStoreEcommerce.Buy.GetList(parameters,out DataTable ds1);
            int i = 0;
            foreach (DataRow row in ds1.Rows)
            {
                BuyOutput buyOutput = new BuyOutput();
                buyOutput.STT = i + 1;
                i++;
                buyOutput.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
                buyOutput.Code = row["Code"] == DBNull.Value ? "" : (string)row["Code"];
                buyOutput.NameProduct = row["NameProduct"] == DBNull.Value ? "" : (string)row["NameProduct"];
                buyOutput.PictureLink = row["PictureLink"] == DBNull.Value ? "" : (string)row["PictureLink"];
                buyOutput.Size = row["Size"] == DBNull.Value ? "" : (string)row["Size"];
                buyOutput.Price = row["Price"] == DBNull.Value ? 0 : (int)row["Price"];
                buyOutput.ProvinceCode = row["ProvinceCode"] == DBNull.Value ? 0 : (int)row["ProvinceCode"];
                buyOutput.DistrictCode = row["DistrictCode"] == DBNull.Value ? 0 : (int)row["DistrictCode"];
                buyOutput.Number = row["Number"] == DBNull.Value ? 0 : (int)row["Number"];
                buyOutput.Value = row["Value"] == DBNull.Value ? "" : (string)row["Value"];
                buyOutput.Pay = row["Pay"] == DBNull.Value ? "" : (string)row["Pay"];
                buyOutput.Date = row["Date"] == DBNull.Value ? DateTime.Now : (DateTime)row["Date"];
                buyOutput.ProvinceName = listaddress.Find(x => x.ProvinceCode == buyOutput.ProvinceCode).AddressName;
                buyOutput.DistrictName = listaddress.Find(x => x.ProvinceCode == buyOutput.DistrictCode).AddressName;
                buyOutputs.Add(buyOutput);
            }
            return Ok(buyOutputs);
        }

        // POST api/<BuyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BuyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BuyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
