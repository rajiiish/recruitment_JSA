using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace recruitment


{
    public partial class connectiontest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection.Recruitmentcon();
                Label1.Text = "successful";
                
                
            }
            catch (Exception)
            {

                Label1.Text = "not successful";
            }
          
        }
    }
}