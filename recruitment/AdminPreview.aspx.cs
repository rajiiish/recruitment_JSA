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
    public partial class AdminPreview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gridviewload();

        }

        private void gridviewload()
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
                                    GridView1.DataSource = dt;
                                    GridView1.DataBind();

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



        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Update")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];  // row which u have created..
                string requestNo = row.Cells[0].Text;
                // similarly u can get all the values of the row..
                // u can do ur stuff here...

                testlbl.Text = requestNo;
            }

            if (e.CommandName == "") // other command names etc etc...
            { }

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string nbps = e.Row.Cells[18].Text;

                //  string nbps = GridView1.Rows[rowindex].Cells[4].Text;

                if (nbps == "Yes")
                {
                    LinkButton sbtn = (LinkButton)e.Row.FindControl("ShortlistLbtn1");
                    LinkButton rbtn = (LinkButton)e.Row.FindControl("NotEligibleBtn");

                    ImageButton rimgbtn = (ImageButton)e.Row.FindControl("rigthimgbtn");
                    ImageButton wrmgbtn = (ImageButton)e.Row.FindControl("wrnimgbtn");


                    sbtn.Enabled = false;
                    rimgbtn.Visible = true;
                    rbtn.Enabled = true;
                    wrmgbtn.Visible = false;
                  //  sbtn.ForeColor = System.Drawing.Color.Red;
                    

                    //  btn.ForeColor = System.Drawing.Color.Green;
                    // btn.Text = "yes";


                }
                else
                {
                    LinkButton sbtn = (LinkButton)e.Row.FindControl("ShortlistLbtn1");
                    LinkButton rbtn = (LinkButton)e.Row.FindControl("NotEligibleBtn");

                    ImageButton rimgbtn = (ImageButton)e.Row.FindControl("rigthimgbtn");
                    ImageButton wrmgbtn = (ImageButton)e.Row.FindControl("wrnimgbtn");


                    sbtn.Enabled = true;
                    rimgbtn.Visible = false;
                    rbtn.Enabled = false;
                    wrmgbtn.Visible = true;
                    rbtn.ForeColor = System.Drawing.Color.Red;

                }
            }
                //Change the Index number as per your Column
                if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell cell1 = e.Row.Cells[12];
                int sslc = int.Parse(cell1.Text);

                TableCell cell2 = e.Row.Cells[13];
                int hsc = int.Parse(cell2.Text);

                TableCell cell3 = e.Row.Cells[14];
                int dip = int.Parse(cell3.Text);

                TableCell cell4 = e.Row.Cells[15];
                int ug = int.Parse(cell4.Text);


                TableCell cell5 = e.Row.Cells[16];
                int pg = int.Parse(cell5.Text);

                //Add the condition check here
                if (e.Row.Cells[5].Text == "OBC") //ColumnValue is the value of your column at runtime
                {
                    e.Row.Cells[5].BackColor = System.Drawing.Color.Green;
                }
                else if (e.Row.Cells[5].Text == "ST")
                {
                    e.Row.Cells[5].BackColor = System.Drawing.Color.Blue;
                }

                else if (e.Row.Cells[5].Text == "SC")
                {
                    e.Row.Cells[5].BackColor = System.Drawing.Color.SkyBlue;
                }

                
                if (sslc < 60)
                {
                    e.Row.Cells[12].BackColor = System.Drawing.Color.Orange;
                }

               

                if (hsc < 60)
                {
                    e.Row.Cells[13].BackColor = System.Drawing.Color.Orange;
                }

               

                if (dip < 60)
                {
                    e.Row.Cells[14].BackColor = System.Drawing.Color.Orange;
                }

                if (ug < 60)
                {
                    e.Row.Cells[15].BackColor = System.Drawing.Color.Orange;
                }

                if (pg < 60)
                {
                    e.Row.Cells[16].BackColor = System.Drawing.Color.Orange;
                }
            }
        }

        protected void ExportExclBtn_Click(object sender, EventArgs e)
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

            GridView1.GridLines = GridLines.Both;
            GridView1.HeaderStyle.Font.Bold = true;
            GridView1.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();


        }
        public override void VerifyRenderingInServerForm(Control control)
        {
           
        }

        protected void Filterbtn_Click(object sender, EventArgs e)
        {
            int marks = Int32.Parse(markstxt.Text);
            string vpostcode = DropDownList1.SelectedValue.ToString();

            if (DropDownList2.SelectedValue== "sslc")
            { 
                           
                try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM basicdetailsNew WHERE SSLCPmarks >= @marks And postcode = @vpostcode"))
                        {

                            cmd.Parameters.AddWithValue("@marks", marks);
                            cmd.Parameters.AddWithValue("@vpostcode", vpostcode);

                            using (SqlDataAdapter sda = new SqlDataAdapter())
                            {
                                cmd.Connection = conn;
                                sda.SelectCommand = cmd;

                                using (DataTable dt = new DataTable())
                                {
                                    sda.Fill(dt);
                                    GridView1.DataSource = dt;
                                    GridView1.DataBind();
                                    int rowscount = GridView1.Rows.Count;

                                    for (int i = 0; i < rowscount; i++)
                                    {

                                        GridView1.Rows[i].Cells[12].BackColor = System.Drawing.Color.Pink;
                                         GridView1.Rows[i].Cells[5].BackColor = System.Drawing.Color.White;

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

           else if (DropDownList2.SelectedValue == "hsc")
            {

                try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM basicdetailsNew WHERE HSCPmarks >= @marks And postcode = @vpostcode"))
                        {

                            cmd.Parameters.AddWithValue("@marks", marks);
                            cmd.Parameters.AddWithValue("@vpostcode", vpostcode);

                            using (SqlDataAdapter sda = new SqlDataAdapter())
                            {
                                cmd.Connection = conn;
                                sda.SelectCommand = cmd;

                                using (DataTable dt = new DataTable())
                                {
                                    sda.Fill(dt);
                                    GridView1.DataSource = dt;
                                    GridView1.DataBind();

                                    int rowscount = GridView1.Rows.Count;

                                    for (int i = 0; i < rowscount; i++)
                                    {

                                        GridView1.Rows[i].Cells[13].BackColor = System.Drawing.Color.Pink;
                                        GridView1.Rows[i].Cells[5].BackColor = System.Drawing.Color.White;

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

            else if (DropDownList2.SelectedValue == "iti")
            {

                try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM basicdetailsNew WHERE ITIPmarks >= @marks And postcode = @vpostcode"))
                        {

                            cmd.Parameters.AddWithValue("@marks", marks);
                            cmd.Parameters.AddWithValue("@vpostcode", vpostcode);

                            using (SqlDataAdapter sda = new SqlDataAdapter())
                            {
                                cmd.Connection = conn;
                                sda.SelectCommand = cmd;

                                using (DataTable dt = new DataTable())
                                {
                                    sda.Fill(dt);
                                    GridView1.DataSource = dt;
                                    GridView1.DataBind();

                                    int rowscount = GridView1.Rows.Count;

                                    for (int i = 0; i < rowscount; i++)
                                    {

                                        GridView1.Rows[i].Cells[14].BackColor = System.Drawing.Color.Pink;
                                        GridView1.Rows[i].Cells[5].BackColor = System.Drawing.Color.White;

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
            else if (DropDownList2.SelectedValue == "dip")
            {

                try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM basicdetailsNew WHERE DIPLOMAPmarks >= @marks And postcode = @vpostcode"))
                        {

                            cmd.Parameters.AddWithValue("@marks", marks);
                            cmd.Parameters.AddWithValue("@vpostcode", vpostcode);

                            using (SqlDataAdapter sda = new SqlDataAdapter())
                            {
                                cmd.Connection = conn;
                                sda.SelectCommand = cmd;

                                using (DataTable dt = new DataTable())
                                {
                                    sda.Fill(dt);
                                    GridView1.DataSource = dt;
                                    GridView1.DataBind();

                                    int rowscount = GridView1.Rows.Count;

                                    for (int i = 0; i < rowscount; i++)
                                    {
                                       
                                            GridView1.Rows[i].Cells[15].BackColor = System.Drawing.Color.Pink;
                                        GridView1.Rows[i].Cells[5].BackColor = System.Drawing.Color.White;

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

            else if (DropDownList2.SelectedValue == "ug")
            {

                try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM basicdetailsNew WHERE UGPmarks >= @marks And postcode = @vpostcode"))
                        {

                            cmd.Parameters.AddWithValue("@marks", marks);
                            cmd.Parameters.AddWithValue("@vpostcode", vpostcode);

                            using (SqlDataAdapter sda = new SqlDataAdapter())
                            {
                                cmd.Connection = conn;
                                sda.SelectCommand = cmd;

                                using (DataTable dt = new DataTable())
                                {
                                    sda.Fill(dt);
                                    GridView1.DataSource = dt;
                                    GridView1.DataBind();

                                    int rowscount = GridView1.Rows.Count;

                                    for (int i = 0; i < rowscount; i++)
                                    {

                                        GridView1.Rows[i].Cells[16].BackColor = System.Drawing.Color.Pink;
                                        GridView1.Rows[i].Cells[5].BackColor = System.Drawing.Color.White;

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
            else if (DropDownList2.SelectedValue == "pg")
            {

                try
                {
                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM basicdetailsNew WHERE PGPmarks >= @marks And postcode = @vpostcode"))
                        {

                            cmd.Parameters.AddWithValue("@marks", marks);
                            cmd.Parameters.AddWithValue("@vpostcode", vpostcode);

                            using (SqlDataAdapter sda = new SqlDataAdapter())
                            {
                                cmd.Connection = conn;
                                sda.SelectCommand = cmd;

                                using (DataTable dt = new DataTable())
                                {
                                    sda.Fill(dt);
                                    GridView1.DataSource = dt;
                                    GridView1.DataBind();

                                    int rowscount = GridView1.Rows.Count;

                                    for (int i = 0; i < rowscount; i++)
                                    {

                                        GridView1.Rows[i].Cells[17].BackColor = System.Drawing.Color.Pink;
                                        GridView1.Rows[i].Cells[5].BackColor = System.Drawing.Color.White;


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

        protected void ShortlistLbtn_Click(object sender, EventArgs e)
        {

            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;


            appregnolbl1.Text = GridView1.Rows[rowindex].Cells[0].Text;

            ModalPopupExtender1.Show();
            
        }

        protected void FinalShortBtn_Click(object sender, EventArgs e)
        {
            
            
            string dbcanreg = canregno1.Text;

            string dbappno = appregnolbl1.Text;

            string yesno = "Yes";

            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {

                    string insertquery1 = "UPDATE basicdetailsNew SET IsShortlisted = @yesno WHERE appregno = @ddbappno";

                    SqlCommand cmd1 = new SqlCommand(insertquery1, conn);


                    cmd1.Parameters.AddWithValue("@yesno", yesno);




                    cmd1.Parameters.AddWithValue("@dcanreg", dbcanreg);
                    cmd1.Parameters.AddWithValue("@ddbappno", dbappno);

                    cmd1.ExecuteNonQuery();
                    gridviewload();
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
        }

        protected void RejecLinkClick_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;


            appregnolbl2.Text = GridView1.Rows[rowindex].Cells[0].Text;

            ModalPopupExtender2.Show();
            
        }

        protected void PopupFinalRejectBtn_Click(object sender, EventArgs e)
        {

            string dbcanreg = canregno1.Text;

            string dbappno = appregnolbl2.Text;

            string Shortyesno = "No";

            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {

                    string insertquery1 = "UPDATE basicdetailsNew SET IsShortlisted = @Shortyesno WHERE appregno = @ddbappno";

                    SqlCommand cmd1 = new SqlCommand(insertquery1, conn);
                    cmd1.Parameters.AddWithValue("@Shortyesno", Shortyesno);
                    cmd1.Parameters.AddWithValue("@dcanreg", dbcanreg);
                    cmd1.Parameters.AddWithValue("@ddbappno", dbappno);

                    cmd1.ExecuteNonQuery();
                    gridviewload();

                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
        }

        protected void PreviewClicklinbtn_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;

            appregnolbl3.Text = GridView1.Rows[rowindex].Cells[0].Text;

            ModalPopupExtender3.Show();
        }

        protected void SearchbyPost_Click(object sender, EventArgs e)
        {
            gridviewload();
        }
    }
       
}