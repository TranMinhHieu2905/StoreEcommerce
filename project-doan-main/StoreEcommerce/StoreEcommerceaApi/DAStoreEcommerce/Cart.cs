using StoreEcommerceaApi.Database;
using System.Data;
using static StoreEcommerceaApi.Database.DbSQLUtils;

namespace StoreEcommerceaApi.DAStoreEcommerce
{
    public class Cart
    {
        public static int Insert(List<Parameter> parameter)
        {
            DbSQLUtils insert = new DbSQLUtils();
            return insert.StoreResuftOutput("usp_Cart_Insert", parameter);
        }
        public static int DeleteCart(Parameter parameter)
        {
            DbSQLUtils insert = new DbSQLUtils();
            return insert.StoreResuftOutput("usp_Cart_Delete", parameter);
        }
        public static int CheckExitsCart_InAccount(List<Parameter> parameter, out int ds)
        {
            DbSQLUtils insert = new DbSQLUtils();
            return insert.StoreResuftOutput("usp_Cart_CheckExitsCart_InAccount", parameter,out ds);
        }
        // List Cart Backup
        public static DataTable GetListCartbyAccount(Parameter parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Cart_GetList", parameter, out ds);
        }
        // List Cart Backup
        public static DataTable GetListCartbyAccountNew(Parameter parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Cart_GetListNew", parameter, out ds);
        }
        public static DataTable GetListCartNow(List<Parameter> parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Cart_BuyNow", parameter, out ds);
        }
        // Get List lại sau khi thay đổi địa chỉ
        public static DataTable GetListCartAfterChangeAdress(List<Parameter> parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Cart_GetListNewAfterAdress", parameter, out ds);
        }
    }
}
