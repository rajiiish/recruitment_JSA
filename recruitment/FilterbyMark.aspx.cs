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
    public partial class FilterbyMark : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["s_adminuser"] != null) && (Session["s_adminpassword"] != null))
            {
                if (!IsPostBack)
                {
                    if (!IsPostBack)
                    {
                        LoadRecordsByAll();
                        ExportBtn.Visible = false;
                        if (EducatonListDrop.SelectedIndex == 0)
                        {
                            markstxt.Visible = false;
                            Marklbl.Visible = false;
                            equlabl.Visible = false;
                            markstxt.Text = "";
                        }
                        else
                        {
                            markstxt.Visible = true;
                            Marklbl.Visible = true;
                            equlabl.Visible = true;
                        }
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
        private void FilterbyMarks()
        {
            double marks = Double.Parse(markstxt.Text);
            string vpostcode = DropDownList1.SelectedValue.ToString();
            string vsubmitted = SubmitteDrop.SelectedValue.ToString();


            if ((EducatonListDrop.SelectedValue == "sslc") && (!string.IsNullOrEmpty(markstxt.Text)))
            {

                try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM basicdetailsNew WHERE SSLCPmarks >= @marks And postcode = @vpostcode AND IsCompleted =@vsubmitted"))
                        {

                            cmd.Parameters.AddWithValue("@marks", marks);
                            cmd.Parameters.AddWithValue("@vpostcode", vpostcode);
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
                                    int rowscount = PostWiseGridView1.Rows.Count;

                                    for (int i = 0; i < rowscount; i++)
                                    {

                                        PostWiseGridView1.Rows[i].Cells[12].BackColor = System.Drawing.Color.Pink;
                                        PostWiseGridView1.Rows[i].Cells[5].BackColor = System.Drawing.Color.White;

                                    }

                                }
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    Response.Write("<script> alert ('" + ex.Message + "');</script>");

                }

            }

            else if ((EducatonListDrop.SelectedValue == "hsc") && (!string.IsNullOrEmpty(markstxt.Text)))
            {

                try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM basicdetailsNew WHERE HSCPmarks >= @marks And postcode = @vpostcode AND IsCompleted =@vsubmitted"))
                        {

                            cmd.Parameters.AddWithValue("@marks", marks);
                            cmd.Parameters.AddWithValue("@vpostcode", vpostcode);
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

                                    int rowscount = PostWiseGridView1.Rows.Count;

                                    for (int i = 0; i < rowscount; i++)
                                    {

                                        PostWiseGridView1.Rows[i].Cells[13].BackColor = System.Drawing.Color.Pink;
                                        PostWiseGridView1.Rows[i].Cells[5].BackColor = System.Drawing.Color.White;

                                    }

                                }
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    Response.Write("<script> alert ('" + ex.Message + "');</script>");

                }

            }

            else if ((EducatonListDrop.SelectedValue == "iti") && (!string.IsNullOrEmpty(markstxt.Text)))
            {

                try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM basicdetailsNew WHERE ITIPmarks >= @marks And postcode = @vpostcode AND IsCompleted =@vsubmitted"))
                        {

                            cmd.Parameters.AddWithValue("@marks", marks);
                            cmd.Parameters.AddWithValue("@vpostcode", vpostcode);
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

                                    int rowscount = PostWiseGridView1.Rows.Count;

                                    for (int i = 0; i < rowscount; i++)
                                    {

                                        PostWiseGridView1.Rows[i].Cells[14].BackColor = System.Drawing.Color.Pink;
                                        PostWiseGridView1.Rows[i].Cells[5].BackColor = System.Drawing.Color.White;

                                    }

                                }
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    Response.Write("<script> alert ('" + ex.Message + "');</script>");

                }

            }
            else if ((EducatonListDrop.SelectedValue == "dip") && (!string.IsNullOrEmpty(markstxt.Text)))
            {

                try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM basicdetailsNew WHERE DIPLOMAPmarks >= @marks And postcode = @vpostcode AND IsCompleted =@vsubmitted"))
                        {

                            cmd.Parameters.AddWithValue("@marks", marks);
                            cmd.Parameters.AddWithValue("@vpostcode", vpostcode);
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

                                    int rowscount = PostWiseGridView1.Rows.Count;

                                    for (int i = 0; i < rowscount; i++)
                                    {

                                        PostWiseGridView1.Rows[i].Cells[15].BackColor = System.Drawing.Color.Pink;
                                        PostWiseGridView1.Rows[i].Cells[5].BackColor = System.Drawing.Color.White;

                                    }
                                }
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    Response.Write("<script> alert ('" + ex.Message + "');</script>");

                }


            }

            else if ((EducatonListDrop.SelectedValue == "ug") && (!string.IsNullOrEmpty(markstxt.Text)))
            {

                try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM basicdetailsNew WHERE UGPmarks >= @marks And postcode = @vpostcode AND IsCompleted =@vsubmitted"))
                        {

                            cmd.Parameters.AddWithValue("@marks", marks);
                            cmd.Parameters.AddWithValue("@vpostcode", vpostcode);
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

                                    int rowscount = PostWiseGridView1.Rows.Count;

                                    for (int i = 0; i < rowscount; i++)
                                    {

                                        PostWiseGridView1.Rows[i].Cells[16].BackColor = System.Drawing.Color.Pink;
                                        PostWiseGridView1.Rows[i].Cells[5].BackColor = System.Drawing.Color.White;

                                    }
                                }
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    Response.Write("<script> alert ('" + ex.Message + "');</script>");

                }


            }
            else if ((EducatonListDrop.SelectedValue == "pg") && (!string.IsNullOrEmpty(markstxt.Text)))
            {

                try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM basicdetailsNew WHERE PGPmarks >= @marks And postcode = @vpostcode AND IsCompleted =@vsubmitted"))
                        {

                            cmd.Parameters.AddWithValue("@marks", marks);
                            cmd.Parameters.AddWithValue("@vpostcode", vpostcode);
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

                                    int rowscount = PostWiseGridView1.Rows.Count;

                                    for (int i = 0; i < rowscount; i++)
                                    {

                                        PostWiseGridView1.Rows[i].Cells[17].BackColor = System.Drawing.Color.Pink;
                                        PostWiseGridView1.Rows[i].Cells[5].BackColor = System.Drawing.Color.White;


                                    }
                                }
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    Response.Write("<script> alert ('" + ex.Message + "');</script>");

                }


            }

        }
        protected void Submitbtn_Click(object sender, EventArgs e)
        {
            if ((EducatonListDrop.SelectedIndex == 0 ) && (string.IsNullOrEmpty(markstxt.Text))) 
            {
                LoadRecordsByAll();
            }
            else if ((EducatonListDrop.SelectedIndex != 0) && (!string.IsNullOrEmpty(markstxt.Text)))
            {
                FilterbyMarks();
                
            }
                
        }

        protected void ExportBtn_Click(object sender, EventArgs e)
        {

        }

        protected void EducatonListDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EducatonListDrop.SelectedIndex ==0)
            {
                markstxt.Visible = false;
                Marklbl.Visible = false;
                equlabl.Visible = false;
                markstxt.Text = "";
            }

            else 
            {
                markstxt.Visible = true;
                Marklbl.Visible = true;
                equlabl.Visible = true;
            }
        }
    }
}