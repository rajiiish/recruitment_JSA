using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.IO;

namespace recruitment
{
    public partial class PDFUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadpdffiles();
        }
        public void regid()
        {
            regidlbl.Text = Convert.ToString(Session["can_regno"]);

            appidnolbl.Text = Convert.ToString(Session["S_appregno"]);

            applyhpostlbl.Text = Convert.ToString(Session["postname"]);


            //firstName.Text = Convert.ToString(Session["fname"]);
            //lastName.Text = Convert.ToString(Session["lname"]);
            //email.Text = Convert.ToString(Session["email"]);
        }

        private void uploadpdf()
        {

            Label2.Visible = true;
            string filePath = FileUpload1.PostedFile.FileName; // getting the file path of uploaded file  
            string filename1 = Path.GetFileName(filePath);
            // getting the file name of uploaded file  
            string ext = Path.GetExtension(filename1); // getting the file extension of uploaded file  
            string type = String.Empty;


            if (FileUpload1.HasFile)
            {
                // filesizecheck();

                try
                {
                    switch (ext) // this switch code validate the files which allow to upload only PDF file   
                    {
                        case ".pdf":
                            type = "application/pdf";
                            break;
                    }
                    if (type != String.Empty)
                    {

                        string udocname = DropDownList1.SelectedItem.ToString();
                        string uploadFolder = Request.PhysicalApplicationPath + "files\\";

                        string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);

                        string finalfilename = uploadFolder + udocname + extension;
                        FileUpload1.SaveAs(finalfilename);





                        SqlConnection con = MySqlConnection.Recruitmentcon();

                        string canregnobasic = regidlbl.Text;
                        string newappno = appidnolbl.Text;
                        string path = "files";
                        string Docname = DropDownList1.SelectedValue.ToString();

                        Stream fs = FileUpload1.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs); //reads the binary files  
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length); //counting the file length into bytes  
                        string query = "insert into PDFFiles (can_regno,Docname,DocPath,Name,type,data)" + " values (@canreg,@Docname,@filepath,@Name, @type, @Data)"; //insert query  
                        SqlCommand com = new SqlCommand(query, con);
                        com.Parameters.Add("@Name", SqlDbType.VarChar).Value = filename1;
                        com.Parameters.Add("@type", SqlDbType.VarChar).Value = type;
                        com.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;

                        com.Parameters.Add("@canreg", SqlDbType.VarChar).Value = canregnobasic;
                        // com.Parameters.Add("@appregno", SqlDbType.VarChar).Value = newappno;
                        com.Parameters.Add("@Docname", SqlDbType.VarChar).Value = Docname;
                        com.Parameters.Add("@filepath", SqlDbType.VarChar).Value = path;



                        //com.Parameters.AddWithValue("@canreg", canregnobasic);
                        //com.Parameters.AddWithValue("@appregno", newappno);
                        //com.Parameters.AddWithValue("@Docname", Docname);
                        //com.Parameters.AddWithValue("@filepath", path);


                        com.ExecuteNonQuery();
                        Label2.ForeColor = System.Drawing.Color.Green;
                        //Label2.Text = "File Uploaded Successfully";
                        Label2.Text = "File uploaded successfully as: " + "Test" + extension;
                    }
                    else
                    {
                        Label2.ForeColor = System.Drawing.Color.Red;
                        Label2.Text = "Select Only PDF Files "; // if file is other than speified extension   
                    }
                }
                catch (Exception ex)
                {
                    Label2.Text = "Error: " + ex.Message.ToString();
                }
            }
        }
        private void filesizecheck()
        {

            // Specify the path on the server to
            // save the uploaded file to.
            // string savePath = @"c:\temp\uploads\";

            // Before attempting to save the file, verify
            // that the FileUpload control contains a file.



            if (FileUpload1.HasFile)
            {
                // Get the size in bytes of the file to upload.
                int fileSize = FileUpload1.PostedFile.ContentLength;

                // Allow only files less than 2,100,000 bytes (approximately 2 MB) to be uploaded.
                if (fileSize < 1100000)
                {

                    // Append the name of the uploaded file to the path.
                    //savePath += Server.HtmlEncode(FileUpload1.FileName);

                    // Call the SaveAs method to save the 
                    // uploaded file to the specified path.
                    // This example does not perform all
                    // the necessary error checking.               
                    // If a file with the same name
                    // already exists in the specified path,  
                    // the uploaded file overwrites it.
                    // FileUpload1.SaveAs(savePath);
                    uploadpdf();
                    // Notify the user that the file was uploaded successfully.
                    Label2.Text = "Your file was uploaded successfully.";
                }
                else
                {
                    // Notify the user why their file was not uploaded.
                    Label2.Text = "Your file was not uploaded because " +
                                             "it exceeds the 2 MB size limit.";
                }
            }
            else
            {
                // Notify the user that a file was not uploaded.
                Label2.Text = "You did not specify a file to upload.";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!FileUpload1.HasFile)
            {
                Label2.Text = "Please Select File to upload first."; //if file uploader has no file selected  
            }
            else
            {
                filesizecheck();
            }
        }

        private void loadpdffiles()
        {
            SqlConnection con = MySqlConnection.Recruitmentcon();

            string query = "Select * from PDFFiles";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            con.Close();

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            loadpdffiles();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = MySqlConnection.Recruitmentcon();
            SqlCommand com = new SqlCommand("select can_regno,Docname,DocPath,Name,type,data from PDFFiles where can_regno=@can_regno", con);
            com.Parameters.AddWithValue("can_regno", GridView1.SelectedRow.Cells[1].Text);


            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = dr["type"].ToString();
                Response.AddHeader("content-disposition", "attachment;filename=" + dr["Name"].ToString()); // to open file prompt Box open or Save file  
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite((byte[])dr["data"]);
                Response.End();
            }
        }
    }
}