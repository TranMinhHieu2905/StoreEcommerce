using StoreEcommerceaApi.Database;
using System.Data;
using static StoreEcommerceaApi.Database.DbSQLUtils;

namespace StoreEcommerceaApi.DAStoreEcommerce
{
    public class SystemKey
    {
        public static DataTable GetList(out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_SystemKey_GetList", out ds);
        }
        public static DataTable GetListProperties(out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_SystemKey_GetListProperties", out ds);
        }
        public static DataTable GetListTax(out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_SystemKey_GetListTax", out ds);
        }
        public static DataTable GetListDefault(Parameter parameter,out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Default_Value", parameter,out ds);
        }
        public static DataTable GetListSupplier(out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_SystemKey_GetListSupplier", out ds);
        }
        public static DataTable GetListSuppliers(Parameter parameter,out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Supplier_GetListSearch", parameter,out ds);
        }
        public static DataTable GetListTypeProduct(Parameter parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Product_TypeProduct", parameter, out ds);
        }
        public static int InsertType(List<Parameter> parameter)
        {
            DbSQLUtils insert = new DbSQLUtils();
            return insert.StoreResuftOutput("usp_Type_Insert", parameter);
        }
        public static int UpdateType(List<Parameter> parameter)
        {
            DbSQLUtils insert = new DbSQLUtils();
            return insert.StoreResuftOutput("usp_Type_Update", parameter);
        }
        public static int DeleteType(List<Parameter> parameter)
        {
            DbSQLUtils insert = new DbSQLUtils();
            return insert.StoreResuftOutput("usp_Type_Delete", parameter);
        }
    }
}
