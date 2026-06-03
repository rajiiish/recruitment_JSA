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
    public partial class FilterbyPost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["s_adminuser"] != null) && (Session["s_adminpassword"] != null))
            {
                if (!IsPostBack)
                {
                    LoadRecordsByAll();
                    if (PostWiseGridView1.Rows.Count == 0)
                    {
                        ExportBtn.Visible = false;
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
                        using (SqlCommand cmd = new SqlCommand("SELECT appregno,fullname,fathername,dateofbirth,sexuality,cast,religion,csiremp,pwd,ExArmy,UnderBond,IsRelativeCSIR,SSLCPmarks,HSCPmarks,ITIPmarks,DIPLOMAPmarks,UGPmarks,PGPmarks,IsCompleted,IsShortlisted FROM basicdetailsNew WHERE postcode = @postcode"))
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

        private void LoadRecordsByApplicationSubmited()
        {
            string vpostcode = DropDownList1.SelectedValue.ToString();
            string vsubmitted = SubmitteDrop.SelectedValue.ToString();

            {
                try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT appregno,fullname,fathername,dateofbirth,sexuality,cast,religion,csiremp,pwd,ExArmy,UnderBond,IsRelativeCSIR,SSLCPmarks,HSCPmarks,ITIPmarks,DIPLOMAPmarks,UGPmarks,PGPmarks,IsCompleted,IsShortlisted FROM basicdetailsNew WHERE postcode = @postcode AND IsCompleted='Yes'"))
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

        private void LoadRecordsByApplicationNotSubmited()
        {
            string vpostcode = DropDownList1.SelectedValue.ToString();
            string vsubmitted = SubmitteDrop.SelectedValue.ToString();

            {
                try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT appregno,fullname,fathername,dateofbirth,sexuality,cast,religion,csiremp,pwd,ExArmy,UnderBond,IsRelativeCSIR,SSLCPmarks,HSCPmarks,ITIPmarks,DIPLOMAPmarks,UGPmarks,PGPmarks,IsCompleted,IsShortlisted FROM basicdetailsNew WHERE postcode = @postcode AND IsCompleted='No'"))
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
        protected void Submitbtn_Click(object sender, EventArgs e)
        {
            if (SubmitteDrop.SelectedValue == "All")
            {
                LoadRecordsByAll();
            }

            else if (SubmitteDrop.SelectedValue == "Yes")
            {
                LoadRecordsByApplicationSubmited();
            }
            else if (SubmitteDrop.SelectedValue == "No")
            {
                LoadRecordsByApplicationNotSubmited();
            }

            if (PostWiseGridView1.Rows.Count == 0)
            {
                ExportBtn.Visible = false;
            }
            else
            {
                ExportBtn.Visible = true;
            }
        }

        protected void ExportBtn_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "CMC_REC_" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);

            PostWiseGridView1.GridLines = GridLines.Both;
            PostWiseGridView1.HeaderStyle.Font.Bold = true;
            PostWiseGridView1.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}