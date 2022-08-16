using StoreEcommerceaApi.Database;
using System.Data;
using static StoreEcommerceaApi.Database.DbSQLUtils;

namespace StoreEcommerceaApi.DAStoreEcommerce
{
    public class Tax
    {
        //public static DataTable GetList(List<Parameter> parameter, out DataTable ds)
        //{
        //    DbSQLUtils getList = new DbSQLUtils();
        //    return getList.GetList("usp_Tax_GetList", parameter, out ds);
        //}

        public static DataTable GetList(Parameter parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Tax_GetList", parameter, out ds);
        }
        public static int Delete(Parameter parameter)
        {
            DbSQLUtils delete = new DbSQLUtils();
            return delete.StoreResuftOutput("usp_Tax_DeletebyID", parameter);

        }
    }
}
