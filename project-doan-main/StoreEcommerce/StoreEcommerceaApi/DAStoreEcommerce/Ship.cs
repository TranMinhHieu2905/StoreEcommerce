using StoreEcommerceaApi.Database;
using System.Data;
using static StoreEcommerceaApi.Database.DbSQLUtils;

namespace StoreEcommerceaApi.DAStoreEcommerce
{
    public class Ship
    {
        public static DataTable GetPricebyDistrictAndProvince(List<Parameter> parameter,out DataTable ds)
        {
            DbSQLUtils getone = new DbSQLUtils();
            return getone.GetList("usp_Ship_GetShipbyProvinceAndDistrict", parameter,out ds);
        }
        public static DataTable GetPricebyDistrictAndProvinceProductShip(List<Parameter> parameter, out DataTable ds)
        {
            DbSQLUtils getone = new DbSQLUtils();
            return getone.GetList("usp_Ship_GetShipbyProvinceAndDistrictProductShip", parameter, out ds);
        }
    }
}
