using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Pro2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductsConnectionString1"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Print();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Button1.Text == "insert")
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Pro] ([ProductName], [UnitPrice], [UnitInStock]) VALUES (@ProductName, @UnitPrice, @UnitInStock)", con);
                cmd.Parameters.AddWithValue("ProductName", TextBox1.Text);
                cmd.Parameters.AddWithValue("UnitPrice", TextBox2.Text);
                cmd.Parameters.AddWithValue("UnitInStock", TextBox3.Text);
                con.Open();
                int res = cmd.ExecuteNonQuery();
                con.Close();

                if (res == 1)
                {
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    Label1.Text = "insertedddd";
                    Print();
                }
            }
            else
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Pro] SET [ProductName] = @ProductName, [UnitPrice] = @UnitPrice, [UnitInStock] = @UnitInStock WHERE [Id] = @Id", con);
                cmd.Parameters.AddWithValue("ProductName", TextBox1.Text);
                cmd.Parameters.AddWithValue("UnitPrice", TextBox2.Text);
                cmd.Parameters.AddWithValue("UnitInStock", TextBox3.Text);
                cmd.Parameters.AddWithValue("Id",ViewState["Id"]);
                con.Open();
                int res = cmd.ExecuteNonQuery();
                con.Close();

                if (res == 1)
                {
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    Label1.Text = "updatedddd";
                    Button1.Text = "insert";
                    Print();
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void Print()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT [Id], [ProductName], [UnitPrice], [UnitInStock] FROM [Pro]",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            SqlCommand cmd = new SqlCommand("DELETE FROM [Pro] WHERE [Id] = "+btn.CommandArgument, con);
            cmd.Parameters.AddWithValue("Id",btn.CommandArgument);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            Print();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            SqlDataAdapter da = new SqlDataAdapter("SELECT [Id], [ProductName], [UnitPrice], [UnitInStock] FROM [Pro] WHERE [Id] =" + btn.CommandArgument, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ViewState["Id"] = btn.CommandArgument;
            TextBox1.Text = dt.Rows[0][1].ToString();
            TextBox2.Text = dt.Rows[0][2].ToString();
            TextBox3.Text = dt.Rows[0][3].ToString();
            Button1.Text = "selected..";
        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Print();
        }
    }
}