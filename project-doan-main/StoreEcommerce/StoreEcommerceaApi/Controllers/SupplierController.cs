using LibraryStoreEcommerce;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static StoreEcommerceaApi.Database.DbSQLUtils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreEcommerceaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        [HttpPost("Supplier")]
        public IActionResult Supplier([FromBody] Address_SearchInput supplierInput)
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
            List<Supplier> suppliers = new List<Supplier>();
            Parameter parameters = new Parameter() { parameter = "@TextSearch", length = 0, type = "nvarchar", value = supplierInput.TextSearch };
            DAStoreEcommerce.SystemKey.GetListSuppliers(parameters,out DataTable ds1);
            int STT = 0;
            foreach (DataRow row in ds1.Rows)
            {
                Supplier supplier = new Supplier();
                supplier.STT = STT + 1;
                STT++;
                supplier.NameSupplier = row["NameSupplier"] == DBNull.Value ? "" : (string)row["NameSupplier"];
                supplier.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
                supplier.Address = row["Address"] == DBNull.Value ? "" : (string)row["Address"];
                supplier.ProvinceCode = row["ProvinceCode"] == DBNull.Value ? 0 : (int)row["ProvinceCode"];
                supplier.DistrictCode = row["DistrictCode"] == DBNull.Value ? 0 : (int)row["DistrictCode"];
                supplier.ProvinceName = listaddress.Find(x => x.ProvinceCode == supplier.ProvinceCode).AddressName;
                supplier.DistrictName = listaddress.Find(x => x.ProvinceCode == supplier.DistrictCode).AddressName;
                suppliers.Add(supplier);
            }
            return Ok(suppliers);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] SupplierInput supplierInput)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@ID", length = 0, type = "int", value = supplierInput.ID });
            parameters.Add(new Parameter { parameter = "@SupplierName", length = 0, type = "nvarchar", value = supplierInput.SupplierName });
            parameters.Add(new Parameter { parameter = "@AddressName", length = 0, type = "nvarchar", value = supplierInput.AddressName });
            parameters.Add(new Parameter { parameter = "@ProvinceCode", length = 0, type = "int", value = supplierInput.ProvinceCode });
            parameters.Add(new Parameter { parameter = "@DistrictCode", length = 0, type = "int", value = supplierInput.DistrictCode });
            DAStoreEcommerce.Address.UpdateSupplier(parameters);
            return Ok();
        }
        [HttpPost("Delete")]
        public IActionResult Update([FromBody] AddressInput supplierInput)
        {
            Parameter parameters = new Parameter() { parameter = "@ID", length = 0, type = "nvarchar", value = supplierInput.ID };
            DAStoreEcommerce.Address.DeleteSupplier(parameters);
            return Ok();
        }
        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] SupplierInput supplierInput)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@SupplierName", length = 0, type = "nvarchar", value = supplierInput.SupplierName });
            parameters.Add(new Parameter { parameter = "@AddressName", length = 0, type = "nvarchar", value = supplierInput.AddressName });
            parameters.Add(new Parameter { parameter = "@ProvinceCode", length = 0, type = "int", value = supplierInput.ProvinceCode });
            parameters.Add(new Parameter { parameter = "@DistrictCode", length = 0, type = "int", value = supplierInput.DistrictCode });
            DAStoreEcommerce.Address.InsertSupplier(parameters);
            return Ok();
        }

    }
}
