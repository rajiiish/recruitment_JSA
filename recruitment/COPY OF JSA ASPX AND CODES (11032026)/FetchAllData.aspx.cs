using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace recruitment
{
    public partial class FetchAllData : System.Web.UI.Page
    {
       SqlConnection connection = MySqlConnection.Recruitmentcon();

        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

            public class BasicInformation : FetchAllData
        {
            private DataTable dataTable = new DataTable();
            private DataSet dataSet = new DataSet();
            public BasicInformation()   {  }
            public string PullData()
            {
                string canregdbtest = "TA-IT-2001 ";//TextBox1.Text.ToString();
                    string query = "SELECT * FROM basicdetailsNew WHERE can_regno = @canregdbtest";
                    SqlCommand cmd = new SqlCommand(query, connection);
                 // connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@canregdbtest", canregdbtest);
                    da.Fill(dataSet);
                    connection.Close();
                    da.Dispose();

                        StringBuilder output = new StringBuilder();
                        foreach (DataRow rows in dataSet.Tables[0].Rows)
                        {
                            foreach (DataColumn col in dataSet.Tables[0].Columns)
                            {
                                output.AppendFormat("{0} ", rows[col]);
                            }

                            output.AppendLine();
                        }
                string resut = output.ToString();
                //  string str = dataSet.Tables[0].Rows.ToString();
                return output.ToString();

               
            }
        }

        protected void Submitbtn_Click(object sender, EventArgs e)
        {
            BasicInformation bs = new BasicInformation();
            resultlbl.Text = bs.PullData();
        }
    }
}