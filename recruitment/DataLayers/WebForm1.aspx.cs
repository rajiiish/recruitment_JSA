using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace recruitment.DataLayers
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadAllData()
        {
            string can_regno = "CMC20131000";
            string appregno = "TA-IT-2001";

            GridView1.DataSource = BasicDetailsDataAccessLayer.GetDetails(can_regno, appregno);
            GridView1.DataBind();

           
        }
        protected void LoadData_Click(object sender, EventArgs e)
        {
            
            LoadAllData();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string can_regno = "CMC20131000";
            string appregno = "TA-IT-2001";
            DataSet ds = new DataSet();
            DataTable ad = new DataTable();


            var a = BasicDetailsDataAccessLayer.GetDetails(can_regno, appregno);
            
           
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {

        }
         
    }
}