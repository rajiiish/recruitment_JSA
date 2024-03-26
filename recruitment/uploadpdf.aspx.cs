using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;

namespace recruitment
{
    public partial class uploadpdf : System.Web.UI.Page
    {

        string smsg = "File Uploaded Successfully";
        string emsg = "Please first select a file to upload...";
        string pdfonly = "Only PDF Files are allowed to upload";
        string photoonly = "Only JPG Files are allowed to upload";
        string maxpdf = "Upload PDF file less then 2 MB size";
        string maxphoto = "Upload JPG file less then 1 MB size";
        string deletemsg = "You are already Deleted File from Server, Please upload again.";

        protected void Page_Load(object sender, EventArgs e)
        {

            if ((Session["email"] != null) && (Session["password"] != null) && (Session["can_regno"] != null) && (Session["S_appregno"] != null))
            {

                regid();
                SignPhotoLoad();
                SubmittedCheck();
                DisplayDocPreference();
                phottimelbl.Visible = false;
                signtimelbl.Visible = false;


                //  photo.ImageUrl = "~/files/" + regidlbl.Text.ToString() + "_PHOTO" + ".jpeg";

                //Response.Redirect("userlogin.aspx");
            }
            else
            {
                Response.Redirect("position_details.aspx");
            }

            if (!IsPostBack)
            {
                sscfileexitcheck();
                hscfileexitcheck();
                ITIfileexitcheck();
                DIPfileexitcheck();
                UGfileexitcheck();
                PGfileexitcheck();

                Communityfileexitcheck();
                Experiencefileexitcheck();
                ExServicemanfileexitcheck();
             //   NOCfileexitcheck();
                PWDfileexitcheck();
                
                photofileexitcheck();
                signfileexitcheck();
                //  photoload();
            }
        }

        private void SubmittedCheck()
        {
            try
            {

                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT IsCompleted FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        string isComp = dr.GetValue(0).ToString();
                       
                      
                        if (isComp == "Yes")
                        {
                            Response.Redirect("position_details.aspx");

                        }
                        
                    }
                }
               
            }


