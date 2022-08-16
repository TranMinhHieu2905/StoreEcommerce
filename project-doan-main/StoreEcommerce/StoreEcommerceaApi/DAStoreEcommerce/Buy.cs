using StoreEcommerceaApi.Database;
using System.Data;
using static StoreEcommerceaApi.Database.DbSQLUtils;

namespace StoreEcommerceaApi.DAStoreEcommerce
{
    public class Buy
    {
        public static int Insert(List<Parameter> parameter)
        {
            DbSQLUtils insert = new DbSQLUtils();
            return insert.StoreResuftOutput("usp_Buy_Insert", parameter);
        }
        public static int DeleteProductAfterBuy(List<Parameter> parameter)
        {
            DbSQLUtils insert = new DbSQLUtils();
            return insert.StoreResuftOutput("usp_Buy_DeleteProductAfterBuy", parameter);
        }
        public static DataTable GetList(Parameter parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_UserBuy_GetList", parameter, out ds);
        }
    }
}
