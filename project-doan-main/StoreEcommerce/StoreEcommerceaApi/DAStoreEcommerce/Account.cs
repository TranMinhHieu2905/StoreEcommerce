using StoreEcommerceaApi.Database;
using System.Data;
using static StoreEcommerceaApi.Database.DbSQLUtils;


namespace StoreEcommerceaApi.DAStoreEcommerce
{
    public class Account
    {
        public static DataTable SellectLogin(List<Parameter> parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Account_GetList", parameter, out ds);
        }
        public static DataTable GetAddressByAccount(Parameter parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Account_GetAddressByAccount", parameter, out ds);
        }
        public static DataTable GetOne(Parameter parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Account_GetAccountDetailbyID", parameter, out ds);
        }
        public static int Update(List<Parameter> parameter)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.StoreResuftOutput("usp_Account_Update", parameter);
        }
        public static int Insert(List<Parameter> parameter)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.StoreResuftOutput("usp_Account_Insert", parameter);
        }
        public static int CheckAccount(List<Parameter> parameter,out int ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.StoreResuftOutput("usp_Account_CheckAccountExits", parameter,out ds);
        }
        public static DataTable GetListAccount(List<Parameter> parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Account_GetListAccount", parameter, out ds);
        }
        public static int Delete(Parameter parameter)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.StoreResuftOutput("usp_Account_Delete", parameter);
        }
        public static int RestoreUser(Parameter parameter)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.StoreResuftOutput("usp_Account_RestoreUser", parameter);
        }
        public static int UpdatePassword(List<Parameter> parameter)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.StoreResuftOutput("usp_Account_UpdateChangePassword", parameter);
        }
    }
}