            catch (Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "');</script>");

            }
        }
        private void DisplayDocPreference()
        {
            try
            {

                string canregdbtext = Convert.ToString(Session["can_regno"]);

                string appregnotext = Convert.ToString(Session["S_appregno"]);



                SqlConnection connection = MySqlConnection.Recruitmentcon();
                string sql1 = "SELECT SSLC,HSC,ITI,DIPLOMA,UG,PG,PHD,IsExperienced,ExArmy,PermentGovtStaff,pwd, IsUploadComplete,cast FROM basicdetailsNew WHERE can_regno = @canregdbtest and appregno = @appregnotext ";

                SqlCommand command = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@canregdbtest", canregdbtext);
                command.Parameters.AddWithValue("@appregnotext", appregnotext);

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        string sslcyesno = dr.GetValue(0).ToString();
                        string HSCyesno = dr.GetValue(1).ToString();
                        string ITIyesno = dr.GetValue(2).ToString();
                        string DIPyesno = dr.GetValue(3).ToString();
                        string UGyesno = dr.GetValue(4).ToString();
                        string PGyesno = dr.GetValue(5).ToString();
                        string PHDyesno = dr.GetValue(6).ToString();

                    //    
                        string Experienceyesno = dr.GetValue(7).ToString();
                        string ExServicemanyesno = dr.GetValue(8).ToString();
                        string NOCyesno = dr.GetValue(9).ToString();
                        string PWDyesno = dr.GetValue(10).ToString();
                        string IsComplete = dr.GetValue(11).ToString();
                        string Communityyesno = dr.GetValue(12).ToString();
                        //if (IsComplete == "Yes")
                        //{
                        //    Response.Redirect("PreviewDetails.aspx");

                        //}



                        if (HSCyesno == "Yes")
                        {
                            HSCTableRow.Visible = true;

                        }
                        else if (HSCyesno == "No")
                        {

                            HSCTableRow.Visible = false;
                        }

                        if (ITIyesno == "Yes")
                        {
                            IITTableRow.Visible = true;

                        }
                        else if (ITIyesno == "No")
                        {

                            IITTableRow.Visible = false;
                        }
                        ////////////////////////////////////
                        if (DIPyesno == "Yes")
                        {
                            DIPTableRow.Visible = true;

                        }
                        else if (DIPyesno == "No")
                        {

                            DIPTableRow.Visible = false;
                        }
                        /////////////////////////////////
                        if (UGyesno == "Yes")
                        {
                            UGTableRow.Visible = true;

                        }
                        else if (UGyesno == "No")
                        {

                            UGTableRow.Visible = false;
                        }
                        ////////////////////////////////
                        if (PGyesno == "Yes")
                        {
                            PGTableRow.Visible = true;

                        }
                        else if (PGyesno == "No")
                        {

                            PGTableRow.Visible = false;
                        }



                        //if (PHDyesno == "Yes")
                        //{
                        //    PHDTableRow.Visible = true;

                        //}
                        //else if (UGyesno == "No")
                        //{

                        //    PHDTableRow.Visible = false;
                        //}

                        if ((Communityyesno == "SC") && (Communityyesno == "ST") && (Communityyesno == "OBC") && (Communityyesno == "EWS"))
                        {
                            CommunityTableRow.Visible = true;

                        }
                        else if (Communityyesno == "GENERAL")
                        {

                            CommunityTableRow.Visible = false;
                        }
                        //////////////////////////////
                        if (Experienceyesno == "Yes")
                        {
                            ExperienceTableRow.Visible = true;

                        }
                        else if (Experienceyesno == "No")
                        {

                            ExperienceTableRow.Visible = false;
                        }
                        ///////////////////////////
                        if (ExServicemanyesno == "Yes")
                        {
                            ExServicemanTableRow.Visible = true;

                        }
                        else if (ExServicemanyesno == "No")
                        {

                            ExServicemanTableRow.Visible = false;
                        }
                        /////////////////////////////////
                        if (NOCyesno == "Yes")
                        {
                            NOCTableRow.Visible = false;

                        }
                        else if (NOCyesno == "No")
                        {

                            NOCTableRow.Visible = false;
                        }
                        //////////////////////////////////
                        if (PWDyesno == "Yes")
                        {
                            PWDTableRow.Visible = true;

                        }
                        else if (PWDyesno == "No")
                        {

                            PWDTableRow.Visible = false;
                        }
                        
                    }
                }
                else
                {
                    // Response.Redirect("position_details.aspx");
                    // Response.Write("<script>alert('Invalid credentials');</script>");


                }
            }


            catch (Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "');</script>");

            }
        }
        public void SignPhotoLoad()
        {
            try
            {
                SqlConnection con = MySqlConnection.Recruitmentcon();

                SqlCommand cmd = new SqlCommand("SELECT photoid,signid FROM rec_canreg where can_regno= @rno ", con);

                string rno = regidlbl.Text;
                //  string apno = appidnolbl.Text;

                cmd.Parameters.AddWithValue("@rno", rno);
                // cmd.Parameters.AddWithValue("@apno", apno);

                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da1.Fill(ds);

                phottimelbl.Text = ds.Tables[0].Rows[0]["photoid"].ToString();
                signtimelbl.Text = ds.Tables[0].Rows[0]["signid"].ToString();
                con.Close();

            }
            catch (Exception ex)
            {

                Response.Write("<script> alert ('" + ex.Message + "');</script>");
            }

        }
        public void regid()
        {
            regidlbl.Text = Convert.ToString(Session["can_regno"]);

            appidnolbl.Text = Convert.ToString(Session["S_appregno"]);

            applyhpostlbl.Text = Convert.ToString(Session["postname"]);



        }

       

        protected void SSLC_btn_Click(object sender, EventArgs e)
        {
            string regno = regidlbl.Text;
            string sslc = "_SSLC";

            string newsslc = regno + sslc;


            string textmobile = newsslc;

            if (FileUpload1.HasFile == false)
            {
                // No file uploaded!
                Label1.Text = emsg;
            }

            else if (FileUpload1.HasFile)
            {
                int fileSize = FileUpload1.PostedFile.ContentLength;

                if (fileSize < 2100000)
                {  //==== Add Namespace System.IO

                    //==== Get file name without its extension.
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(FileUpload1.FileName);

                    //==== Get file extension.
                    string fileExtension = Path.GetExtension(FileUpload1.FileName);

                    //=== Now we have both file name and its extension seperately we can now eaisly rename file name.

                    //===== Adding some text in begining and end of the file name
                    //fileNameWithoutExtension = textmobile + fileNameWithoutExtension + textmobile;
                    //fileNameWithoutExtension = textmobile;

                    //===== Now lets upload the renamed file.

                    if (fileExtension == ".pdf")

                    //if (fileInfo.Length / 1048 > 20)
                    {

                        fileNameWithoutExtension = textmobile;
                        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/files/" + fileNameWithoutExtension + fileExtension));
                        Response.Redirect(Request.Url.AbsoluteUri);
                        Label1.Text = smsg;
                        Label1.ForeColor = System.Drawing.Color.Green;

                        sscfileexitcheck();

                        //   Label2.Text = string.Format(@"Uploaded file: {0}<br /> File size (in bytes): {1:N0}<br />  Content-type: {2}", FileUpload1.FileName,
                        //   FileUpload1.FileBytes.Length,
                        //FileUpload1.PostedFile.ContentType);

                    }

                    else
                    {
                        Label1.Text = pdfonly;
                    }

                    //  Label2.Text = "Your file was uploaded successfully.";

                }

                else
                {
                    Label1.Text = maxpdf;

                }
            }
        }

        protected void ssc_view_Click(object sender, EventArgs e)
        {


            string FilePath = Server.MapPath("files/" + regidlbl.Text.ToString() + "_SSLC" + ".pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        public void sscfileexitcheck()
        {
            string pdfname = Server.MapPath("~/files/" + regidlbl.Text.ToString() + "_SSLC" + ".pdf");
            ViewState["pdfname"] = pdfname;
            if (File.Exists(pdfname))
            {
                ssc_deletebtn.Visible = true;
                ssc_pdfview.Visible = true;
                FileUpload2.Visible = true;
                HSC_btn.Visible = true;
                FileUpload1.Enabled = false;
                SSLC_btn.Enabled = false;
                Label1.Text = "File Uploaded Sucessfully";
            }
            else
            {
                ssc_deletebtn.Visible = false;
                ssc_pdfview.Visible = false;
                FileUpload1.Enabled = true;
                SSLC_btn.Enabled = true;



                //  FileUpload2.Visible = false;
                // HSC_btn.Visible = false;

                // Label1.Text = "You are already Deleted File from Server, Please upload again.";

            }
        }

        public void hscfileexitcheck()
        {
            string pdfname = Server.MapPath("~/files/" + regidlbl.Text.ToString() + "_HSC" + ".pdf");
            ViewState["pdfname"] = pdfname;
            if (File.Exists(pdfname))
            {

                hsc_deletebtn.Visible = true;
                hsc_pdfview.Visible = true;
                FileUpload2.Visible = true;
                HSC_btn.Visible = true;
                FileUpload2.Enabled = false;
                HSC_btn.Enabled = false;
                Label2.Text = "File Uploaded Sucessfully";

            }
            else
            {
                hsc_deletebtn.Visible = false;
                hsc_pdfview.Visible = false;
                FileUpload2.Enabled = true;
                HSC_btn.Enabled = true;
                //  FileUpload2.Visible = false;
                // HSC_btn.Visible = false;

                // Label1.Text = "You are already Deleted File from Server, Please upload again.";

            }
        }

        public void ITIfileexitcheck()
        {
            string pdfname = Server.MapPath("~/files/" + regidlbl.Text.ToString() + "_ITI" + ".pdf");
            ViewState["pdfname"] = pdfname;
            if (File.Exists(pdfname))
            {

                ITI_deletebtn.Visible = true;
                ITI_pdfview.Visible = true;
                ITIFileUpload.Visible = true;
                ITI_btn.Visible = true;
                ITIFileUpload.Enabled = false;
                ITI_btn.Enabled = false;
                ITIlbl.Text = "File Uploaded Sucessfully";

            }
            else
            {
                ITI_deletebtn.Visible = false;
                ITI_pdfview.Visible = false;
                ITIFileUpload.Enabled = true;
                ITI_btn.Enabled = true;
                //  FileUpload2.Visible = false;
                // HSC_btn.Visible = false;

                // Label1.Text = "You are already Deleted File from Server, Please upload again.";

            }
        }
        public void DIPfileexitcheck()
        {
            string pdfname = Server.MapPath("~/files/" + regidlbl.Text.ToString() + "_DIP" + ".pdf");
            ViewState["pdfname"] = pdfname;
            if (File.Exists(pdfname))
            {

                DIP_deletebtn.Visible = true;
                DIP_pdfview.Visible = true;
                DIPFileUpload.Visible = true;
                DIP_btn.Visible = true;
                DIPFileUpload.Enabled = false;
                DIP_btn.Enabled = false;
                DIPlbl.Text = "File Uploaded Sucessfully";

            }
            else
            {
                DIP_deletebtn.Visible = false;
                DIP_pdfview.Visible = false;
                DIPFileUpload.Enabled = true;
                DIP_btn.Enabled = true;
                //  FileUpload2.Visible = false;
                // HSC_btn.Visible = false;

                // Label1.Text = "You are already Deleted File from Server, Please upload again.";

            }
        }

        public void UGfileexitcheck()
        {
            string pdfname = Server.MapPath("~/files/" + regidlbl.Text.ToString() + "_UG" + ".pdf");
            ViewState["pdfname"] = pdfname;
            if (File.Exists(pdfname))
            {

                UG_deletebtn.Visible = true;
                UG_pdfview.Visible = true;
                UGFileUpload.Visible = true;
                UG_btn.Visible = true;
                UGFileUpload.Enabled = false;
                UG_btn.Enabled = false;
                UGlbl.Text = "File Uploaded Sucessfully";

            }
            else
            {
                UG_deletebtn.Visible = false;
                UG_pdfview.Visible = false;
                UGFileUpload.Enabled = true;
                UG_btn.Enabled = true;
                //  FileUpload2.Visible = false;
                // HSC_btn.Visible = false;

                // Label1.Text = "You are already Deleted File from Server, Please upload again.";

            }
        }

        public void PGfileexitcheck()
        {
            string pdfname = Server.MapPath("~/files/" + regidlbl.Text.ToString() + "_PG" + ".pdf");
            ViewState["pdfname"] = pdfname;
            if (File.Exists(pdfname))
            {

                PG_deletebtn.Visible = true;
                PG_pdfview.Visible = true;
                PGFileUpload.Visible = true;
                PG_btn.Visible = true;
                PGFileUpload.Enabled = false;
                PG_btn.Enabled = false;
                PGlbl.Text = "File Uploaded Sucessfully";

            }
            else
            {
                PG_deletebtn.Visible = false;
                PG_pdfview.Visible = false;
                PGFileUpload.Enabled = true;
                PG_btn.Enabled = true;
                //  FileUpload2.Visible = false;
                // HSC_btn.Visible = false;

                // Label1.Text = "You are already Deleted File from Server, Please upload again.";

            }
        }

        public void Communityfileexitcheck()
        {
            string pdfname = Server.MapPath("~/files/" + regidlbl.Text.ToString() + "_Community" + ".pdf");
            ViewState["pdfname"] = pdfname;
            if (File.Exists(pdfname))
            {

                Community_deletebtn.Visible = true;
                Community_pdfview.Visible = true;
                CommunityFileUpload.Visible = true;
                Community_btn.Visible = true;
                CommunityFileUpload.Enabled = false;
                Community_btn.Enabled = false;
                Communitylbl.Text = "File Uploaded Sucessfully";

            }
            else
            {
                Community_deletebtn.Visible = false;
                Community_pdfview.Visible = false;
                CommunityFileUpload.Enabled = true;
                Community_btn.Enabled = true;
                //  FileUpload2.Visible = false;
                // HSC_btn.Visible = false;

                // Label1.Text = "You are already Deleted File from Server, Please upload again.";

            }
        }

        public void Experiencefileexitcheck()
        {
            string pdfname = Server.MapPath("~/files/" + regidlbl.Text.ToString() + "_Experience" + ".pdf");
            ViewState["pdfname"] = pdfname;
            if (File.Exists(pdfname))
            {

                Experience_deletebtn.Visible = true;
                Experience_pdfview.Visible = true;
                ExperienceFileUpload.Visible = true;
                Experience_btn.Visible = true;
                ExperienceFileUpload.Enabled = false;
                Experience_btn.Enabled = false;
                Experiencelbl.Text = "File Uploaded Sucessfully";

            }
            else
            {
                Experience_deletebtn.Visible = false;
                Experience_pdfview.Visible = false;
                ExperienceFileUpload.Enabled = true;
                Experience_btn.Enabled = true;
                //  FileUpload2.Visible = false;
                // HSC_btn.Visible = false;

                // Label1.Text = "You are already Deleted File from Server, Please upload again.";

            }
        }
        public void ExServicemanfileexitcheck()
        {
            string pdfname = Server.MapPath("~/files/" + regidlbl.Text.ToString() + "_ExServiceman" + ".pdf");
            ViewState["pdfname"] = pdfname;
            if (File.Exists(pdfname))
            {

                ExServiceman_deletebtn.Visible = true;
                ExServiceman_pdfview.Visible = true;
                ExServicemanFileUpload.Visible = true;
                ExServiceman_btn.Visible = true;
                ExServicemanFileUpload.Enabled = false;
                ExServiceman_btn.Enabled = false;
                ExServicemanlbl.Text = "File Uploaded Sucessfully";

            }
            else
            {
                ExServiceman_deletebtn.Visible = false;
                ExServiceman_pdfview.Visible = false;
                ExServicemanFileUpload.Enabled = true;
                ExServiceman_btn.Enabled = true;
                //  FileUpload2.Visible = false;
                // HSC_btn.Visible = false;

                // Label1.Text = "You are already Deleted File from Server, Please upload again.";

            }
        }

        public void NOCfileexitcheck()
        {
            string pdfname = Server.MapPath("~/files/" + regidlbl.Text.ToString() + "_NOC" + ".pdf");
            ViewState["pdfname"] = pdfname;
            if (File.Exists(pdfname))
            {

                NOC_deletebtn.Visible = true;
                NOC_pdfview.Visible = true;
                NOCFileUpload.Visible = true;
                NOC_btn.Visible = true;
                NOCFileUpload.Enabled = false;
                NOC_btn.Enabled = false;
                NOClbl.Text = "File Uploaded Sucessfully";

            }
            else
            {
                NOC_deletebtn.Visible = false;
                NOC_pdfview.Visible = false;
                NOCFileUpload.Enabled = true;
                NOC_btn.Enabled = true;
                //  FileUpload2.Visible = false;
                // HSC_btn.Visible = false;

                // Label1.Text = "You are already Deleted File from Server, Please upload again.";

            }
        }

        public void PWDfileexitcheck()
        {
            string pdfname = Server.MapPath("~/files/" + regidlbl.Text.ToString() + "_PWD" + ".pdf");
            ViewState["pdfname"] = pdfname;
            if (File.Exists(pdfname))
            {

                PWD_deletebtn.Visible = true;
                PWD_pdfview.Visible = true;
                PWDFileUpload.Visible = true;
                PWD_btn.Visible = true;
                PWDFileUpload.Enabled = false;
                PWD_btn.Enabled = false;
                PWDlbl.Text = "File Uploaded Sucessfully";

            }
            else
            {
                PWD_deletebtn.Visible = false;
                PWD_pdfview.Visible = false;
                PWDFileUpload.Enabled = true;
                PWD_btn.Enabled = true;
                //  FileUpload2.Visible = false;
                // HSC_btn.Visible = false;

                // Label1.Text = "You are already Deleted File from Server, Please upload again.";

            }
        }
        public void photofileexitcheck()
        {


            string photoname = Server.MapPath("~/files/photos/" + regidlbl.Text.ToString() + "_" + phottimelbl.Text.ToString() + "_PHOTO" + ".jpg");
            ViewState["photoname"] = photoname;
            if (File.Exists(photoname))
            {

                photo.ImageUrl = "~/files/photos/" + regidlbl.Text.ToString() + "_" + phottimelbl.Text.ToString() + "_PHOTO" + ".jpg";


                photo.Visible = true;
                photo_deletebtn.Visible = true;
                

                //SignUpload.Visible = true;
                //signaturebtn.Visible = true;

                PhotoUpload.Enabled = false;
                photobtn.Enabled = false;

                photosucesslbl.Text = "Photo Uploaded Sucessfully";

            }
            else
            {
                              
                photo_deletebtn.Visible = false;
                PhotoUpload.Enabled = true;
                photobtn.Enabled = true;
                photo.Visible = false;

                
            }
        }

        private void signfileexitcheck()
        {
            string signname = Server.MapPath("~/files/signatures/" + regidlbl.Text.ToString() + "_" + signtimelbl.Text.ToString() + "_SIGN" + ".jpg");
            ViewState["signname"] = signname;
            if (File.Exists(signname))
            {

                signature.ImageUrl = "~/files/signatures/" + regidlbl.Text.ToString() + "_" + signtimelbl.Text.ToString() + "_SIGN" + ".jpg";


                signature.Visible = true;
                sign_deletebtn.Visible = true;

               

                //FileUpload1.Visible = true;
                //SSLC_btn.Visible = true;


                SignUpload.Enabled = false;
                signaturebtn.Enabled = false;

                signsucesslbl.Text = "Signature Uploaded Sucessfully";

            }
            else
            {
                signature.Visible = false;
                sign_deletebtn.Visible = false;

                SignUpload.Enabled = true;
                signaturebtn.Enabled = true;
                
                               
            }
        }

        protected void ssc_pdfview_Click(object sender, ImageClickEventArgs e)
        {
            string FilePath = Server.MapPath("files/" + regidlbl.Text.ToString() + "_SSLC" + ".pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        protected void ssc_delete_Click(object sender, ImageClickEventArgs e)
        {
            string pdfname = Server.MapPath("~/files/" + regidlbl.Text.ToString() + "_SSLC" + ".pdf");
            ViewState["pdfname"] = pdfname;
            if (File.Exists(pdfname))
            {
                ssc_deletebtn.Visible = true;
                ssc_pdfview.Visible = true;

                File.Delete(pdfname);
                stepsCompleteDelete();

                sscfileexitcheck();
                Response.Redirect(Request.Url.AbsoluteUri);
                Label1.Text = "Upload only PDF ";
               
            }
            else
            {
                ssc_deletebtn.Visible = false;
                ssc_pdfview.Visible = false;

                Label1.Text = deletemsg;

            }
        }

        protected void hsc_pdfview_Click(object sender, ImageClickEventArgs e)
        {
            string FilePath = Server.MapPath("files/" + regidlbl.Text.ToString() + "_HSC" + ".pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        protected void hsc_deletebtn_Click(object sender, ImageClickEventArgs e)
        {
            string pdfname = Server.MapPath("~/files/" + regidlbl.Text.ToString() + "_HSC" + ".pdf");
            ViewState["pdfname"] = pdfname;
            if (File.Exists(pdfname))
            {
                
                hsc_deletebtn.Visible = true;
                hsc_pdfview.Visible = true;
                File.Delete(pdfname);
                stepsCompleteDelete();
                hscfileexitcheck();
                Response.Redirect(Request.Url.AbsoluteUri);
                Label2.Text = "Upload only PDF ";
                
            }
            else
            {
                hsc_deletebtn.Visible = false;
                hsc_pdfview.Visible = false;
                Label2.Text = deletemsg;

            }
        }

        protected void HSC_btn_Click(object sender, EventArgs e)
        {
            string regno = regidlbl.Text;
            string hsc = "_HSC";

            string newhsc= regno + hsc;


            string textmobile = newhsc;

            if (FileUpload2.HasFile == false)
            {
                // No file uploaded!
                Label2.Text = emsg;
            }

            else if (FileUpload2.HasFile)
            {
                int fileSize = FileUpload2.PostedFile.ContentLength;

                if (fileSize < 1100000)
                {  //==== Add Namespace System.IO

                    //==== Get file name without its extension.
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(FileUpload2.FileName);

                    //==== Get file extension.
                    string fileExtension = Path.GetExtension(FileUpload2.FileName);

                    //=== Now we have both file name and its extension seperately we can now eaisly rename file name.

                    //===== Adding some text in begining and end of the file name
                    //fileNameWithoutExtension = textmobile + fileNameWithoutExtension + textmobile;
                    //fileNameWithoutExtension = textmobile;

                    //===== Now lets upload the renamed file.

                    if (fileExtension == ".pdf")

                    //if (fileInfo.Length / 1048 > 20)
                    {

                        fileNameWithoutExtension = textmobile;
                        FileUpload2.PostedFile.SaveAs(Server.MapPath("~/files/" + fileNameWithoutExtension + fileExtension));
                        Response.Redirect(Request.Url.AbsoluteUri);
                        Label2.Text = smsg;
                        signsucesslbl.ForeColor = System.Drawing.Color.Green;

                        hscfileexitcheck();

                        //   Label2.Text = string.Format(@"Uploaded file: {0}<br /> File size (in bytes): {1:N0}<br />  Content-type: {2}", FileUpload1.FileName,
                        //   FileUpload1.FileBytes.Length,
                        //FileUpload1.PostedFile.ContentType);

                    }

                    else
                    {
                        Label2.Text = pdfonly;
                    }

                    //  Label2.Text = "Your file was uploaded successfully.";

                }

                else
                {
                    Label2.Text = maxpdf;

                }
            }
        }

        private void UploadCompleteCheck()
        {
            string dbcanreg = Convert.ToString(Session["can_regno"]);

            string dbappno = Convert.ToString(Session["S_appregno"]);

           string yesno = "Yes";

            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {

                    string insertquery1 = "UPDATE basicdetailsNew SET IsUploadComplete = @yesno WHERE appregno = @ddbappno";

                    SqlCommand cmd1 = new SqlCommand(insertquery1, conn);


                    cmd1.Parameters.AddWithValue("@yesno", yesno);




                    cmd1.Parameters.AddWithValue("@dcanreg", dbcanreg);
                    cmd1.Parameters.AddWithValue("@ddbappno", dbappno);

                    cmd1.ExecuteNonQuery();
                   
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert (" + ex.Message + "');</script>");
            }
        }

        private void stepsComplete()
        {
            string canregdbtest = Convert.ToString(Session["can_regno"]);
            string vappidnolbl = Convert.ToString(Session["S_appregno"]);
            string vyes = "Yes";
            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {


                    string insertquery = "Update ApplicationSteps SET Upload=@vyes WHERE appregno = @vappidnolbl and can_regno = @vcan_reg";

                    SqlCommand cmd = new SqlCommand(insertquery, conn);

                    cmd.Parameters.AddWithValue("@vcan_reg", canregdbtest);
                    cmd.Parameters.AddWithValue("@vappidnolbl", vappidnolbl);
                    cmd.Parameters.AddWithValue("@vyes", vyes);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "');</script>");
            }
        }

        private void stepsCompleteDelete()
        {
            string canregdbtest = Convert.ToString(Session["can_regno"]);
            string vappidnolbl = Convert.ToString(Session["S_appregno"]);
            string vno = "No";
            try
            {
                using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                {


                    string insertquery = "Update ApplicationSteps SET Upload=@vno WHERE appregno = @vappidnolbl and can_regno = @vcan_reg";

                    SqlCommand cmd = new SqlCommand(insertquery, conn);

                    cmd.Parameters.AddWithValue("@vcan_reg", canregdbtest);
                    cmd.Parameters.AddWithValue("@vappidnolbl", vappidnolbl);
                    cmd.Parameters.AddWithValue("@vno", vno);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "');</script>");
            }
        }

        protected void uploadcontinue_Click(object sender, EventArgs e)
        {
            if ((photo_deletebtn.Visible == false) && (photo.Visible == false))
            {
                Response.Write("<script> alert ('Upload Photo');</script>");
            }
            else if ((sign_deletebtn.Visible == false) && (signature.Visible == false))
            {
                Response.Write("<script> alert ('Upload Signature');</script>");
            }
            else if ((SSLCTableRow.Visible ==true) && (ssc_deletebtn.Visible==false))
            {             
                Response.Write("<script> alert ('Upload 10TH OR Equivalent Certificate');</script>");
            }

            else if ((HSCTableRow.Visible == true) && (hsc_deletebtn.Visible == false))
            {
                Response.Write("<script> alert ('Upload 12th or Equivalent Certificate');</script>");
            }

            else if ((IITTableRow.Visible == true) && (ITI_deletebtn.Visible == false))
            {
                Response.Write("<script> alert ('Upload ITI or Equivalent Certificate');</script>");
            }

            else if ((DIPTableRow.Visible == true) && (DIP_deletebtn.Visible == false))
            {
                Response.Write("<script> alert ('Upload DIPLOMA or Equivalent Certificate');</script>");
            }

            else if ((UGTableRow.Visible == true) && (UG_deletebtn.Visible == false))
            {
                Response.Write("<script> alert ('Upload UG or Equivalent Certificate');</script>");
            }

            else if ((PGTableRow.Visible == true) && (PG_deletebtn.Visible == false))
            {
                Response.Write("<script> alert ('Upload UG or Equivalent Certificate');</script>");
            }

            else if ((CommunityTableRow.Visible == true) && (Community_deletebtn.Visible == false))
            {
                Response.Write("<script> alert ('Upload Community Certificate');</script>");
            }

            else if ((ExperienceTableRow.Visible == true) && (Experience_deletebtn.Visible == false))
            {
                Response.Write("<script> alert ('Upload Experience Certificate');</script>");
            }

            else if ((ExServicemanTableRow.Visible == true) && (ExServiceman_deletebtn.Visible == false))
            {
                Response.Write("<script> alert ('Upload Ex-Serviceman Certificate');</script>");
            }

            else if ((NOCTableRow.Visible == true) && (NOC_deletebtn.Visible == false))
            {
                Response.Write("<script> alert ('Upload NOC Certificate');</script>");
            }

            else if ((PWDTableRow.Visible == true) && (PWD_deletebtn.Visible == false))
            {
                Response.Write("<script> alert ('Upload PWD Certificate');</script>");
            }

            else
            {
                UploadCompleteCheck();
                stepsComplete();
                Response.Redirect("candidate_Home.aspx");               
            }
        }

        protected void photobtn_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int RandomNumber = r.Next();


            string regno = regidlbl.Text;
            string underslalsh = "_";
            int photime = RandomNumber;
            string ph = "_PHOTO";

            string newph = regno + underslalsh + photime+ ph;


            string textmobile = newph;

            if (PhotoUpload.HasFile == false)
            {
                // No file uploaded!
                photosucesslbl.Text = emsg;
            }

            else if (PhotoUpload.HasFile)
            {
                int fileSize = PhotoUpload.PostedFile.ContentLength;

                if (fileSize < 1100000)
                {  //==== Add Namespace System.IO

                    //==== Get file name without its extension.
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(PhotoUpload.FileName);

                    //==== Get file extension.
                    string fileExtension = Path.GetExtension(PhotoUpload.FileName);

                    //=== Now we have both file name and its extension seperately we can now eaisly rename file name.

                    //===== Adding some text in begining and end of the file name
                    //fileNameWithoutExtension = textmobile + fileNameWithoutExtension + textmobile;
                    //fileNameWithoutExtension = textmobile;

                    //===== Now lets upload the renamed file.

                    if (fileExtension == ".jpg")

                    //if (fileInfo.Length / 1048 > 20)
                    {

                        fileNameWithoutExtension = textmobile;

                        PhotoUpload.PostedFile.SaveAs(Server.MapPath("~/files/photos/" + fileNameWithoutExtension + fileExtension));

                        //  Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);

                        photosucesslbl.Text = smsg;
                        photosucesslbl.ForeColor = System.Drawing.Color.Green;
                        phottimelbl.Text = photime.ToString();

                        //Response.Redirect(Request.RawUrl);
                        if (photo.Visible == false)
                        { 
                                    try
                                    {
                                        using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                                        {
                                            string insertquery = "Update rec_canreg SET photoid=@pid where can_regno=@canreg";
                                            SqlCommand cmd = new SqlCommand(insertquery, conn);

                                            cmd.Parameters.AddWithValue("@pid", photime);
                                            cmd.Parameters.AddWithValue("@canreg", regno);

                                            cmd.ExecuteNonQuery();
                                            conn.Close();

                                        }
                                    }

                                    catch (Exception ex)
                                    {
                                        Response.Write("<script> alert ('" + ex.Message + "');</script>");
                                    }


                        photofileexitcheck();
                        SignPhotoLoad();

                        //   Label2.Text = string.Format(@"Uploaded file: {0}<br /> File size (in bytes): {1:N0}<br />  Content-type: {2}", FileUpload1.FileName,
                        //   FileUpload1.FileBytes.Length,
                        //FileUpload1.PostedFile.ContentType);

                        }

                    else
                    {
                        photosucesslbl.Text = photoonly;
                    }
                }
                    //  Label2.Text = "Your file was uploaded successfully.";

                }

                else
                {
                    photosucesslbl.Text = maxphoto;

                }
            }
        }

      
        protected void photo_deletebtn_Click(object sender, ImageClickEventArgs e)
        {
            string photoname = Server.MapPath("~/files/photos/" + regidlbl.Text.ToString() + "_" + phottimelbl.Text.ToString() + "_PHOTO" + ".jpg");
            ViewState["photoname"] = photoname;
            if (File.Exists(photoname))
            {

                photo_deletebtn.Visible = true;
             //   photo_view.Visible = true;
                File.Delete(photoname);
                stepsCompleteDelete();
                Response.Redirect(Request.Url.AbsoluteUri);
                photo.ImageUrl = "~/files/noimage.jpg";
                photofileexitcheck();
                photosucesslbl.Text = "Upload only JPG Photo ";
               
                photo.Visible = false;

                
            }
            else
            {
                photo_deletebtn.Visible = false;
                //  photo_view.Visible = true;
                photosucesslbl.Text = deletemsg;
                
            }
        }

        protected void signatureupload_Click(object sender, EventArgs e)
        {
         //   if (!IsPostBack)
            {

                Random r = new Random();
                int RandomNumber = r.Next();


                string regno = regidlbl.Text;
                string underslalsh = "_";
                int signtime = RandomNumber;
                string ph = "_SIGN";

                string newph = regno + underslalsh  + signtime + ph;


                string textmobile = newph;

                if (SignUpload.HasFile == false)
                {
                    // No file uploaded!
                    signsucesslbl.Text = emsg;
                }

                else if (SignUpload.HasFile)
                {
                    int fileSize = SignUpload.PostedFile.ContentLength;

                    if (fileSize < 1100000)
                    {  //==== Add Namespace System.IO

                        //==== Get file name without its extension.
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(SignUpload.FileName);

                        //==== Get file extension.
                        string fileExtension = Path.GetExtension(SignUpload.FileName);

                        //=== Now we have both file name and its extension seperately we can now eaisly rename file name.

                        //===== Adding some text in begining and end of the file name
                        //fileNameWithoutExtension = textmobile + fileNameWithoutExtension + textmobile;
                        //fileNameWithoutExtension = textmobile;

                        //===== Now lets upload the renamed file.

                        if (fileExtension == ".jpg")

                        //if (fileInfo.Length / 1048 > 20)
                        {

                            fileNameWithoutExtension = textmobile;

                            SignUpload.PostedFile.SaveAs(Server.MapPath("~/files/signatures/" + fileNameWithoutExtension + fileExtension));

                            //  Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);

                            signsucesslbl.Text = smsg;
                            signsucesslbl.ForeColor = System.Drawing.Color.Green;
                            signtimelbl.Text = signtime.ToString();

                            //Response.Redirect(Request.RawUrl);

                            if (signature.Visible == false)
                            {
                                try
                                {
                                    using (SqlConnection conn = MySqlConnection.Recruitmentcon())
                                    {
                                        string insertquery = "Update rec_canreg SET signid=@sid where can_regno=@canreg";
                                        SqlCommand cmd = new SqlCommand(insertquery, conn);

                                        cmd.Parameters.AddWithValue("@sid", signtime);
                                        cmd.Parameters.AddWithValue("@canreg", regno);

                                        cmd.ExecuteNonQuery();
                                        conn.Close();

                                    }
                                }

                                catch (Exception ex)
                                {
                                    Response.Write("<script> alert ('" + ex.Message + "');</script>");
                                }


                                signfileexitcheck();
                                SignPhotoLoad();

                            }


                            else
                            {
                                signsucesslbl.Text = photoonly;
                            }
                        }
                        //  Label2.Text = "Your file was uploaded successfully.";

                    }

                    else
                    {
                        signsucesslbl.Text = maxphoto;

                    }
                }
            }
        }

        protected void sign_deletebtn_Click(object sender, ImageClickEventArgs e)
        {
            string signname = Server.MapPath("~/files/signatures/" + regidlbl.Text.ToString() + "_" + signtimelbl.Text.ToString() + "_SIGN" + ".jpg");
            ViewState["signname"] = signname;
            if (File.Exists(signname))
            {

                sign_deletebtn.Visible = true;
                //   photo_view.Visible = true;
                File.Delete(signname);
                stepsCompleteDelete();
                Response.Redirect(Request.Url.AbsoluteUri);
               
                signfileexitcheck();

                signsucesslbl.Text = "Upload only JPG Photo ";

                signature.Visible = false;
               
            }
            else
            {
                sign_deletebtn.Visible = false;
                //  photo_view.Visible = true;
                signsucesslbl.Text = deletemsg;

            }
        }

        protected void ITI_btn_Click(object sender, EventArgs e)
        {
            string regno = regidlbl.Text;
            string iti = "_ITI";
            string newiti = regno + iti;
            string textmobile = newiti;
            if (ITIFileUpload.HasFile == false)
            {
                // No file uploaded!
                ITIlbl.Text = emsg;
            }

            else if (ITIFileUpload.HasFile)
            {
                int fileSize = ITIFileUpload.PostedFile.ContentLength;

                if (fileSize < 1100000)
                {                     
                   string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(ITIFileUpload.FileName);                                 
                   string fileExtension = Path.GetExtension(ITIFileUpload.FileName);         

                    if (fileExtension == ".pdf")                   
                    {
                        fileNameWithoutExtension = textmobile;
                        ITIFileUpload.PostedFile.SaveAs(Server.MapPath("~/files/" + fileNameWithoutExtension + fileExtension));
                        Response.Redirect(Request.Url.AbsoluteUri);
                        ITIlbl.Text = smsg;
                        signsucesslbl.ForeColor = System.Drawing.Color.Green;
                        ITIfileexitcheck();
                    }
                    else
                    {
                        ITIlbl.Text = pdfonly;
                    }                                       

                }

                else
                {
                    ITIlbl.Text = maxpdf;
                }
            }
        }

        protected void ITI_pdfview_Click(object sender, EventArgs e)
        {
            string FilePath = Server.MapPath("files/" + regidlbl.Text.ToString() + "_ITI" + ".pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        protected void ITI_deletebtn_Click(object sender, EventArgs e)
        {
            string pdfname = Server.MapPath("~/files/" + regidlbl.Text.ToString() + "_ITI" + ".pdf");
            ViewState["pdfname"] = pdfname;
            if (File.Exists(pdfname))
            {

                ITI_deletebtn.Visible = true;
                ITI_pdfview.Visible = true;
                File.Delete(pdfname);
                stepsCompleteDelete();
                ITIfileexitcheck();
                Response.Redirect(Request.Url.AbsoluteUri);
                Label2.Text = "Upload only PDF ";
                
            }
            else
            {
                ITI_deletebtn.Visible = false;
                ITI_pdfview.Visible = false;
                Label2.Text = deletemsg;

            }
        }

        protected void DIP_btn_Click(object sender, EventArgs e)
        {
            string regno = regidlbl.Text;
            string DIP = "_DIP";
            string newDIP = regno + DIP;
            string textmobile = newDIP;
            if (DIPFileUpload.HasFile == false)
            {
                // No file uploaded!
                DIPlbl.Text = emsg;
            }

            else if (DIPFileUpload.HasFile)
            {
                int fileSize = DIPFileUpload.PostedFile.ContentLength;

                if (fileSize < 1100000)
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(DIPFileUpload.FileName);
                    string fileExtension = Path.GetExtension(DIPFileUpload.FileName);

                    if (fileExtension == ".pdf")
                    {
                        fileNameWithoutExtension = textmobile;
                        DIPFileUpload.PostedFile.SaveAs(Server.MapPath("~/files/" + fileNameWithoutExtension + fileExtension));
                        Response.Redirect(Request.Url.AbsoluteUri);
                        DIPlbl.Text = smsg;
                        signsucesslbl.ForeColor = System.Drawing.Color.Green;
                        DIPfileexitcheck();
                    }
                    else
                    {
                        DIPlbl.Text = pdfonly;
                    }

                }

                else
                {
                    DIPlbl.Text = maxpdf;
                }
            }
        }

        protected void DIP_pdfview_Click(object sender, EventArgs e)
        {
            string FilePath = Server.MapPath("files/" + regidlbl.Text.ToString() + "_DIP" + ".pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        protected void DIP_deletebtn_Click(object sender, EventArgs e)
        {
            string pdfname = Server.MapPath("~/files/" + regidlbl.Text.ToString() + "_DIP" + ".pdf");
            ViewState["pdfname"] = pdfname;
            if (File.Exists(pdfname))
            {

                DIP_deletebtn.Visible = true;
                DIP_pdfview.Visible = true;
                File.Delete(pdfname);
                stepsCompleteDelete();
                DIPfileexitcheck();
                Response.Redirect(Request.Url.AbsoluteUri);
                Label2.Text = "Upload only PDF ";
                
            }
            else
            {
                DIP_deletebtn.Visible = false;
                DIP_pdfview.Visible = false;
                Label2.Text = deletemsg;

            }
        }

        protected void UG_btn_Click(object sender, EventArgs e)
        {
            string regno = regidlbl.Text;
            string UG = "_UG";
            string newUG = regno + UG;
            string textmobile = newUG;
            if (UGFileUpload.HasFile == false)
            {
                // No file uploaded!
                UGlbl.Text = emsg;
            }

            else if (UGFileUpload.HasFile)
            {
                int fileSize = UGFileUpload.PostedFile.ContentLength;

                if (fileSize < 1100000)
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(UGFileUpload.FileName);
                    string fileExtension = Path.GetExtension(UGFileUpload.FileName);

                    if (fileExtension == ".pdf")
                    {
                        fileNameWithoutExtension = textmobile;
                        UGFileUpload.PostedFile.SaveAs(Server.MapPath("~/files/" + fileNameWithoutExtension + fileExtension));
                        Response.Redirect(Request.Url.AbsoluteUri);
                        UGlbl.Text = smsg;
                        signsucesslbl.ForeColor = System.Drawing.Color.Green;
                        UGfileexitcheck();
                    }
                    else
                    {
                        UGlbl.Text = pdfonly;
                    }

                }

                else
                {
                    UGlbl.Text = maxpdf;
                }
            }
        }

        protected void UG_pdfview_Click(object sender, EventArgs e)
        {
            string FilePath = Server.MapPath("files/" + regidlbl.Text.ToString() + "_UG" + ".pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        protected void UG_deletebtn_Click(object sender, EventArgs e)
        {
            string pdfname = Server.MapPath("~/files/" + regidlbl.Text.ToString() + "_UG" + ".pdf");
            ViewState["pdfname"] = pdfname;
            if (File.Exists(pdfname))
            {

                UG_deletebtn.Visible = true;
                UG_pdfview.Visible = true;
                File.Delete(pdfname);
                stepsCompleteDelete();
                UGfileexitcheck();
                Response.Redirect(Request.Url.AbsoluteUri);
                Label2.Text = "Upload only PDF ";
                
            }
            else
            {
                UG_deletebtn.Visible = false;
                UG_pdfview.Visible = false;
                Label2.Text = deletemsg;

            }
        }

        protected void PG_btn_Click(object sender, EventArgs e)
        {
            string regno = regidlbl.Text;
            string PG = "_PG";
            string newPG = regno + PG;
            string textmobile = newPG;
            if (PGFileUpload.HasFile == false)
            {
                // No file uploaded!
                PGlbl.Text = emsg;
            }

            else if (PGFileUpload.HasFile)
            {
                int fileSize = PGFileUpload.PostedFile.ContentLength;

                if (fileSize < 1100000)
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(PGFileUpload.FileName);
                    string fileExtension = Path.GetExtension(PGFileUpload.FileName);

                    if (fileExtension == ".pdf")
                    {
                        fileNameWithoutExtension = textmobile;
                        PGFileUpload.PostedFile.SaveAs(Server.MapPath("~/files/" + fileNameWithoutExtension + fileExtension));
                        Response.Redirect(Request.Url.AbsoluteUri);
                        PGlbl.Text = smsg;
                        signsucesslbl.ForeColor = System.Drawing.Color.Green;
                        PGfileexitcheck();
                    }
                    else
                    {
                        PGlbl.Text = pdfonly;
                    }

                }

                else
                {
                    PGlbl.Text = maxpdf;
                }
            }
        }

        protected void PG_pdfview_Click(object sender, EventArgs e)
        {
            string FilePath = Server.MapPath("files/" + regidlbl.Text.ToString() + "_PG" + ".pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        protected void PG_deletebtn_Click(object sender, EventArgs e)
        {
            string pdfname = Server.MapPath("~/files/" + regidlbl.Text.ToString() + "_PG" + ".pdf");
            ViewState["pdfname"] = pdfname;
            if (File.Exists(pdfname))
            {

                PG_deletebtn.Visible = true;
                PG_pdfview.Visible = true;
                File.Delete(pdfname);
                stepsCompleteDelete();
                PGfileexitcheck();
                Response.Redirect(Request.Url.AbsoluteUri);
                Label2.Text = "Upload only PDF ";
               
            }
            else
            {
                PG_deletebtn.Visible = false;
                PG_pdfview.Visible = false;
                Label2.Text = deletemsg;

            }
        }

        protected void PHD_btn_Click(object sender, EventArgs e)
        {

        }

        protected void PHD_pdfview_Click(object sender, EventArgs e)
        {
            string FilePath = Server.MapPath("files/" + regidlbl.Text.ToString() + "_SSLC" + ".pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        protected void PHD_deletebtn_Click(object sender, EventArgs e)
        {

        }

        protected void Community_btn_Click(object sender, EventArgs e)
        {
            string regno = regidlbl.Text;
            string Community = "_Community";
            string newCommunity = regno + Community;
            string textmobile = newCommunity;
            if (CommunityFileUpload.HasFile == false)
            {
                // No file uploaded!
                Communitylbl.Text = emsg;
            }

            else if (CommunityFileUpload.HasFile)
            {
                int fileSize = CommunityFileUpload.PostedFile.ContentLength;

                if (fileSize < 1100000)
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(CommunityFileUpload.FileName);
                    string fileExtension = Path.GetExtension(CommunityFileUpload.FileName);

                    if (fileExtension == ".pdf")
                    {
                        fileNameWithoutExtension = textmobile;
                        CommunityFileUpload.PostedFile.SaveAs(Server.MapPath("~/files/" + fileNameWithoutExtension + fileExtension));
                        Response.Redirect(Request.Url.AbsoluteUri);
                        Communitylbl.Text = smsg;
                        signsucesslbl.ForeColor = System.Drawing.Color.Green;
                        Communityfileexitcheck();
                    }
                    else
                    {
                        Communitylbl.Text = pdfonly;
                    }

                }

                else
                {
                    Communitylbl.Text = maxpdf;
                }
            }
        }

        protected void Community_pdfview_Click(object sender, EventArgs e)
        {
            string FilePath = Server.MapPath("files/" + regidlbl.Text.ToString() + "_Community" + ".pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        protected void Community_deletebtn_Click(object sender, EventArgs e)
        {
            string pdfname = Server.MapPath("~/files/" + regidlbl.Text.ToString() + "_Community" + ".pdf");
            ViewState["pdfname"] = pdfname;
            if (File.Exists(pdfname))
            {

                Community_deletebtn.Visible = true;
                Community_pdfview.Visible = true;
                File.Delete(pdfname);
                stepsCompleteDelete();
                Communityfileexitcheck();
                Response.Redirect(Request.Url.AbsoluteUri);
                Communitylbl.Text = "Upload only PDF ";
               
            }
            else
            {
                Community_deletebtn.Visible = false;
                Community_pdfview.Visible = false;
                Communitylbl.Text = deletemsg;

            }
        }

        protected void Experience_btn_Click(object sender, EventArgs e)
        {
            string regno = regidlbl.Text;
            string Experience = "_Experience";
            string newExperience = regno + Experience;
            string textmobile = newExperience;
            if (ExperienceFileUpload.HasFile == false)
            {
                // No file uploaded!
                Experiencelbl.Text = emsg;
            }

            else if (ExperienceFileUpload.HasFile)
            {
                int fileSize = ExperienceFileUpload.PostedFile.ContentLength;

                if (fileSize < 1100000)
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(ExperienceFileUpload.FileName);
                    string fileExtension = Path.GetExtension(ExperienceFileUpload.FileName);

                    if (fileExtension == ".pdf")
                    {
                        fileNameWithoutExtension = textmobile;
                        ExperienceFileUpload.PostedFile.SaveAs(Server.MapPath("~/files/" + fileNameWithoutExtension + fileExtension));
                        Response.Redirect(Request.Url.AbsoluteUri);
                        Experiencelbl.Text = smsg;
                        signsucesslbl.ForeColor = System.Drawing.Color.Green;
                        Experiencefileexitcheck();
                    }
                    else
                    {
                        Experiencelbl.Text = pdfonly;
                    }

                }

                else
                {
                    Experiencelbl.Text = maxpdf;
                }
            }
        }

        protected void Experience_pdfview_Click(object sender, EventArgs e)
        {
            string FilePath = Server.MapPath("files/" + regidlbl.Text.ToString() + "_Experience" + ".pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        protected void Experience_deletebtn_Click(object sender, EventArgs e)
        {
            string pdfname = Server.MapPath("~/files/" + regidlbl.Text.ToString() + "_Experience" + ".pdf");
            ViewState["pdfname"] = pdfname;
            if (File.Exists(pdfname))
            {

                Experience_deletebtn.Visible = true;
                Experience_pdfview.Visible = true;
                File.Delete(pdfname);
                Experiencefileexitcheck();
                stepsCompleteDelete();
                Response.Redirect(Request.Url.AbsoluteUri);
                Experiencelbl.Text = "Upload only PDF ";
                
            }
            else
            {
                Experience_deletebtn.Visible = false;
                Experience_pdfview.Visible = false;
                Experiencelbl.Text = deletemsg;

            }
        }

        protected void ExServiceman_btn_Click(object sender, EventArgs e)
        {
            string regno = regidlbl.Text;
            string ExServiceman = "_ExServiceman";
            string newExServiceman = regno + ExServiceman;
            string textmobile = newExServiceman;
            if (ExServicemanFileUpload.HasFile == false)
            {
                // No file uploaded!
                ExServicemanlbl.Text = emsg;
            }

            else if (ExServicemanFileUpload.HasFile)
            {
                int fileSize = ExServicemanFileUpload.PostedFile.ContentLength;

                if (fileSize < 1100000)
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(ExServicemanFileUpload.FileName);
                    string fileExtension = Path.GetExtension(ExServicemanFileUpload.FileName);

                    if (fileExtension == ".pdf")
                    {
                        fileNameWithoutExtension = textmobile;
                        ExServicemanFileUpload.PostedFile.SaveAs(Server.MapPath("~/files/" + fileNameWithoutExtension + fileExtension));
                        Response.Redirect(Request.Url.AbsoluteUri);
                        ExServicemanlbl.Text = smsg;
                        signsucesslbl.ForeColor = System.Drawing.Color.Green;
                        ExServicemanfileexitcheck();
                    }
                    else
                    {
                        ExServicemanlbl.Text = pdfonly;
                    }

                }

                else
                {
                    ExServicemanlbl.Text = maxpdf;
                }
            }
        }

        protected void ExServiceman_pdfview_Click(object sender, EventArgs e)
        {
            string FilePath = Server.MapPath("files/" + regidlbl.Text.ToString() + "_ExServiceman" + ".pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        protected void ExServiceman_deletebtn_Click(object sender, EventArgs e)
        {
            string pdfname = Server.MapPath("~/files/" + regidlbl.Text.ToString() + "_ExServiceman" + ".pdf");
            ViewState["pdfname"] = pdfname;
            if (File.Exists(pdfname))
            {

                ExServiceman_deletebtn.Visible = true;
                ExServiceman_pdfview.Visible = true;
                File.Delete(pdfname);
                stepsCompleteDelete();
                ExServicemanfileexitcheck();
                Response.Redirect(Request.Url.AbsoluteUri);
                ExServicemanlbl.Text = "Upload only PDF ";
               
            }
            else
            {
                ExServiceman_deletebtn.Visible = false;
                ExServiceman_pdfview.Visible = false;
                ExServicemanlbl.Text = deletemsg;

            }
        }

        protected void NOC_btn_Click(object sender, EventArgs e)
        {
            string regno = regidlbl.Text;
            string NOC = "_NOC";
            string newNOC = regno + NOC;
            string textmobile = newNOC;
            if (NOCFileUpload.HasFile == false)
            {
                // No file uploaded!
                NOClbl.Text = emsg;
            }

            else if (NOCFileUpload.HasFile)
            {
                int fileSize = NOCFileUpload.PostedFile.ContentLength;

                if (fileSize < 1100000)
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(NOCFileUpload.FileName);
                    string fileExtension = Path.GetExtension(NOCFileUpload.FileName);

                    if (fileExtension == ".pdf")
                    {
                        fileNameWithoutExtension = textmobile;
                        NOCFileUpload.PostedFile.SaveAs(Server.MapPath("~/files/" + fileNameWithoutExtension + fileExtension));
                        Response.Redirect(Request.Url.AbsoluteUri);
                        NOClbl.Text = smsg;
                        signsucesslbl.ForeColor = System.Drawing.Color.Green;
                        NOCfileexitcheck();
                    }
                    else
                    {
                        NOClbl.Text = pdfonly;
                    }

                }

                else
                {
                    NOClbl.Text = maxpdf;
                }
            }
        }

        protected void NOC_pdfview_Click(object sender, EventArgs e)
        {
            string FilePath = Server.MapPath("files/" + regidlbl.Text.ToString() + "_NOC" + ".pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        protected void NOC_deletebtn_Click(object sender, EventArgs e)
        {
            string pdfname = Server.MapPath("~/files/" + regidlbl.Text.ToString() + "_NOC" + ".pdf");
            ViewState["pdfname"] = pdfname;
            if (File.Exists(pdfname))
            {

                NOC_deletebtn.Visible = true;
                NOC_pdfview.Visible = true;
                File.Delete(pdfname);
                stepsCompleteDelete();
                NOCfileexitcheck();
                Response.Redirect(Request.Url.AbsoluteUri);
                NOClbl.Text = "Upload only PDF ";
                
            }
            else
            {
                NOC_deletebtn.Visible = false;
                NOC_pdfview.Visible = false;
                NOClbl.Text = deletemsg;

            }
        }

        protected void PWD_btn_Click(object sender, EventArgs e)
        {
            string regno = regidlbl.Text;
            string PWD = "_PWD";
            string newPWD = regno + PWD;
            string textmobile = newPWD;
            if (PWDFileUpload.HasFile == false)
            {
                // No file uploaded!
                PWDlbl.Text = emsg;
            }

            else if (PWDFileUpload.HasFile)
            {
                int fileSize = PWDFileUpload.PostedFile.ContentLength;

                if (fileSize < 1100000)
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(PWDFileUpload.FileName);
                    string fileExtension = Path.GetExtension(PWDFileUpload.FileName);

                    if (fileExtension == ".pdf")
                    {
                        fileNameWithoutExtension = textmobile;
                        PWDFileUpload.PostedFile.SaveAs(Server.MapPath("~/files/" + fileNameWithoutExtension + fileExtension));
                        Response.Redirect(Request.Url.AbsoluteUri);
                        PWDlbl.Text = smsg;
                        signsucesslbl.ForeColor = System.Drawing.Color.Green;
                        PWDfileexitcheck();
                    }
                    else
                    {
                        PWDlbl.Text = pdfonly;
                    }

                }

                else
                {
                    PWDlbl.Text = maxpdf;
                }
            }
        }

        protected void PWD_pdfview_Click(object sender, EventArgs e)
        {
            string FilePath = Server.MapPath("files/" + regidlbl.Text.ToString() + "_PWD" + ".pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        protected void PWD_deletebtn_Click(object sender, EventArgs e)
        {
            string pdfname = Server.MapPath("~/files/" + regidlbl.Text.ToString() + "_PWD" + ".pdf");
            ViewState["pdfname"] = pdfname;
            if (File.Exists(pdfname))
            {

                PWD_deletebtn.Visible = true;
                PWD_pdfview.Visible = true;
                File.Delete(pdfname);
                stepsCompleteDelete();
                PWDfileexitcheck();
                Response.Redirect(Request.Url.AbsoluteUri);
                PWDlbl.Text = "Upload only PDF ";
                
            }
            else
            {
                PWD_deletebtn.Visible = false;
                PWD_pdfview.Visible = false;
                PWDlbl.Text = deletemsg;

            }
        }

        protected void goBackbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Candidate_Home.aspx");
        }
    }
}
