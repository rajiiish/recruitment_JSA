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

namespace recruitment
{
    public partial class FilterbyCast : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((Session["s_adminuser"] != null) && (Session["s_adminpassword"] != null))
            {
                if (!IsPostBack)
                {
                    if (PostWiseGridView1.Rows.Count == 0)
                    {
                        ExportBtn.Visible = false;
                    }
                    else
                    {
                        ExportBtn.Visible = true;
                    }

                }
                //loaddataBadicinformation(); 
                //Response.Redirect("userlogin.aspx");
            }
            else
            {
                Response.Redirect("rms_admin.aspx");
            }


          
        }

        private void LoadRecordsByAll()
        {
            string vpostcode = DropDownList1.SelectedValue.ToString();
            string vsubmitted = SubmitteDrop.SelectedValue.ToString();


            {
                try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT appregno,fullname,fathername,dateofbirth,sexuality,cast,religion,csiremp,pwd,ExArmy,UnderBond,IsRelativeCSIR,SSLCPmarks,HSCPmarks,ITIPmarks,DIPLOMAPmarks,UGPmarks,PGPmarks,IsCompleted,IsShortlisted FROM basicdetailsNew WHERE postcode = @postcode And IsCompleted=@vsubmitted "))
                        {

                            cmd.Parameters.AddWithValue("@postcode", vpostcode);
                            cmd.Parameters.AddWithValue("@vsubmitted", vsubmitted);

                            using (SqlDataAdapter sda = new SqlDataAdapter())
                            {
                                cmd.Connection = conn;
                                sda.SelectCommand = cmd;

                                using (DataTable dt = new DataTable())
                                {
                                    sda.Fill(dt);
                                    PostWiseGridView1.DataSource = dt;
                                    PostWiseGridView1.DataBind();

                                }
                            }
                        }
                    }
                }

                catch (Exception ex)
                {

                    Response.Write("<script> alert ('" + ex.Message + "');</script>");
                    //  Response.Write("<script> alert ('No Record to Load');</script>");

                }

            }
        }

        private void LoadRecordsByCast()
        {
            string vpostcode = DropDownList1.SelectedValue.ToString();
            string vsubmitted = SubmitteDrop.SelectedValue.ToString();
            string vcast = CastListDrop.SelectedValue.ToString();


            {
                try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT appregno,fullname,fathername,dateofbirth,sexuality,cast,religion,csiremp,pwd,ExArmy,UnderBond,IsRelativeCSIR,SSLCPmarks,HSCPmarks,ITIPmarks,DIPLOMAPmarks,UGPmarks,PGPmarks,IsCompleted,IsShortlisted FROM basicdetailsNew WHERE postcode = @postcode And IsCompleted=@vsubmitted and  cast=@vcast"))
                        {

                            cmd.Parameters.AddWithValue("@postcode", vpostcode);
                            cmd.Parameters.AddWithValue("@vsubmitted", vsubmitted);
                            cmd.Parameters.AddWithValue("@vcast", vcast);

                            using (SqlDataAdapter sda = new SqlDataAdapter())
                            {
                                cmd.Connection = conn;
                                sda.SelectCommand = cmd;

                                using (DataTable dt = new DataTable())
                                {
                                    sda.Fill(dt);
                                    PostWiseGridView1.DataSource = dt;
                                    PostWiseGridView1.DataBind();

                                }
                            }
                        }
                    }
                }

                catch (Exception ex)
                {

                    Response.Write("<script> alert ('" + ex.Message + "');</script>");
                    //  Response.Write("<script> alert ('No Record to Load');</script>");

                }

            }
        }
        protected void Submitbtn_Click(object sender, EventArgs e)
        {
            if ((CastListDrop.SelectedIndex == 0))
                {
                LoadRecordsByAll();
                }
            else
                {
                LoadRecordsByCast();
                }

        }

        protected void ExportBtn_Click(object sender, EventArgs e)
        {
            
        }

        protected void CastListDrop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}