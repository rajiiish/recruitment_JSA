using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace recruitment
{
    public partial class position_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (!IsPostBack)
            if ((Session["email"] != null) && (Session["password"] != null))
            {
              regid();
               
                //Response.Redirect("userlogin.aspx");
            }
            else
            {
                Response.Redirect("userlogin.aspx");
            }

        }

        public int ApplicationNumber()
        {
            string postcode = PostDropDownList.SelectedValue.ToString();
            string postname = PostDropDownList.SelectedItem.ToString();
            int c = 0;

           
                SqlConnection connection = MySqlConnection.Recruitmentcon();

                SqlCommand cmd = new SqlCommand("SELECT JSA_GEN, JSA_FA, JSA_SP, STENO FROM appno ", connection);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da1.Fill(ds);
                //  string i = ds.Tables[0].Rows[0]["applicant_count"].ToString();
                string j = ds.Tables[0].Rows[0]["JSA_GEN"].ToString();
                string k = ds.Tables[0].Rows[0]["JSA_FA"].ToString();
                string l = ds.Tables[0].Rows[0]["JSA_SP"].ToString();
                string m = ds.Tables[0].Rows[0]["STENO"].ToString();


                if (PostDropDownList.SelectedIndex == 1)
                {
                    int a = Convert.ToInt32(j);
                     c = a + 1;

                    SqlCommand cmd1 = new SqlCommand("UPDATE appno SET JSA_GEN=JSA_GEN+1", connection);
                    cmd1.ExecuteNonQuery();

                }

            else if (PostDropDownList.SelectedIndex == 2)
            {
                int a = Convert.ToInt32(k);
                c = a + 1;
                SqlCommand cmd1 = new SqlCommand("UPDATE appno SET JSA_FA=JSA_FA+1", connection);
                cmd1.ExecuteNonQuery();

            }

            else if (PostDropDownList.SelectedIndex == 3)
            {
                int a = Convert.ToInt32(l);
                c = a + 1;
                SqlCommand cmd1 = new SqlCommand("UPDATE appno SET JSA_SP=JSA-SP+1", connection);
                cmd1.ExecuteNonQuery();

            }

            else if (PostDropDownList.SelectedIndex == 4)
            {
                int a = Convert.ToInt32(m);
                c = a + 1;
                SqlCommand cmd1 = new SqlCommand("UPDATE appno SET STENO=STENO+1", connection);
                cmd1.ExecuteNonQuery();
            }
            return c;
        }
        



        public void ApplicationPostIDCreation()
        {
            string postcode = PostDropDownList.SelectedValue.ToString();
            string postname = PostDropDownList.SelectedItem.ToString();
            try
            {               

                int x = ApplicationNumber();
                string newappno = postcode + "-" + x;

                string canregnobasic = regidlbl.Text;
                string vforignvisit = "No";
                string vexperieced = "No";

                string vunderbond= "No";
                string vcsirrelative = "No";

                string vsslc = "No";
                string vhsc = "No";
                string viti = "No";
                string vdip = "No";
                string vug = "No";
                string vpg = "No";
                string vphd = "No";
                string vgate = "No";
                string vExArmy = "No";
                string vPermentGovtStaff = "No";
                string vpwd = "No";
                string vcompleted = "No";

                string vrpub = "No";
                string vpat = "No";
                string vagerlx = "No";

                int vmarks = 0;

                string vno = "No";

                SqlConnection connection = MySqlConnection.Recruitmentcon();


               // SqlCommand cmd1 = new SqlCommand("UPDATE appno SET applicant_count=applicant_count+1", connection);

               // cmd1.ExecuteNonQuery();

                //for adding details in basicdetaisl table

                SqlConnection connection1 = MySqlConnection.Recruitmentcon();
                string sql2 = "Insert into basicdetailsNew(can_regno,postcode,postdetails,appregno, IsExperienced, IsForignVist,UnderBond,IsRelativeCSIR,SSLC,HSC,ITI,DIPLOMA,UG,PG,PHD,GATE,ExArmy,PermentGovtStaff,pwd,IsCompleted, IsResearchPub, IsPatent,AgeRelaxCatagory,SSLCPmarks,ITIPmarks,HSCPmarks,DIPLOMAPmarks,UGPmarks,PGPmarks)values(@canreg,@pcode,@postdetails,@appregno,@vexperieced,@vforignvisit,@vunderbond,@vcsirrelative,@vsslc,@vhsc,@viti,@vdip,@vug,@vpg,@vphd,@vgate,@vExArmy,@vPermentGovtStaff,@vpwd,@vcompleted,@vrpub,@vpat,@vagerlx,@vmarks,@vmarks,@vmarks,@vmarks,@vmarks,@vmarks)";
                string sql3 = "Insert into ExtraInfo(can_regno,appregno)values(@canreg,@appregno)";
                string sql4 = "Insert into ApplicationSteps(can_regno,appregno,BasicInfo,Education,Experienced,Profession,AdditionalInfo,Upload,AppFee)values(@canreg,@appregno,@vno,@vno,@vno,@vno,@vno,@vno,@vno)";
                string sql5 = "Insert into AddQualfications(can_regno,appregno)values(@canreg,@appregno)";


                SqlCommand cmd2 = new SqlCommand(sql2, connection1);
                SqlCommand cmd3 = new SqlCommand(sql3, connection1);
                SqlCommand cmd4 = new SqlCommand(sql4, connection1);
                SqlCommand cmd5 = new SqlCommand(sql5, connection1);

                cmd2.CommandType = CommandType.Text;
                cmd3.CommandType = CommandType.Text;
                cmd4.CommandType = CommandType.Text;
                cmd5.CommandType = CommandType.Text;

                cmd2.Parameters.AddWithValue("@canreg", canregnobasic);
                cmd3.Parameters.AddWithValue("@canreg", canregnobasic);
                cmd4.Parameters.AddWithValue("@canreg", canregnobasic);
                cmd5.Parameters.AddWithValue("@canreg", canregnobasic);

                cmd2.Parameters.AddWithValue("@pcode", postcode);

                cmd2.Parameters.AddWithValue("@appregno", newappno);
                cmd3.Parameters.AddWithValue("@appregno", newappno);
                cmd4.Parameters.AddWithValue("@appregno", newappno);
                cmd5.Parameters.AddWithValue("@appregno", newappno);

                cmd4.Parameters.AddWithValue("@vno", vno);

                cmd2.Parameters.AddWithValue("@postdetails", postname);

                cmd2.Parameters.AddWithValue("@vexperieced", vexperieced);
                cmd2.Parameters.AddWithValue("@vforignvisit", vforignvisit);
                cmd2.Parameters.AddWithValue("@vunderbond", vunderbond);
                cmd2.Parameters.AddWithValue("@vcsirrelative", vcsirrelative);


                cmd2.Parameters.AddWithValue("@vsslc", vsslc);
                cmd2.Parameters.AddWithValue("@vhsc", vhsc);
                cmd2.Parameters.AddWithValue("@viti", viti);
                cmd2.Parameters.AddWithValue("@vdip", vdip);
                cmd2.Parameters.AddWithValue("@vug", vug);
                cmd2.Parameters.AddWithValue("@vpg", vpg);
                cmd2.Parameters.AddWithValue("@vphd", vphd);
                cmd2.Parameters.AddWithValue("@vgate", vgate);

                cmd2.Parameters.AddWithValue("@vExArmy", vExArmy);
                cmd2.Parameters.AddWithValue("@vPermentGovtStaff",vPermentGovtStaff);
                cmd2.Parameters.AddWithValue("@vpwd", vpwd);
                cmd2.Parameters.AddWithValue("@vcompleted", vcompleted);
                cmd2.Parameters.AddWithValue("@vrpub", vrpub);
                cmd2.Parameters.AddWithValue("@vpat", vpat);
                cmd2.Parameters.AddWithValue("@vagerlx", vagerlx);
                cmd2.Parameters.AddWithValue("@vmarks", vmarks);





                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
                cmd5.ExecuteNonQuery();

                Response.Write("<script> alert ('Your are going to apply');</script>");
                Session["postname"] = PostDropDownList.SelectedItem.ToString();
                Session["S_appregno"] = newappno.ToString();

                Response.Redirect("Candidate_Home.aspx");

              //  Response.Redirect("BasicinformationADD.aspx");
                connection.Close();
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "');</script>");

                //  Response.Write("<script> alert ('" + ex.Message + "');</script>");

            }


        }


        public void regid()
        {
            regidlbl.Text = Convert.ToString(Session["can_regno"]);
            
        }
        private void CheckAlreadyApplied()
        {

            if (PostDropDownList.SelectedIndex == 0)
            {

                Response.Write("<script> alert ('Please Select Post From Dropdown to apply');</script>");

            }
            else
            {
                try
                {
                    string canregdbtest = Convert.ToString(Session["can_regno"]);

                    string postcode1 = PostDropDownList.SelectedValue.ToString();

                    SqlConnection connection = MySqlConnection.Recruitmentcon();
                    string sql1 = "SELECT * FROM basicdetailsNew WHERE can_regno = @canregdbtest and postcode = @postcode ";

                    SqlCommand command = new SqlCommand(sql1, connection);
                    command.Parameters.AddWithValue("@canregdbtest", canregdbtest);
                    command.Parameters.AddWithValue("@postcode", postcode1);
                    SqlDataReader dr;
                    dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {

                        Response.Write("<script> alert ('You already applied for the post, please submit / continue');</script>");
                    }

                    else
                    {
                        ApplicationPostIDCreation();
                    }
                    connection.Close();
                }




                catch (Exception ex)
                {
                    Response.Write("<script> alert ('" + ex.Message + "');</script>");

                }
            }
        }
        protected void applybtn_Click(object sender, EventArgs e)
        {
            CheckAlreadyApplied();

        }

        protected void PostDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PostDropDownList.SelectedIndex==0)
            {

                qualificationlable.Text = "Please Select Post to apply";
            }

            else if (PostDropDownList.SelectedIndex == 1)

            {

                qualificationlable.Text = "Ex-servicemen, JCO in Army or other Paramilitary Forces with minimum of five years experience in the work of security.";
            }

            else if (PostDropDownList.SelectedIndex == 2)

            {
                
                qualificationlable.Text = "Diploma in Electronics/Electronics & Communication/IT/Computer Science Engineering from a recognized institute.";
            }

            else if (PostDropDownList.SelectedIndex == 3)

            {

                qualificationlable.Text = "i)12th pass or equivalent graduation from a recognised college/ university <br/> ii) The typing speed must be 35W.P.M in English and 30 W.P.M in Hindi.";
            }
        }

        protected void ContinueApplication_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;


            Session["S_appregno"] = GridView1.Rows[rowindex].Cells[3].Text;
            Session["postname"] = GridView1.Rows[rowindex].Cells[2].Text;

            Response.Redirect("Candidate_Home.aspx");
          //  Response.Redirect("BasicinformationADD.aspx");
        }



        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //  int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;

          //  int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string nbps = e.Row.Cells[4].Text;

              //  string nbps = GridView1.Rows[rowindex].Cells[4].Text;

                if (nbps == "Yes")
                {
                    LinkButton btn = (LinkButton)e.Row.FindControl("ContinueApplication");
                    LinkButton pbtn = (LinkButton)e.Row.FindControl("PrintApplication");


                    btn.Enabled = false;
                    pbtn.Visible = true;

                    btn.ForeColor = System.Drawing.Color.Green;
                    btn.Text = "Application Submitted";


                }
                else
                {
                    LinkButton btn = (LinkButton)e.Row.FindControl("ContinueApplication");
                    LinkButton pbtn = (LinkButton)e.Row.FindControl("PrintApplication");

                    btn.Enabled = true;
                    pbtn.Visible = false;
                    //  btn.ForeColor = System.Drawing.Color.Red;

                }

            }


            //string Namecolumnvalue = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "csiremp"));

            //LinkButton lb1 = (LinkButton)e.Row.FindControl("ContinueApplication1");


            //if (Namecolumnvalue == "Yes")
            //{
            //    lb1.Visible = false;
            //}
        }

        protected void PrintApplication_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;


            Session["S_appregno"] = GridView1.Rows[rowindex].Cells[3].Text;
            Session["postname"] = GridView1.Rows[rowindex].Cells[2].Text;

            Response.Redirect("PreviewDetails.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }



    



}