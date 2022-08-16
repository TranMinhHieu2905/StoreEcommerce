using StoreEcommerceaApi.Database;
using System.Data;
using static StoreEcommerceaApi.Database.DbSQLUtils;

namespace StoreEcommerceaApi.DAStoreEcommerce
{
    public class Statistical
    {
        public static DataTable GetList(out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Statistical_GetList", out ds);
        }
        public static DataTable GetListProduct(List<Parameter> parameters,out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Statistical_GetListProduct", parameters, out ds);
        }
        public static int UpdateStatus(List<Parameter> parameter)
        {
            DbSQLUtils update = new DbSQLUtils();
            return update.StoreResuftOutput("usp_Statistical_UpdateStatus", parameter);
        }
        // Phần cũ , cái mới đuôi + NEW
        public static DataTable GetListProductbyStatusID(List<Parameter> parameters, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Statistical_GetListbyStatusID", parameters, out ds);
        }
        //
        public static DataTable GetDetailProduct(Parameter parameters, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_UserBuy_Detail", parameters, out ds);
        }
        public static DataTable GetListProductVerNew(List<Parameter> parameters, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Statistical_GetListProductNew", parameters, out ds);
        }
        public static DataTable GetListProductbyStatusIDNew(List<Parameter> parameters, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Statistical_GetListbyStatusIDNew", parameters, out ds);
        }
        public static DataTable GetTotal(List<Parameter> parameters, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Statistical_IsBuy", parameters, out ds);
        }
        public static DataTable GetAccountTotal( out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Statistical_GetAccountTotal", out ds);
        }
        public static DataTable GetAccountTotalMoney(out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Statistical_GetAccountTotalMoney", out ds);
        }
    }
}
