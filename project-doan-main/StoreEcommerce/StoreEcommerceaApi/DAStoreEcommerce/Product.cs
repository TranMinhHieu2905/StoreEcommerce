
using StoreEcommerceaApi.Database;
using System.Data;
using static StoreEcommerceaApi.Database.DbSQLUtils;

namespace StoreEcommerceaApi.DAStoreEcommerce
{
    public class Product
    {
        public static DataTable GetList(List<Parameter> parameter,out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Product_GetList", parameter, out ds);
        }
        public static DataTable GetListAdmin(List<Parameter> parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_ProductAdmin_GetList", parameter, out ds);
        }
        public static DataTable GetListDetail(Parameter parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_ProductAdmin_GetDetail", parameter, out ds);
        }
        public static DataTable GetImage(Parameter parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetOne("usp_Product_GetImage", parameter, out ds);
        }
        public static DataTable GetDetailProductbyCode(Parameter parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetOne("usp_Product_GetDetailProductbyCode", parameter, out ds);
        }
        public static DataTable GetListImage(Parameter parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetOne("usp_Product_GetListImage", parameter, out ds);
        }
        public static int Insert(List<Parameter> parameter)
        {
            DbSQLUtils insert = new DbSQLUtils();
            return insert.StoreResuftOutput("usp_Product_Insert", parameter);
        }
        public static int InsertNew(List<Parameter> parameter)
        {
            DbSQLUtils insert = new DbSQLUtils();
            return insert.StoreResuftOutput("usp_ProductNew_Insert", parameter);
        }
        public static int InsertIMG(List<Parameter> parameter)
        {
            DbSQLUtils insert = new DbSQLUtils();
            return insert.StoreResuftOutput("usp_ImageProduct_Insert", parameter);

        }
        public static int InsertColor(List<Parameter> parameter)
        {
            DbSQLUtils insert = new DbSQLUtils();
            return insert.StoreResuftOutput("usp_Product_InsertColor", parameter);
        }
        public static int InsertProperties(List<Parameter> parameter)
        {
            DbSQLUtils insert = new DbSQLUtils();
            return insert.StoreResuftOutput("usp_Product_InsertProperties", parameter);
        }
        public static int Update(List<Parameter> parameter)
        {
            DbSQLUtils update = new DbSQLUtils();
            return update.StoreResuftOutput("usp_Product_Update", parameter);
        }
        public static int Delete(Parameter parameter)
        {
            DbSQLUtils delete = new DbSQLUtils();
            return delete.StoreResuftOutput("usp_Product_DeletebyID", parameter);
        }
        public static int DeleteImage(Parameter parameter)
        {
            DbSQLUtils delete = new DbSQLUtils();
            return delete.StoreResuftOutput("usp_Image_Delete", parameter);
        }
        public static DataTable GetProductbyID(Parameter parameter, out DataTable ds)
        {
            DbSQLUtils getProductbyid = new DbSQLUtils();
            return getProductbyid.GetOne("usp_GetProductbyID", parameter, out ds);
        }
        public static DataTable GetListProductByID(List<Parameter> parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Product_GetListProductbyID", parameter, out ds);
        }
        public static DataTable GetListColor(Parameter parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetOne("usp_Product_GetListColor", parameter, out ds);
        }
        public static DataTable GetNumber(List<Parameter> parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Product_GetNumber", parameter, out ds);
        }
        public static DataTable GetSize(Parameter parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Product_GetSize", parameter, out ds);
        }
        public static DataTable GetPrice(Parameter parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Product_GetPrice", parameter, out ds);
        }
        public static DataTable GetOne(Parameter parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_ProductAdmin_GetOne", parameter, out ds);
        }
        public static DataTable GetListPrice(Parameter parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Product_GetListPrice",parameter, out ds);
        }
        public static int UpdateProduct(List<Parameter> parameter)
        {
            DbSQLUtils insert = new DbSQLUtils();
            return insert.StoreResuftOutput("usp_ProductAdmin_Update", parameter);
        }
        public static DataTable Random(Parameter parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Product_Random", parameter, out ds);
        }
        public static int SalePrice(List<Parameter> parameter)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.StoreResuftOutput("usp_ProductAdmin_Sale", parameter);
        }
        public static int DeleteProperties(Parameter parameter)
        {
            DbSQLUtils delete = new DbSQLUtils();
            return delete.StoreResuftOutput("usp_Properties_Delete", parameter);
        }
        public static int LikeProduct(List<Parameter> parameter)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.StoreResuftOutput("usp_Product_Like", parameter);
        }
        public static DataTable CheckLike(List<Parameter> parameter, out DataTable ds)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.GetList("usp_Product_CheckLike", parameter, out ds);
        }
        public static int InsertLike(List<Parameter> parameter)
        {
            DbSQLUtils getList = new DbSQLUtils();
            return getList.StoreResuftOutput("usp_Product_InsertLike", parameter);
        }
    }
}
