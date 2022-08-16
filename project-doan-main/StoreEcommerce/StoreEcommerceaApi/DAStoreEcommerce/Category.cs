using StoreEcommerceaApi.Database;
using System.Data;
using static StoreEcommerceaApi.Database.DbSQLUtils;


namespace StoreEcommerceaApi.DAStoreEcommerce
{
    public class Category
    {
        public static DataTable GetList(Parameter parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Category_GetList", parameter, out ds);
        }
        public static DataTable GetOne(Parameter parameter, out DataTable ds)
        {
            DbSQLUtils getone = new DbSQLUtils();
            return getone.GetOne("usp_Category_GetIDbyGuid", parameter, out ds);
        }
        public static DataTable GetListProductByID(List<Parameter> parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Product_GetListProductbyID", parameter, out ds);
        }
        public static int Delete(Parameter parameter)
        {
            DbSQLUtils delete = new DbSQLUtils();
            return delete.StoreResuftOutput("usp_Category_DeletebyID", parameter);
        }
        public static int Update(List<Parameter> parameter)
        {
            DbSQLUtils update = new DbSQLUtils();
            return update.StoreResuftOutput("usp_Category_Update", parameter);
        }
        public static int Insert(List<Parameter> parameter)
        {
            DbSQLUtils insert = new DbSQLUtils();
            return insert.StoreResuftOutput("usp_Category_Insert", parameter);
        }
        public static DataTable GetCategorybyID(Parameter parameter, out DataTable ds)
        {
            DbSQLUtils getCategorybyid = new DbSQLUtils();
            return getCategorybyid.GetOne("usp_GetCategorybyID", parameter, out ds);
        }
        public static DataTable GetCategoryID(out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Category_GetID", out ds);
        }
        public static DataTable GetListProductByCategoryID(List<Parameter> parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Product_GetListProductbyCategoryID", parameter, out ds);
        }

    }
}
