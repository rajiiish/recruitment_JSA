using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net;

namespace recruitment
{
    public partial class DashboardAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["s_adminuser"] != null) && (Session["s_adminpassword"] != null) )
            {
                if (!IsPostBack)
                {
                    TotalCount();
                    TotalCountPost();

                }
                //loaddataBadicinformation(); 
                //Response.Redirect("userlogin.aspx");
            }
            else
            {
                Response.Redirect("rms_admin.aspx");
            }
           
        }

       

        public  void TotalCount()
        {
            string vpostcode = DropDownList1.SelectedValue.ToString();
            string vsubmitted = SubmitteDrop.SelectedValue.ToString();

            string strQuery = "select * from basicdetailsNew";

            SqlConnection conn = MySqlConnection.Recruitmentcon();
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            cmd.Parameters.AddWithValue("@postcode", vpostcode);
            cmd.Parameters.AddWithValue("@vsubmitted", vsubmitted);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataSet dsData = new DataSet();
            sda.Fill(dsData);

            conn.Close();

            lblCount.Text = dsData.Tables[0].Rows.Count.ToString();
        }


        private void TotalCountPost()
        {
            string vpostcode = DropDownList1.SelectedValue.ToString();
            string vsubmitted = SubmitteDrop.SelectedValue.ToString();

            string strQuery1 = "select * from basicdetailsNew where postcode = @postcode";
            string strQuery2 = "select * from basicdetailsNew where postcode = @postcode AND IsCompleted='Yes' ";
            string strQuery3 = "select * from basicdetailsNew where postcode = @postcode AND IsCompleted='No'";

            SqlConnection conn = MySqlConnection.Recruitmentcon();
            SqlCommand cmd1 = new SqlCommand(strQuery1, conn);
            SqlCommand cmd2 = new SqlCommand(strQuery2, conn);
            SqlCommand cmd3 = new SqlCommand(strQuery3, conn);

            cmd1.Parameters.AddWithValue("@postcode", vpostcode);

            cmd2.Parameters.AddWithValue("@postcode", vpostcode);
            cmd2.Parameters.AddWithValue("@vsubmitted", vsubmitted);

            cmd3.Parameters.AddWithValue("@postcode", vpostcode);
            cmd3.Parameters.AddWithValue("@vsubmitted", vsubmitted);



            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
            SqlDataAdapter sda3 = new SqlDataAdapter(cmd3);

            DataSet dsData1 = new DataSet();
            DataSet dsData2 = new DataSet();
            DataSet dsData3 = new DataSet();

            sda1.Fill(dsData1);
            sda2.Fill(dsData2);
            sda3.Fill(dsData3);

            conn.Close();

            lblCount1.Text = dsData1.Tables[0].Rows.Count.ToString();
            lblCount2.Text = dsData2.Tables[0].Rows.Count.ToString();
            lblCount3.Text = dsData3.Tables[0].Rows.Count.ToString();
            Postcodelbl.Text = DropDownList1.SelectedItem.Text;


        }

        protected void Submitbtn_Click(object sender, EventArgs e)
        {

            TotalCountPost();
        }
    }
}