using System;
using System.Configuration;
using System.Data.SqlClient;


namespace RoleBasedAccessControl_Authorization
{
    public class MyConnection
    {
        public SqlConnection con;
        public MyConnection()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["RBAC"].ConnectionString);
        }
        public static string type;
    }
}
