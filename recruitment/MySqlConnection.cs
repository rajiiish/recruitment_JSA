using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace recruitment

{
    public class MySqlConnection
    {

        public static SqlConnection Recruitmentcon()
        {
           
                //string connectionString = @"Data Source=DESKTOP-DPB8T2S\rajesh;Initial Catalog=projectasst;Integrated Security=true";
                string connectionString = ConfigurationManager.ConnectionStrings["onlineapplicationConnectionString1"].ConnectionString;

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            
            
        }
    }
}