using System.Data;
using System.Data.SqlClient;

namespace StoreEcommerceaApi.Database
{
    public class DbSQLUtils
    {
        SqlConnection? sqlcon;
        SqlCommand? sqlcom;
        SqlDataReader? sqldr;
        SqlDataAdapter sqlda = new SqlDataAdapter();
        //string strcon = "Server=TRANMINHHIEU;Database=StoreEcommerce;Trusted_Connection=True;";
        string strcon = @"Data Source=DESKTOP-6HLOTS1;Initial Catalog=StoreEcommerce1;User ID=sa;Password=Anhhuy1j";
        public void OpenConnection()
        {
            sqlcon = new SqlConnection(strcon);
            if (sqlcon.State == System.Data.ConnectionState.Closed)
            {
                sqlcon.Open();
            }
        }
        public void CloseConnection()
        {
            sqlcon.Close();
        }

        public class Parameter
        {
            public string parameter { get; set; } = string.Empty;
            public string type { get; set; } = string.Empty;
            public int length { get; set; } = 0;
            public object value { get; set; } = string.Empty;
        }
        public class ParameterGuidId
        {
            public string parameter { get; set; } = string.Empty;
            public string type { get; set; } = string.Empty;
            public int length { get; set; } = 0;
            public Guid value { get; set; } = Guid.Empty;
        }
        public class ParameterOutput
        {
            public string paramOutput { get; set; } = string.Empty;
            public int paramOutput1 { get; set; } = 0;
        }
        public static SqlDbType Type(string name)
        {
            switch (name.ToLower())
            {
                case "date":
                    return SqlDbType.Date;
                case "datetime":
                    return SqlDbType.DateTime;
                case "decimal":
                    return SqlDbType.Decimal;
                case "int":
                    return SqlDbType.Int;
                case "varchar":
                    return SqlDbType.VarChar;
                case "nvarchar":
                    return SqlDbType.NVarChar;
                case "bit":
                    return SqlDbType.Bit;
                case "bigint":
                    return SqlDbType.BigInt;
                case "uniqueidentifier":
                    return SqlDbType.UniqueIdentifier;
                default:
                    return SqlDbType.VarChar;
            }
        }
        public bool InSert(string storeName, List<Parameter> parameters, out bool isSuccess)
        {
            try
            {
                int result = 0;
                isSuccess = false;
                OpenConnection();
                sqlcom = new SqlCommand(storeName, sqlcon);
                sqlcom.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (Parameter p in parameters)
                {
                    if (p.length > 0)
                        sqlcom.Parameters.Add(p.parameter, Type(p.type), p.length).Value = p.value;
                    else
                        sqlcom.Parameters.Add(p.parameter, Type(p.type)).Value = p.value;
                }
                result = sqlcom.ExecuteNonQuery();
                CloseConnection();
                isSuccess = true;
                return true;
            }
            catch (Exception)
            {
                isSuccess = false;
                throw;
            }
        }
        public DataSet GetList(string storeName, List<Parameter> parameters, out DataSet ds)
        {
            try
            {
                OpenConnection();
                sqlcom = new SqlCommand(storeName, sqlcon);
                sqlcom.CommandType = System.Data.CommandType.StoredProcedure;
                ds = new DataSet();
                foreach (Parameter p in parameters)
                {
                    if (p.length > 0)
                        sqlcom.Parameters.Add(p.parameter, Type(p.type), p.length).Value = p.value;
                    else
                        sqlcom.Parameters.Add(p.parameter, Type(p.type)).Value = p.value;
                    sqlda = new SqlDataAdapter(sqlcom);
                }
                sqlda.Fill(ds);
                CloseConnection();
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataSet GetOne(string storeName, Parameter parameter, out DataSet ds)
        {
            try
            {
                OpenConnection();
                sqlcom = new SqlCommand(storeName, sqlcon);
                sqlcom.CommandType = System.Data.CommandType.StoredProcedure;
                ds = new DataSet();
                sqlcom.Parameters.Add(parameter.parameter, Type(parameter.type)).Value = parameter.value;
                sqlda = new SqlDataAdapter(sqlcom);

                sqlda.Fill(ds);
                CloseConnection();
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable GetOne(string storeName, Parameter parameter, out DataTable ds)
        {
            try
            {
                OpenConnection();
                sqlcom = new SqlCommand(storeName, sqlcon);
                sqlcom.CommandType = System.Data.CommandType.StoredProcedure;
                ds = new DataTable();
                sqlcom.Parameters.Add(parameter.parameter, Type(parameter.type)).Value = parameter.value;
                sqlda = new SqlDataAdapter(sqlcom);

                sqlda.Fill(ds);
                CloseConnection();
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable GetList(string storeName, Parameter parameter, out DataTable ds)
        {
            try
            {
                OpenConnection();
                sqlcom = new SqlCommand(storeName, sqlcon);
                sqlcom.CommandType = System.Data.CommandType.StoredProcedure;
                ds = new DataTable();
                sqlcom.Parameters.Add(parameter.parameter, Type(parameter.type)).Value = parameter.value;
                sqlda = new SqlDataAdapter(sqlcom);

                sqlda.Fill(ds);
                CloseConnection();
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable GetList(string storeName, List<Parameter> parameters, out DataTable ds)
        {
            try
            {
                OpenConnection();
                sqlcom = new SqlCommand(storeName, sqlcon);
                sqlcom.CommandType = System.Data.CommandType.StoredProcedure;
                ds = new DataTable();
                foreach (Parameter p in parameters)
                {
                    if (p.length > 0)
                        sqlcom.Parameters.Add(p.parameter, Type(p.type), p.length).Value = p.value;
                    else
                        sqlcom.Parameters.Add(p.parameter, Type(p.type)).Value = p.value;
                    sqlda = new SqlDataAdapter(sqlcom);
                }
                sqlda.Fill(ds);
                CloseConnection();
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataSet GetList(string storeName, out DataSet ds)
        {
            OpenConnection();
            sqlcom = new SqlCommand(storeName, sqlcon);
            sqlcom.CommandType = System.Data.CommandType.StoredProcedure;
            sqlda = new SqlDataAdapter(sqlcom);
            ds = new DataSet();
            sqlda.Fill(ds);
            CloseConnection();
            return ds;
        }
        public DataTable GetList(string storeName, out DataTable ds)
        {
            OpenConnection();
            sqlcom = new SqlCommand(storeName, sqlcon);
            sqlcom.CommandType = System.Data.CommandType.StoredProcedure;
            sqlda = new SqlDataAdapter(sqlcom);
            ds = new DataTable();
            sqlda.Fill(ds);
            CloseConnection();
            return ds;
        }
        public string StoreResuftOutput(string storeName, List<Parameter> parameters, out string result)
        {
            result = "";
            OpenConnection();
            sqlcom = new SqlCommand(storeName, sqlcon);
            sqlcom.CommandType = CommandType.StoredProcedure;
            foreach (Parameter p in parameters)
            {
                if (p.length > 0)
                    sqlcom.Parameters.Add(p.parameter, Type(p.type), p.length).Value = p.value;
                else
                    sqlcom.Parameters.Add(p.parameter, Type(p.type)).Value = p.value;
            }
            sqlcom.Parameters.Add("@result", SqlDbType.NVarChar, 200).Direction = ParameterDirection.Output;

            sqlcom.ExecuteNonQuery();
            result = (string)sqlcom.Parameters["@result"].Value;
            CloseConnection();
            return result;

        }
        public int StoreResuftOutput(string storeName, List<Parameter> parameters)
        {         
            OpenConnection();
            sqlcom = new SqlCommand(storeName, sqlcon);
            sqlcom.CommandType = CommandType.StoredProcedure;
            foreach (Parameter p in parameters)
            {
                if (p.length > 0)
                    sqlcom.Parameters.Add(p.parameter, Type(p.type), p.length).Value = p.value;
                else
                    sqlcom.Parameters.Add(p.parameter, Type(p.type)).Value = p.value;
            }         
            sqlcom.ExecuteNonQuery();          
            CloseConnection();
            return 0; 
        }
        public int StoreResuftOutput(string storeName, Parameter parameters, out int result)
        {
            result = 0;
            OpenConnection();
            sqlcom = new SqlCommand(storeName, sqlcon);
            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.Parameters.Add(parameters.parameter, SqlDbType.UniqueIdentifier).Value = parameters.value;
            sqlcom.Parameters.Add("@result", SqlDbType.BigInt, 500).Direction = ParameterDirection.Output;

            sqlcom.ExecuteNonQuery();
            result = (int)sqlcom.Parameters["@result"].Value;
            CloseConnection();
            return result;
        }
        public int StoreResuftOutput(string storeName, Parameter parameters)
        {
            OpenConnection();
            sqlcom = new SqlCommand(storeName, sqlcon);
            sqlcom.CommandType = CommandType.StoredProcedure;
            if (parameters.length > 0)
                sqlcom.Parameters.Add(parameters.parameter, Type(parameters.type), parameters.length).Value = parameters.value;
            else
                sqlcom.Parameters.Add(parameters.parameter, Type(parameters.type)).Value = parameters.value;
            sqlcom.ExecuteNonQuery();         
            CloseConnection();
            return 0;
        }
        public string Delete(string storeName, List<Parameter> parameters)
        {
            string msg = "";
            OpenConnection();
            sqlcom = new SqlCommand(storeName, sqlcon);
            sqlcom.CommandType = CommandType.StoredProcedure;
            foreach (Parameter p in parameters)
            {
                if (p.length > 0)
                    sqlcom.Parameters.Add(p.parameter, Type(p.type), p.length).Value = p.value;
                else
                    sqlcom.Parameters.Add(p.parameter, Type(p.type)).Value = p.value;
            }
            sqlcom.ExecuteNonQuery();
            CloseConnection();
            return msg;
        }
        public ParameterOutput StoreResuftOutput(string storeName, List<Parameter> parameters, out ParameterOutput result1)
        {

            OpenConnection();
            sqlcom = new SqlCommand(storeName, sqlcon);
            sqlcom.CommandType = CommandType.StoredProcedure;
            foreach (Parameter p in parameters)
            {
                if (p.length > 0)
                    sqlcom.Parameters.Add(p.parameter, Type(p.type), p.length).Value = p.value;
                else
                    sqlcom.Parameters.Add(p.parameter, Type(p.type)).Value = p.value;
            }
            List<Parameter> parameter = new List<Parameter>();
            parameter.Add(new Parameter { parameter = "@resuft", length = 0, type = "nvarchar" });
            parameter.Add(new Parameter { parameter = "@resuft1", length = 0, type = "int" });
            foreach (Parameter p in parameter)
            {
                sqlcom.Parameters.Add(p.parameter, Type(p.type), 200).Direction = ParameterDirection.Output;
            }
            sqlcom.ExecuteNonQuery();
            result1 = new ParameterOutput();
            foreach (Parameter p in parameter)
            {

                if (p.type == "int")
                {
                    result1.paramOutput1 = (int)sqlcom.Parameters[p.parameter].Value;
                }
                else
                {
                    result1.paramOutput = (string)sqlcom.Parameters[p.parameter].Value;
                }
            }
            CloseConnection();
            return result1;

        }
        public int StoreResuftOutput(string storeName, List<Parameter> parameters, out int result)
        {
            result = 0;
            OpenConnection();
            sqlcom = new SqlCommand(storeName, sqlcon);
            sqlcom.CommandType = CommandType.StoredProcedure;
            foreach (Parameter p in parameters)
            {
                if (p.length > 0)
                    sqlcom.Parameters.Add(p.parameter, Type(p.type), p.length).Value = p.value;
                else
                    sqlcom.Parameters.Add(p.parameter, Type(p.type)).Value = p.value;
            }
            sqlcom.Parameters.Add("@result", SqlDbType.Int, 200).Direction = ParameterDirection.Output;

            sqlcom.ExecuteNonQuery();
            result = (int)sqlcom.Parameters["@result"].Value;
            CloseConnection();
            return result;
        }
        public long StoreResuftOutput(string storeName, ParameterGuidId parameters, out long result)
        {
            result = 0;
            OpenConnection();
            sqlcom = new SqlCommand(storeName, sqlcon);
            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.Parameters.Add(parameters.parameter, SqlDbType.UniqueIdentifier).Value = parameters.value;
            sqlcom.Parameters.Add("@result", SqlDbType.BigInt, 500).Direction = ParameterDirection.Output;

            sqlcom.ExecuteNonQuery();
            result = (Int64)sqlcom.Parameters["@result"].Value;
            CloseConnection();
            return result;
        }
        public string StoreResuftOutput(string storeName, ParameterGuidId parameters, out string result)
        {
            result = "";
            OpenConnection();
            sqlcom = new SqlCommand(storeName, sqlcon);
            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.Parameters.Add(parameters.parameter, SqlDbType.UniqueIdentifier).Value = parameters.value;
            sqlcom.Parameters.Add("@result", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;

            sqlcom.ExecuteNonQuery();
            result = (string)sqlcom.Parameters["@result"].Value;
            CloseConnection();
            return result;

        }
    }
}
