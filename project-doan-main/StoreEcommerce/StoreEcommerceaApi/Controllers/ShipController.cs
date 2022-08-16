using LibraryStoreEcommerce;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static StoreEcommerceaApi.Database.DbSQLUtils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreEcommerceaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipController : ControllerBase
    {
        [HttpPost("GetPricebyDistrictAndProvince")]
        public IActionResult GetPricebyDistrictAndProvince([FromBody] ShipInput shipInput)
        {
            ShipOutput ship = new ShipOutput();
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@ProvinceCode", length = 0, type = "int", value = shipInput.ProvinceCode });
            parameters.Add(new Parameter { parameter = "@DistrictCode", length = 0, type = "int", value = shipInput.DistrictCode });
            DAStoreEcommerce.Ship.GetPricebyDistrictAndProvince(parameters,out DataTable ds);
            foreach (DataRow row in ds.Rows)
            {
                ship.PriceShip = row["Price"] == DBNull.Value ? 0 : (int)row["Price"];             
            }
            return Ok(ship);
        }

        [HttpPost("GetPricebyDistrictAndProvinceProductShip")]
        public IActionResult GetPricebyDistrictAndProvinceProductShip([FromBody] ShipInput shipInput)
        {
            ShipOutput ship = new ShipOutput();
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@ProvinceCode", length = 0, type = "int", value = shipInput.ProvinceCode });
            parameters.Add(new Parameter { parameter = "@DistrictCode", length = 0, type = "int", value = shipInput.DistrictCode });
            parameters.Add(new Parameter { parameter = "@ProductShip", length = 0, type = "int", value = shipInput.ProductShip });            
            DAStoreEcommerce.Ship.GetPricebyDistrictAndProvinceProductShip(parameters, out DataTable ds);
            foreach (DataRow row in ds.Rows)
            {
                ship.PriceShip = row["Price"] == DBNull.Value ? 0 : (int)row["Price"];
            }
            return Ok(ship);
        }

        // POST api/<ShipController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ShipController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShipController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
