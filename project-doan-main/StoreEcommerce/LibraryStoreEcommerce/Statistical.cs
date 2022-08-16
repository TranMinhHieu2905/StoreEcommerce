using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStoreEcommerce
{
    public class Statistical
    {
        public string Code { get; set; } = string.Empty;
        public string NameProduct { get; set; } = string.Empty;
        public int Number { get; set; } = 0;
        public int Price { get; set; } = 0;
        public int ToTal { get; set; } = 0;

    }
    public class StatisticalOutputDetail
    {
        public int ID { get; set; } = 0;
        public string UserName { get; set; } = string.Empty;
        public int STT { get; set; } = 0;
        public string Code { get; set; } = string.Empty;
        public string NameProduct { get; set; } = string.Empty;
        public int Number { get; set; } = 0;
        public int Price { get; set; } = 0;
        public int PriceShip { get; set; } = 0;
        public string PictureLink { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public string DistrictName { get; set; } = string.Empty;
        public string ProvinceName { get; set; } = string.Empty;
        public int DistrictCode { get; set; } = 0;
        public int ProvinceCode { get; set; } = 0;
        public string Address { get; set; } = string.Empty;
        public string Pay { get; set; } = string.Empty;
        public int TypePay { get; set; } = 0;
        public string Status { get; set; } = string.Empty;
        public int StatusID { get; set; } = 0;
        public string Name { get; set; } = string.Empty;

    }
    public class StatisticalInput
    {
        public string TextSearch { get; set; } = string.Empty;
        public int Screen { get; set; } = 0;
        public int StatusID { get; set; } = 0;
        public DateTime FromDate { get; set; } = DateTime.Today.AddDays(-7);
        public DateTime ToDate { get; set; } = DateTime.Now;
    }
    public class StatisticalOutput
    {
        public int STT { get; set; } = 0;
        public int ID { get; set; } = 0;
        public string UserName { get; set; } = string.Empty;
        public string Pay { get; set; } = string.Empty;
        public int TypePay { get; set; } = 0;
        public string Status { get; set; } = string.Empty;
        public int StatusID { get; set; } = 0;
        public DateTime Date { get; set; } = DateTime.MinValue;
        public DateTime FromDate { get; set; } = DateTime.MinValue;
        public DateTime ToDate { get; set; } = DateTime.MinValue;
    }
    public class StatisticalStatusID
    {
        public int ID { get; set; } = 0;
        public int StatusID { get; set; } = 0;
    }
    public class StatisticalIDetail
    {
        public int ID { get; set; } = 0;
    }
    public class SendMail
    {
        public int IDMailPV { get; set; } = 0;
        public int PersonID { get; set; } = 0;
        public string PersonSend { get; set; } = string.Empty;
        public string PassPersonSend { get; set; } = string.Empty;
        public string PersonReceive { get; set; } = string.Empty;
        public string MailTitle { get; set; } = string.Empty;
        public string MailBody { get; set; } = string.Empty;
        public DateTime TimeSendMail { get; set; } = DateTime.Now;
        //public int MailTitleID { get; set; } = 0;
        //public int MailBodyID { get; set; } = 0;
        public int StatusMail { get; set; } = 0;
    }
    public class GetTotalInput
    {
        public int Screen { get; set; } = 0;
        public int IsBuy { get; set; } = 0;
    }
    public class GetTotalOutput
    {
        public int Total { get; set; } = 0;
    }
    public class GetAccountTotal
    {
        public int NumberBuy { get; set; } = 0;
        public string Account { get; set; } = string.Empty;
        public int Price { get; set; } = 0;
    }
}
