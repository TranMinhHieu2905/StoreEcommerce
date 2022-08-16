using StoreEcommerceaApi.Database;
using System.Data;
using static StoreEcommerceaApi.Database.DbSQLUtils;

namespace StoreEcommerceaApi.DAStoreEcommerce
{
    public class Address
    {
        public static DataTable GetList(out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Address_GetList", out ds);
        }
        public static DataTable GetListProvince(out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Address_GetListProvince", out ds);
        }
        public static DataTable GetListProvinceName(Parameter parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Address_GetListProductName", parameter,out ds);
        }
        public static DataTable GetListDistrict(out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Address_GetListDistrict", out ds);
        }
        public static DataTable GetListDistrictbyProvince(Parameter parameter,out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Address_GetListDistrictbyProvince", parameter, out ds);
        }
        public static int InsertDistrict(List<Parameter> parameter)
        {
            DbSQLUtils insert = new DbSQLUtils();
            return insert.StoreResuftOutput("usp_Address_InsertDistrictInProvince", parameter);
        }
        public static int DeleteProvince(Parameter parameter)
        {
            DbSQLUtils insert = new DbSQLUtils();
            return insert.StoreResuftOutput("usp_Address_DeleteProvince", parameter);
        }
        public static int InsertAdressNew(List<Parameter> parameter)
        {
            DbSQLUtils insert = new DbSQLUtils();
            return insert.StoreResuftOutput("usp_Address_InsertAddressNew", parameter);
        }
        public static DataTable GetListNew(Parameter parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Address_GetListNew", parameter, out ds);
        }
        public static DataTable GetListAdressbyID(Parameter parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Address_GetAdressbyID", parameter, out ds);
        }
        public static int UpdateSupplier(List<Parameter> parameter)
        {
            DbSQLUtils insert = new DbSQLUtils();
            return insert.StoreResuftOutput("usp_Address_UpdateSuplier", parameter);
        }
        public static int DeleteSupplier(Parameter parameter)
        {
            DbSQLUtils insert = new DbSQLUtils();
            return insert.StoreResuftOutput("usp_Supplier_Delete", parameter);
        }
        public static int InsertSupplier(List<Parameter> parameter)
        {
            DbSQLUtils insert = new DbSQLUtils();
            return insert.StoreResuftOutput("usp_Supplier_Insert", parameter);
        }
    }
}
