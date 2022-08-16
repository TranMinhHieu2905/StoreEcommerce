using LibraryStoreEcommerce;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static StoreEcommerceaApi.Database.DbSQLUtils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreEcommerceaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemKeyController : ControllerBase
    {
        // GET: api/<SystemKeyController>
        [HttpGet("Type")]
        public IActionResult GetSystemKey()
        {
            List<SystemKey> systemKeys = new List<SystemKey>();
            DAStoreEcommerce.SystemKey.GetList(out DataTable ds);           
            foreach (DataRow row in ds.Rows)
            {
                SystemKey systemKey = new SystemKey();
                systemKey.NameType = row["NameType"] == DBNull.Value ? "" : (string)row["NameType"];
                systemKey.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
                systemKeys.Add(systemKey);
            }
            return Ok(systemKeys);
        }
        [HttpGet("Properties")]
        public IActionResult GetProperties()
        {
            List<SystemKeyProperties> systemKeys = new List<SystemKeyProperties>();
            DAStoreEcommerce.SystemKey.GetListProperties(out DataTable ds);
            foreach (DataRow row in ds.Rows)
            {
                SystemKeyProperties systemKey = new SystemKeyProperties();
                systemKey.Name = row["Name"] == DBNull.Value ? "" : (string)row["Name"];
                systemKey.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
                systemKeys.Add(systemKey);
            }
            return Ok(systemKeys);
        }
        [HttpGet("Tax")]
        public IActionResult GetTax()
        {
            List<SystemKeyTax> systemKeys = new List<SystemKeyTax>();
            DAStoreEcommerce.SystemKey.GetListTax(out DataTable ds);
            foreach (DataRow row in ds.Rows)
            {
                SystemKeyTax systemKey = new SystemKeyTax();
                systemKey.NameTax = row["NameTax"] == DBNull.Value ? "" : (string)row["NameTax"];
                systemKey.Descriptions = row["Description"] == DBNull.Value ? "" : (string)row["Description"];
                systemKey.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
                systemKeys.Add(systemKey);
            }
            return Ok(systemKeys);
        }
        [HttpPost("Default")]
        public IActionResult Default([FromBody] DefaultValue defaultValue)
        {
            List<DefaultOuput> systemKeys = new List<DefaultOuput>();
            Parameter parameter = new Parameter() { parameter = "@ID", length = 0, type = "int", value = defaultValue.ID };
            DAStoreEcommerce.SystemKey.GetListDefault(parameter, out DataTable ds);
            foreach (DataRow row in ds.Rows)
            {
                DefaultOuput systemKey = new DefaultOuput();               
                systemKey.Value = row["Value"] == DBNull.Value ? "" : (string)row["Value"];
                systemKey.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
                systemKeys.Add(systemKey);
            }
            return Ok(systemKeys);
        }

        [HttpGet("Supplier")]
        public IActionResult Supplier()
        {
            List<SystemKeySupplier> systemKeys = new List<SystemKeySupplier>();
            DAStoreEcommerce.SystemKey.GetListSupplier(out DataTable ds);
            int STT = 0;
            foreach (DataRow row in ds.Rows)
            {
                SystemKeySupplier systemKey = new SystemKeySupplier();
                systemKey.STT = STT + 1;
                STT++;
                systemKey.NameSupplier = row["NameSupplier"] == DBNull.Value ? "" : (string)row["NameSupplier"];
                systemKey.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
                systemKeys.Add(systemKey);
            }
            return Ok(systemKeys);
        }

        [HttpPost("TypeProduct")]
        public IActionResult TypeProduct([FromBody] TypeProduct typeProduct)
        {
            List<SystemKey> systemKeys = new List<SystemKey>();
            Parameter parameter = new Parameter() { parameter = "@TextSearch", length = 0, type = "nvarchar", value = typeProduct.TextSearch };
            DAStoreEcommerce.SystemKey.GetListTypeProduct(parameter, out DataTable ds);
            int i = 0;
            foreach (DataRow row in ds.Rows)
            {
                SystemKey systemKey = new SystemKey();
                systemKey.STT = i + 1;
                i++;
                systemKey.Descriptions = row["Descriptions"] == DBNull.Value ? "" : (string)row["Descriptions"];
                systemKey.NameType = row["NameType"] == DBNull.Value ? "" : (string)row["NameType"];
                systemKey.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
                systemKeys.Add(systemKey);
            }
            return Ok(systemKeys);
        }

         [HttpPost("InsertType")]
        public IActionResult InsertType([FromBody] TypeProductInsert typeProduct)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@Name", length = 0, type = "nvarchar", value = typeProduct.Name });
            parameters.Add(new Parameter { parameter = "@Description", length = 0, type = "nvarchar", value = typeProduct.Description });
            DAStoreEcommerce.SystemKey.InsertType(parameters);
            return Ok();
        }
        [HttpPost("UpdateType")]
        public IActionResult UpdateType([FromBody] TypeProductInsert typeProduct)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@ID", length = 0, type = "int", value = typeProduct.ID });
            parameters.Add(new Parameter { parameter = "@Name", length = 0, type = "nvarchar", value = typeProduct.Name });
            parameters.Add(new Parameter { parameter = "@Description", length = 0, type = "nvarchar", value = typeProduct.Description });
            DAStoreEcommerce.SystemKey.UpdateType(parameters);
            return Ok();
        }
        [HttpPost("DeleteType")]
        public IActionResult DeleteType([FromBody] TypeProductDelete typeProduct)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@ID", length = 0, type = "int", value = typeProduct.ID });           
            DAStoreEcommerce.SystemKey.DeleteType(parameters);
            return Ok();
        }
    }
}
