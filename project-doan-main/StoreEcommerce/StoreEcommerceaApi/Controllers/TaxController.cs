using LibraryStoreEcommerce;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static StoreEcommerceaApi.Database.DbSQLUtils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreEcommerceaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        [HttpPost("GetList")]
      

        public IActionResult GetList([FromBody] Tax_SearchInput Taxinput)
        {
            
            List<Tax> taxss = new List<Tax>();
            Parameter parameters = new Parameter() { parameter = "@TextSearch", length = 0, type = "nvarchar", value = Taxinput.TextSearch };
            
            DAStoreEcommerce.Tax.GetList(parameters, out DataTable ds);
            int i = 0;          
            foreach (DataRow row in ds.Rows)
            {
                Tax tax = new Tax();
                tax.STT = i + 1;
                i++;
                tax.ID = (int)row["ID"];
                //tax.ObjectguidID = (Guid)row["ObjectguidID"];
                tax.NameTax = (string)row["NameTax"];
                tax.Value = (int)row["Value"];
                tax.Description = (string)row["Description"];
                taxss.Add(tax);
            }
            return Ok(taxss);
        }

        // GET api/<TaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpPost("Delete")]
        public IActionResult DeleteTax([FromBody] Tax tax)
        {
            Parameter param = new Parameter() { parameter = "@ID", length = 0, type = "int", value = tax.ID };
            DAStoreEcommerce.Tax.Delete(param);
            return Ok();
        }
    }
}
