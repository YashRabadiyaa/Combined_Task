using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace pro4
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["customerConnectionString1"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Custname"] != null)
            {
                Label1.Text = "Welcome " + Session["Custname"] + "...!!";
            }
            else
            {
                Label1.Text = "Welcome User...!!";
            }

            Print();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void Print()
        {
            SqlDataAdapter adpt = new SqlDataAdapter("SELECT [Id], [Custname], [Email], [Adress], [City] FROM [customer]", con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}