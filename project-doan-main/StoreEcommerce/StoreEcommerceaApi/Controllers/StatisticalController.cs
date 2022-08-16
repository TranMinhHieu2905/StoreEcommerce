using LibraryStoreEcommerce;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using System.Net.Mail;
using static StoreEcommerceaApi.Database.DbSQLUtils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreEcommerceaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticalController : ControllerBase
    {
        [HttpGet("GetProductSelling")]
        public IActionResult GetProductSelling()
        {
            List<Statistical>  statisticals = new List<Statistical>();
            DAStoreEcommerce.Statistical.GetList(out DataTable ds);
            foreach (DataRow row in ds.Rows)
            {
                Statistical statistical = new Statistical();
                statistical.Code = row["Code"] == DBNull.Value ? "" : (string)row["Code"];
                statistical.NameProduct = row["NameProduct"] == DBNull.Value ? "" : (string)row["NameProduct"];
                statistical.Number = row["Number"] == DBNull.Value ? 0 : (int)row["Number"];
                statistical.Price = row["Price"] == DBNull.Value ? 0 : (int)row["Price"];
                statistical.ToTal = row["ToTal"] == DBNull.Value ? 0 : (int)row["ToTal"];
                statisticals.Add(statistical);
            }
            return Ok(statisticals);
        }
        // GetList đơn hàng API cũ
        [HttpPost("GetListProduct")]
        public IActionResult GetList([FromBody] StatisticalInput searchInput)
        {
            List<StatisticalOutput> statisticalOutputs = new List<StatisticalOutput>();
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@TextSearch", length = 0, type = "nvarchar", value = searchInput.TextSearch });
            parameters.Add(new Parameter { parameter = "@Screen", length = 0, type = "int", value = searchInput.Screen });
            parameters.Add(new Parameter { parameter = "@FromDate", length = 0, type = "datetime", value = searchInput.FromDate });
            parameters.Add(new Parameter { parameter = "@ToDate", length = 0, type = "datetime", value = searchInput.ToDate });
            DAStoreEcommerce.Statistical.GetListProduct(parameters, out DataTable ds);
            int i = 0;
            foreach (DataRow row in ds.Rows)
            {
                StatisticalOutput statisticalOutput = new StatisticalOutput();
                statisticalOutput.STT = i + 1;
                i++;
                statisticalOutput.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
                statisticalOutput.UserName = row["Account"] == DBNull.Value ? "" : (string)row["Account"];
                statisticalOutput.Pay = row["Pay"] == DBNull.Value ? "" : (string)row["Pay"];
                statisticalOutput.TypePay = row["TypePay"] == DBNull.Value ? 0 : (int)row["TypePay"];
                statisticalOutput.Date = row["Date"] == DBNull.Value ? DateTime.Now : (DateTime)row["Date"];
                statisticalOutput.Status = row["Status"] == DBNull.Value ? "" : (string)row["Status"];
                statisticalOutput.StatusID = row["StatusID"] == DBNull.Value ? 0 : (int)row["StatusID"];
                statisticalOutputs.Add(statisticalOutput);
            }
            return Ok(statisticalOutputs);
        }

        [HttpPost("UpdateStatus")]
        public IActionResult Delete([FromBody] StatisticalStatusID  statisticalStatusID)
        {
            Category category = new Category();
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@ID", length = 0, type = "int", value = statisticalStatusID.ID });
            parameters.Add(new Parameter { parameter = "@StatusID", length = 0, type = "int", value = statisticalStatusID.StatusID });
            DAStoreEcommerce.Statistical.UpdateStatus(parameters);                        
            return Ok();
        }

        [HttpPost]
        public ActionResult SendMailCandidate([FromBody] SendMail sendMail)
        {
            string Message = "";
            try
            {
                MailMessage mail = new MailMessage();

                //set the addresses 
                mail.From = new MailAddress("Hieuminhtran2905@gmail.com");
                mail.To.Add("Hieuminhtran2905@gmail.com");

                //set the content 
                mail.Subject = "This is a test email from C# script";
                mail.Body = "This is a test email from C# script";
                //send the message 
                SmtpClient smtp = new SmtpClient("mail.domainname.com");

                NetworkCredential Credentials = new NetworkCredential("Hieuminhtran2905@gmail.com", "Anhhuy1j");
                smtp.Credentials = Credentials;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return Ok(Message);
        }

        [HttpPost("GetListProductByStatusID")]
        public IActionResult GetListProductByStatusID([FromBody] StatisticalInput searchInput)
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
            List<StatisticalOutputDetail> statisticalOutputs = new List<StatisticalOutputDetail>();
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@TextSearch", length = 0, type = "nvarchar", value = searchInput.TextSearch });
            parameters.Add(new Parameter { parameter = "@Screen", length = 0, type = "int", value = searchInput.Screen });
            parameters.Add(new Parameter { parameter = "@StatusID", length = 0, type = "int", value = searchInput.StatusID });
            parameters.Add(new Parameter { parameter = "@FromDate", length = 0, type = "datetime", value = searchInput.FromDate });
            parameters.Add(new Parameter { parameter = "@ToDate", length = 0, type = "datetime", value = searchInput.ToDate });
            DAStoreEcommerce.Statistical.GetListProductVerNew(parameters, out DataTable ds1);
            int i = 0;
            foreach (DataRow row in ds1.Rows)
            {
                StatisticalOutputDetail statisticalOutput = new StatisticalOutputDetail();
                statisticalOutput.STT = i + 1;
                i++;
                statisticalOutput.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
                statisticalOutput.UserName = row["Account"] == DBNull.Value ? "" : (string)row["Account"];
                statisticalOutput.Pay = row["Pay"] == DBNull.Value ? "" : (string)row["Pay"];
                statisticalOutput.TypePay = row["TypePay"] == DBNull.Value ? 0 : (int)row["TypePay"];
                statisticalOutput.Date = row["Date"] == DBNull.Value ? DateTime.Now : (DateTime)row["Date"];
                statisticalOutput.Status = row["Status"] == DBNull.Value ? "" : (string)row["Status"];
                statisticalOutput.StatusID = row["StatusID"] == DBNull.Value ? 0 : (int)row["StatusID"];
                statisticalOutput.Code = row["Code"] == DBNull.Value ? "" : (string)row["Code"];
                statisticalOutput.NameProduct = row["NameProduct"] == DBNull.Value ? "" : (string)row["NameProduct"];
                statisticalOutput.Price = row["Price"] == DBNull.Value ? 0 : (int)row["Price"];
                statisticalOutput.PriceShip = row["PriceShip"] == DBNull.Value ? 0 : (int)row["PriceShip"];
                statisticalOutput.Number = row["Number"] == DBNull.Value ? 0 : (int)row["Number"];
                statisticalOutput.Date = row["Date"] == DBNull.Value ? DateTime.Now : (DateTime)row["Date"];
                statisticalOutput.Size = row["Size"] == DBNull.Value ? "" : (string)row["Size"];
                statisticalOutput.Value = row["Value"] == DBNull.Value ? "" : (string)row["Value"];
                statisticalOutput.PictureLink = row["PictureLink"] == DBNull.Value ? "" : (string)row["PictureLink"];
                statisticalOutput.Address = row["Address"] == DBNull.Value ? "" : (string)row["Address"];
                statisticalOutput.ProvinceCode = row["ProvinceCode"] == DBNull.Value ? 0 : (int)row["ProvinceCode"];
                statisticalOutput.DistrictCode = row["DistrictCode"] == DBNull.Value ? 0 : (int)row["DistrictCode"];
                statisticalOutput.Pay = row["Pay"] == DBNull.Value ? "" : (string)row["Pay"];
                statisticalOutput.Status = row["Status"] == DBNull.Value ? "" : (string)row["Status"];
                statisticalOutput.Name = row["Name"] == DBNull.Value ? "" : (string)row["Name"];
                statisticalOutput.ProvinceName = listaddress.Find(x => x.ProvinceCode == statisticalOutput.ProvinceCode).AddressName;
                statisticalOutput.DistrictName = listaddress.Find(x => x.ProvinceCode == statisticalOutput.DistrictCode).AddressName;
                statisticalOutputs.Add(statisticalOutput);
            }
            return Ok(statisticalOutputs);
        }
        // Xem chi tiết đơn hàng
        [HttpPost("GetDetailProduct")]
        public IActionResult GetDetailProduct([FromBody] StatisticalIDetail searchInput)
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
            StatisticalOutputDetail statisticalOutput = new StatisticalOutputDetail();
            Parameter parameters = new Parameter() { parameter = "@ID", length = 0, type = "int", value = searchInput.ID };
            DAStoreEcommerce.Statistical.GetDetailProduct(parameters, out DataTable ds1);
            int i = 0;
            foreach (DataRow row in ds1.Rows)
            {               
                statisticalOutput.STT = i + 1;
                i++;
                statisticalOutput.Code = row["Code"] == DBNull.Value ? "" : (string)row["Code"];
                statisticalOutput.NameProduct = row["NameProduct"] == DBNull.Value ? "" : (string)row["NameProduct"];
                statisticalOutput.Price = row["Price"] == DBNull.Value ? 0 : (int)row["Price"];
                statisticalOutput.PriceShip = row["PriceShip"] == DBNull.Value ? 0 : (int)row["PriceShip"];
                statisticalOutput.Number = row["Number"] == DBNull.Value ? 0 : (int)row["Number"];
                statisticalOutput.Date = row["Date"] == DBNull.Value ? DateTime.Now : (DateTime)row["Date"];
                statisticalOutput.Size = row["Size"] == DBNull.Value ? "" : (string)row["Size"];
                statisticalOutput.Value = row["Value"] == DBNull.Value ? "" : (string)row["Value"];
                statisticalOutput.PictureLink = row["PictureLink"] == DBNull.Value ? "" : (string)row["PictureLink"];
                statisticalOutput.Address = row["Address"] == DBNull.Value ? "" : (string)row["Address"];
                statisticalOutput.ProvinceCode = row["ProvinceCode"] == DBNull.Value ? 0 : (int)row["ProvinceCode"];
                statisticalOutput.DistrictCode = row["DistrictCode"] == DBNull.Value ? 0 : (int)row["DistrictCode"];
                statisticalOutput.Pay = row["Pay"] == DBNull.Value ? "" : (string)row["Pay"];
                statisticalOutput.Status = row["Status"] == DBNull.Value ? "" : (string)row["Status"];
                statisticalOutput.Name = row["Name"] == DBNull.Value ? "" : (string)row["Name"];
                statisticalOutput.ProvinceName = listaddress.Find(x => x.ProvinceCode == statisticalOutput.ProvinceCode).AddressName;
                statisticalOutput.DistrictName = listaddress.Find(x => x.ProvinceCode == statisticalOutput.DistrictCode).AddressName;
            }
            return Ok(statisticalOutput);
        }       
        // New
        [HttpPost("GetListProductSearch")]
        public IActionResult GetListProductSearch([FromBody] StatisticalInput searchInput)
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
            List<StatisticalOutputDetail> statisticalOutputs = new List<StatisticalOutputDetail>();
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@TextSearch", length = 0, type = "nvarchar", value = searchInput.TextSearch });
            parameters.Add(new Parameter { parameter = "@Screen", length = 0, type = "int", value = searchInput.Screen });
            parameters.Add(new Parameter { parameter = "@StatusID", length = 0, type = "int", value = searchInput.StatusID });
            parameters.Add(new Parameter { parameter = "@FromDate", length = 0, type = "datetime", value = searchInput.FromDate });
            parameters.Add(new Parameter { parameter = "@ToDate", length = 0, type = "datetime", value = searchInput.ToDate });
            DAStoreEcommerce.Statistical.GetListProductVerNew(parameters, out DataTable ds1);
            int i = 0;
            foreach (DataRow row in ds1.Rows)
            {
                StatisticalOutputDetail statisticalOutput = new StatisticalOutputDetail();
                statisticalOutput.STT = i + 1;
                i++;
                statisticalOutput.ID = row["ID"] == DBNull.Value ? 0 : (int)row["ID"];
                statisticalOutput.UserName = row["Account"] == DBNull.Value ? "" : (string)row["Account"];
                statisticalOutput.Pay = row["Pay"] == DBNull.Value ? "" : (string)row["Pay"];
                statisticalOutput.TypePay = row["TypePay"] == DBNull.Value ? 0 : (int)row["TypePay"];
                statisticalOutput.Date = row["Date"] == DBNull.Value ? DateTime.Now : (DateTime)row["Date"];
                statisticalOutput.Status = row["Status"] == DBNull.Value ? "" : (string)row["Status"];
                statisticalOutput.StatusID = row["StatusID"] == DBNull.Value ? 0 : (int)row["StatusID"];
                statisticalOutput.Code = row["Code"] == DBNull.Value ? "" : (string)row["Code"];
                statisticalOutput.NameProduct = row["NameProduct"] == DBNull.Value ? "" : (string)row["NameProduct"];
                statisticalOutput.Price = row["Price"] == DBNull.Value ? 0 : (int)row["Price"];
                statisticalOutput.PriceShip = row["PriceShip"] == DBNull.Value ? 0 : (int)row["PriceShip"];
                statisticalOutput.Number = row["Number"] == DBNull.Value ? 0 : (int)row["Number"];
                statisticalOutput.Date = row["Date"] == DBNull.Value ? DateTime.Now : (DateTime)row["Date"];
                statisticalOutput.Size = row["Size"] == DBNull.Value ? "" : (string)row["Size"];
                statisticalOutput.Value = row["Value"] == DBNull.Value ? "" : (string)row["Value"];
                statisticalOutput.PictureLink = row["PictureLink"] == DBNull.Value ? "" : (string)row["PictureLink"];
                statisticalOutput.Address = row["Address"] == DBNull.Value ? "" : (string)row["Address"];
                statisticalOutput.ProvinceCode = row["ProvinceCode"] == DBNull.Value ? 0 : (int)row["ProvinceCode"];
                statisticalOutput.DistrictCode = row["DistrictCode"] == DBNull.Value ? 0 : (int)row["DistrictCode"];
                statisticalOutput.Pay = row["Pay"] == DBNull.Value ? "" : (string)row["Pay"];
                statisticalOutput.Status = row["Status"] == DBNull.Value ? "" : (string)row["Status"];
                statisticalOutput.Name = row["Name"] == DBNull.Value ? "" : (string)row["Name"];
                statisticalOutput.ProvinceName = listaddress.Find(x => x.ProvinceCode == statisticalOutput.ProvinceCode).AddressName;
                statisticalOutput.DistrictName = listaddress.Find(x => x.ProvinceCode == statisticalOutput.DistrictCode).AddressName;
                statisticalOutputs.Add(statisticalOutput);
            }
            return Ok(statisticalOutputs);
        }
        [HttpPost("GetTotal")]
        public IActionResult GetTotal([FromBody] GetTotalInput  getTotalInput)
        {
            GetTotalOutput getTotalOutput = new GetTotalOutput();
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { parameter = "@IsBuy", length = 0, type = "int", value = getTotalInput.IsBuy });
            parameters.Add(new Parameter { parameter = "@Screen", length = 0, type = "int", value = getTotalInput.Screen });
            DAStoreEcommerce.Statistical.GetTotal(parameters, out DataTable ds);
            foreach (DataRow row in ds.Rows)
            {
                getTotalOutput.Total = row["Total"] == DBNull.Value ? 0 : (int)row["Total"];
            }
            return Ok(getTotalOutput);
        }
        [HttpGet("GetAccounTotal")]
        public IActionResult GetAccounTotal()
        {
            List<GetAccountTotal> getTotalOutputs = new List<GetAccountTotal>();
            DAStoreEcommerce.Statistical.GetAccountTotal(out DataTable ds);
            foreach (DataRow row in ds.Rows)
            {
                GetAccountTotal getTotalOutput = new GetAccountTotal();
                getTotalOutput.NumberBuy = row["NumberBuy"] == DBNull.Value ? 0 : (int)row["NumberBuy"];
                getTotalOutput.Account = row["Account"] == DBNull.Value ? "" : (string)row["Account"];
                getTotalOutputs.Add(getTotalOutput);
            }
            return Ok(getTotalOutputs);
        }
        // Get ra khách hàng mua nhiều tiền nhất
        [HttpGet("GetAccounTotalMoney")]
        public IActionResult GetAccounTotalMoney()
        {
            List<GetAccountTotal> getTotalOutputs = new List<GetAccountTotal>();
            DAStoreEcommerce.Statistical.GetAccountTotalMoney(out DataTable ds);
            foreach (DataRow row in ds.Rows)
            {
                GetAccountTotal getTotalOutput = new GetAccountTotal();
                getTotalOutput.NumberBuy = row["NumberBuy"] == DBNull.Value ? 0 : (int)row["NumberBuy"];
                getTotalOutput.Price = row["Total"] == DBNull.Value ? 0 : (int)row["Total"];
                getTotalOutput.Account = row["Account"] == DBNull.Value ? "" : (string)row["Account"];
                getTotalOutputs.Add(getTotalOutput);
            }
            return Ok(getTotalOutputs);
        }
    }
}
