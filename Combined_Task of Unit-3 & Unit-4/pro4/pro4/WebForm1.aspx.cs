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
    public partial class WebForm1 : System.Web.UI.Page
    {
        String City;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["customerConnectionString1"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [customer] ([Custname], [Email], [Adress], [City]) VALUES (@Custname, @Email, @Adress, @City)", con);
            cmd.Parameters.AddWithValue("Custname", TextBox1.Text);
            cmd.Parameters.AddWithValue("Email", TextBox2.Text);
            cmd.Parameters.AddWithValue("Adress", TextBox3.Text);
            if (DropDownList1.SelectedItem.Selected)
            {
                City = DropDownList1.SelectedValue;
            }
            cmd.Parameters.AddWithValue("City", City);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            Session["Custname"] = TextBox1.Text;
            Response.Redirect("WebForm2.aspx");
            if (res==1)
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                DropDownList1.ClearSelection();
                Label1.Text = "Data inserted..";
            }
        }
    }
}