using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;


namespace recruitment
{
    public partial class registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
           


        }

        protected void submitbtn_Click(object sender, EventArgs e)
        {
            datainsert();
            result.Text = "sucessfully submitted";
        }

        public void datainsert()
        {
            

            string sql = "Insert into registration(mobile,firstname,lastname,gender,state,city,pincode,tempadd,email,password,dob) values ('"+TextBox3.Text+"','"+TextBox1.Text+"','"+TextBox9.Text + "','"+TextBox4.Text + "','"+DropDownList1.Text + "','"+TextBox6.Text + "','"+TextBox7.Text + "','"+TextBox5.Text + "','"+TextBox8.Text + "','"+TextBox10.Text + "','" + TextBox2.Text + "')";
            SqlConnection connection = MySqlConnection.Recruitmentcon();
            SqlCommand command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();
        }
    }
}