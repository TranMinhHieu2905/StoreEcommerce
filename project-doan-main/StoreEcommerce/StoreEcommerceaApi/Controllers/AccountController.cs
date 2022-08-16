using LibraryStoreEcommerce;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static StoreEcommerceaApi.Database.DbSQLUtils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreEcommerceaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost("GetList")]
        public IActionResult GetList([FromBody] AccountInput accountInput)
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
            AccountOutput account = new AccountOutput();
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@UserName", length = 0, type = "nvarchar", value = accountInput.UserName });
            parameters.Add(new Parameter { parameter = "@Password", length = 0, type = "nvarchar", value = accountInput.Password });
            DAStoreEcommerce.Account.SellectLogin(parameters, out DataTable ds1);
            if (ds1 == null) return BadRequest();
            foreach (DataRow row in ds1.Rows)
            {
                account.Password = row["Password"] == DBNull.Value ? "" : (string)row["Password"];
                account.UserName = row["UserName"] == DBNull.Value ? "" : (string)row["UserName"];
                account.DistrictCode = row["DistrictCode"] == DBNull.Value ? 0 : (int)row["DistrictCode"];
                account.ProvinceCode = row["ProvinceCode"] == DBNull.Value ? 0 : (int)row["ProvinceCode"];
                account.Address = row["Address"] == DBNull.Value ? "" : (string)row["Address"];
                account.Phone = row["Phone"] == DBNull.Value ? "" : (string)row["Phone"];
                account.FullName = row["Name"] == DBNull.Value ? "" : (string)row["Name"];
                account.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
                account.ProvinceName = listaddress.Find(x => x.ProvinceCode == account.ProvinceCode).AddressName;
                account.DistrictName = listaddress.Find(x => x.ProvinceCode == account.DistrictCode).AddressName;
            }
            return Ok(account);
        }

        [HttpPost("GetAddressByAccount")]
        public IActionResult GetAddressByAccount([FromBody] AccountInput accountInput)
        {
            Account account = new Account();
            Parameter parameters = new Parameter() { parameter = "@UserName", length = 0, type = "nvarchar", value = accountInput.UserName };
            DAStoreEcommerce.Account.GetAddressByAccount(parameters, out DataTable ds);
            foreach (DataRow row in ds.Rows)
            {
                account.ProvinceCode = row["ProvinceCode"] == DBNull.Value ? 0 : (int)row["ProvinceCode"];
                account.DistrictCode = row["DistrictCode"] == DBNull.Value ? 0 : (int)row["DistrictCode"];
            }
            return Ok(account);
        }
        [HttpPost("GetOnebyID")]
        public IActionResult GetOnebyID([FromBody] Account accountInput)
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
            AccountOutput account = new AccountOutput();
            Parameter parameters = new Parameter() { parameter = "@ID", length = 0, type = "int", value = accountInput.ID };
            DAStoreEcommerce.Account.GetOne(parameters, out DataTable ds1);
            foreach (DataRow row in ds1.Rows)
            {
                account.UserName = row["UserName"] == DBNull.Value ? "" : (string)row["UserName"];
                account.Gender = row["Gender"] == DBNull.Value ? "" : (string)row["Gender"];
                account.Day = row["Birthday"] == DBNull.Value ? DateTime.Now : (DateTime)row["Birthday"];
                account.Address = row["Address"] == DBNull.Value ? "" : (string)row["Address"];
                account.Phone = row["Phone"] == DBNull.Value ? "" : (string)row["Phone"];
                account.FullName = row["Name"] == DBNull.Value ? "" : (string)row["Name"];
                account.DistrictCode = row["DistrictCode"] == DBNull.Value ? 0 : (int)row["DistrictCode"];
                account.ProvinceCode = row["ProvinceCode"] == DBNull.Value ? 0 : (int)row["ProvinceCode"];
                account.Sex = row["Sex"] == DBNull.Value ? 0 : (int)row["Sex"];
                account.Email = row["Email"] == DBNull.Value ? "" : (string)row["Email"];
                account.ProvinceName = listaddress.Find(x => x.ProvinceCode == account.ProvinceCode).AddressName;
                account.DistrictName = listaddress.Find(x => x.ProvinceCode == account.DistrictCode).AddressName;
            }
            return Ok(account);
        }
        [HttpPost("UpdatePassword")]
        public IActionResult UpdatePassword([FromBody] AccountOutput accountInput)
        {            
            AccountOutput account = new AccountOutput();
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@UserName", length = 0, type = "nvarchar", value = accountInput.UserName });
            parameters.Add(new Parameter { parameter = "@Password", length = 0, type = "nvarchar", value = accountInput.CheckPassword });
            DAStoreEcommerce.Account.SellectLogin(parameters, out DataTable ds1);
            foreach (DataRow row in ds1.Rows)
            {
                account.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
            }
            if (account.ID ==0)
            {
                return BadRequest();
            }
            else
            {
                List<Parameter> parameter = new List<Parameter>();
                parameter.Add(new Parameter { parameter = "@UserName", length = 0, type = "nvarchar", value = accountInput.UserName });
                parameter.Add(new Parameter { parameter = "@Password", length = 0, type = "nvarchar", value = accountInput.PasswordNew });
                DAStoreEcommerce.Account.UpdatePassword(parameter);
                return Ok();
            }
           
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] AccountOutput accountInput)
        {           
            AccountOutput account = new AccountOutput();
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@UserName", length = 0, type = "nvarchar", value = accountInput.UserName });
            parameters.Add(new Parameter { parameter = "@DistrictCode", length = 0, type = "nvarchar", value = accountInput.DistrictCode });
            parameters.Add(new Parameter { parameter = "@ProvinceCode", length = 0, type = "nvarchar", value = accountInput.ProvinceCode });
            parameters.Add(new Parameter { parameter = "@Phone", length = 0, type = "nvarchar", value = accountInput.Phone });
            parameters.Add(new Parameter { parameter = "@FullName", length = 0, type = "nvarchar", value = accountInput.FullName });
            parameters.Add(new Parameter { parameter = "@Sex", length = 0, type = "int", value = accountInput.Sex });
            parameters.Add(new Parameter { parameter = "@Email", length = 0, type = "nvarchar", value = accountInput.Email });
            parameters.Add(new Parameter { parameter = "@Address", length = 0, type = "nvarchar", value = accountInput.Address });
            parameters.Add(new Parameter { parameter = "@Birthday", length = 0, type = "datetime", value = accountInput.Day });
            DAStoreEcommerce.Account.Update(parameters);
            return Ok();
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] AccountResgiter accountInput)
        {
            try
            {
                List<Parameter> parameter = new List<Parameter>();
                parameter.Add(new Parameter { parameter = "@UserName", length = 0, type = "nvarchar", value = accountInput.UserName });
                DAStoreEcommerce.Account.CheckAccount(parameter, out int ds);
                if (ds == 0)
                {
                    List<Parameter> parameters = new List<Parameter>();
                    parameters.Add(new Parameter { parameter = "@UserName", length = 0, type = "nvarchar", value = accountInput.UserName });
                    parameters.Add(new Parameter { parameter = "@DistrictCode", length = 0, type = "nvarchar", value = accountInput.DistrictCode });
                    parameters.Add(new Parameter { parameter = "@ProvinceCode", length = 0, type = "nvarchar", value = accountInput.ProvinceCode });
                    parameters.Add(new Parameter { parameter = "@Phone", length = 0, type = "nvarchar", value = accountInput.Phone });
                    parameters.Add(new Parameter { parameter = "@FullName", length = 0, type = "nvarchar", value = accountInput.FullName });
                    parameters.Add(new Parameter { parameter = "@Sex", length = 0, type = "int", value = accountInput.Sex });
                    parameters.Add(new Parameter { parameter = "@Email", length = 0, type = "nvarchar", value = accountInput.Email });
                    parameters.Add(new Parameter { parameter = "@Address", length = 0, type = "nvarchar", value = accountInput.Address });
                    parameters.Add(new Parameter { parameter = "@Birthday", length = 0, type = "datetime", value = accountInput.Birthday });
                    parameters.Add(new Parameter { parameter = "@Password", length = 0, type = "nvarchar", value = accountInput.Password });
                    parameters.Add(new Parameter { parameter = "@Type", length = 0, type = "int", value = accountInput.Type });
                    DAStoreEcommerce.Account.Insert(parameters);

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return Ok();
        }

        [HttpPost("GetListAccount")]
        public IActionResult GetListAccount([FromBody] AccountSearch  accountSearch)
        {
            List<AccountOutput> accounts = new List<AccountOutput>();
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@TextSearch", length = 0, type = "nvarchar", value = accountSearch.TextSearch });
            parameters.Add(new Parameter { parameter = "@Screen", length = 0, type = "int", value = accountSearch.Screen });
            DAStoreEcommerce.Account.GetListAccount(parameters, out DataTable ds);
            int STT = 0;
            foreach (DataRow row in ds.Rows)
            {
                AccountOutput account = new AccountOutput();
                account.STT = STT + 1;
                STT++;
                account.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
                account.IsActive = row["IsActive"] == DBNull.Value ? 0 : (int)row["IsActive"];
                account.Password = row["Password"] == DBNull.Value ? "" : (string)row["Password"];
                account.UserName = row["UserName"] == DBNull.Value ? "" : (string)row["UserName"];
                account.Phone = row["Phone"] == DBNull.Value ? "" : (string)row["Phone"];
                account.FullName = row["Name"] == DBNull.Value ? "" : (string)row["Name"];
                accounts.Add(account);
            }
            return Ok(accounts);
        }
        [HttpPost("Delete")]
        public IActionResult Delete([FromBody] AccountDelete  accountDelete)
        {
            AccountOutput account = new AccountOutput();
            Parameter parameters = new Parameter() { parameter = "@ID", length = 0, type = "int", value = accountDelete.ID };
            DAStoreEcommerce.Account.Delete(parameters);
            return Ok();
        }
        // kHÔI PHỤC LẠI USER
        [HttpPost("RestoreUser")]
        public IActionResult RestoreUser([FromBody] AccountDelete accountDelete)
        {
            AccountOutput account = new AccountOutput();
            Parameter parameters = new Parameter() { parameter = "@ID", length = 0, type = "int", value = accountDelete.ID };
            DAStoreEcommerce.Account.RestoreUser(parameters);
            return Ok();
        }
    }
}
