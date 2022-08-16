using LibraryStoreEcommerce;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static StoreEcommerceaApi.Database.DbSQLUtils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreEcommerceaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        // GET: api/<AddressController>
        [HttpGet("GetListDistricAndProvince")]
        public IActionResult GetListDistricAndProvince()
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
            return Ok(listaddress);
        }

        [HttpGet("SelectProvince")]
        public IActionResult SelectProvince()
        {
            List<Address> listaddress = new List<Address>();
            DAStoreEcommerce.Address.GetListProvince(out DataTable ds);
            foreach (DataRow row in ds.Rows)
            {
                Address address = new Address();
                address.ProvinceCode = row["ProvinceCode"] == DBNull.Value ? 0 : (int)row["ProvinceCode"];
                address.AddressName = row["AddressName"] == DBNull.Value ? "" : (string)row["AddressName"];
                listaddress.Add(address);
            }
            return Ok(listaddress);
        }
        [HttpPost("GetListProvince")]
        public IActionResult GetListProvince([FromBody] SearchInput searchInput)
        {
            List<Address> listaddress = new List<Address>();
            Parameter parameters = new Parameter() { parameter = "@TextSearch", length = 0, type = "nvarchar", value = searchInput.TextSearch };
            DAStoreEcommerce.Address.GetListProvinceName(parameters, out DataTable ds);
            int i = 0;
            foreach (DataRow row in ds.Rows)
            {
                Address address = new Address();
                address.STT = i + 1;
                i++;
                address.ProvinceCode = row["ProvinceCode"] == DBNull.Value ? 0 : (int)row["ProvinceCode"];
                address.AddressName = row["AddressName"] == DBNull.Value ? "" : (string)row["AddressName"];
                listaddress.Add(address);
            }
            return Ok(listaddress);
        }

        [HttpPost("SelectDistrictbyProvince")]
        public IActionResult SelectDistrictbyProvince([FromBody] AddressInput addressInput)
        {
            List<Address> listaddress = new List<Address>();
            Parameter parameter = new Parameter() { parameter = "@ID", length = 0, type = "int", value = addressInput.ID };
            DAStoreEcommerce.Address.GetListDistrictbyProvince(parameter, out DataTable ds);
            int i = 0;
            foreach (DataRow row in ds.Rows)
            {
                Address address = new Address();
                address.STT = i + 1;
                i++;
                address.ProvinceCode = row["ProvinceCode"] == DBNull.Value ? 0 : (int)row["ProvinceCode"];
                address.AddressName = row["AddressName"] == DBNull.Value ? "" : (string)row["AddressName"];
                listaddress.Add(address);
            }
            return Ok(listaddress);
        }
        [HttpPost("InsertDistrict")]
        public IActionResult InsertDistrict([FromBody] AddressInsert addressInsert)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@AddressName", length = 0, type = "nvarchar", value = addressInsert.AddressName });
            parameters.Add(new Parameter { parameter = "@ParentID", length = 0, type = "int", value = addressInsert.ParentID });
            DAStoreEcommerce.Address.InsertDistrict(parameters);
            return Ok();
        }

        [HttpPost("DeleteProvince")]
        public IActionResult DeleteProvince([FromBody] AddressInput addressInput)
        {
            Parameter parameters = new Parameter() { parameter = "@ID", length = 0, type = "nvarchar", value = addressInput.ID };
            DAStoreEcommerce.Address.DeleteProvince(parameters);
            return Ok();
        }

        [HttpPost("InsertAdressNew")]
        public IActionResult InsertAdressNew([FromBody] AddressNewInput addressNewInput)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@Address", length = 0, type = "nvarchar", value = addressNewInput.Address });
            parameters.Add(new Parameter { parameter = "@Account", length = 0, type = "nvarchar", value = addressNewInput.Account });
            parameters.Add(new Parameter { parameter = "@ProvinceCode", length = 0, type = "int", value = addressNewInput.ProvinceCode });
            parameters.Add(new Parameter { parameter = "@DistrictCode", length = 0, type = "int", value = addressNewInput.DistrictCode });
            DAStoreEcommerce.Address.InsertAdressNew(parameters);
            return Ok();
        }
        [HttpPost("GetListAddres")]
        public IActionResult GetListAddres([FromBody] AccountAddres accountInput)
        {
            Account account = new Account();

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
            List<Address> listaddressnew = new List<Address>();
            Parameter parameters = new Parameter() { parameter = "@UserName", length = 0, type = "nvarchar", value = accountInput.UserName };
            DAStoreEcommerce.Address.GetListNew(parameters, out DataTable ds1);
            int i = 0;
            foreach (DataRow row in ds1.Rows)
            {
                Address address = new Address();
                address.STT = i + 1;
                i++;
                address.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
                address.ProvinceCode = row["ProvinceCode"] == DBNull.Value ? 0 : (int)row["ProvinceCode"];
                address.AddressName = row["Address"] == DBNull.Value ? "" : (string)row["Address"];
                address.DistrictCode = row["DistrictCode"] == DBNull.Value ? 0 : (int)row["DistrictCode"];
                address.ProvinceName = listaddress.Find(x => x.ProvinceCode == address.ProvinceCode).AddressName;
                address.DistrictName = listaddress.Find(x => x.ProvinceCode == address.DistrictCode).AddressName;
                listaddressnew.Add(address);
            }
            return Ok(listaddressnew);
        }
        [HttpPost("GetAddresbyID")]
        public IActionResult GetAddresbyID([FromBody] AccountDelete accountInput)
        {
            Account account = new Account();

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
            AccountOutput addressnew = new AccountOutput();
            Parameter parameters = new Parameter() { parameter = "@ID", length = 0, type = "int", value = accountInput.ID };
            DAStoreEcommerce.Address.GetListAdressbyID(parameters, out DataTable ds1);
            int i = 0;
            foreach (DataRow row in ds1.Rows)
            {

                addressnew.STT = i + 1;
                i++;
                addressnew.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
                addressnew.ProvinceCode = row["ProvinceCode"] == DBNull.Value ? 0 : (int)row["ProvinceCode"];
                addressnew.Address = row["Address"] == DBNull.Value ? "" : (string)row["Address"];
                addressnew.DistrictCode = row["DistrictCode"] == DBNull.Value ? 0 : (int)row["DistrictCode"];
                addressnew.ProvinceName = listaddress.Find(x => x.ProvinceCode == addressnew.ProvinceCode).AddressName;
                addressnew.DistrictName = listaddress.Find(x => x.ProvinceCode == addressnew.DistrictCode).AddressName;
            }
            return Ok(addressnew);
        }
    }
}