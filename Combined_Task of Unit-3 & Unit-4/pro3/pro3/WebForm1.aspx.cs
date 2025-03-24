using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace pro3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        String Grade;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentsConnectionString1"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Print();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Button1.Text == "insert")
            {


                SqlCommand cmd = new SqlCommand("INSERT INTO [Std] ([Name], [Age], [Grade]) VALUES (@Name, @Age, @Grade)", con);
                cmd.Parameters.AddWithValue("Name", TextBox1.Text);
                cmd.Parameters.AddWithValue("Age", TextBox2.Text);
                if (ListBox1.SelectedItem.Selected)
                {
                    Grade = ListBox1.SelectedValue;
                }
                cmd.Parameters.AddWithValue("Grade", Grade);

                con.Open();
                int res = cmd.ExecuteNonQuery();
                con.Close();
                if (res == 1)
                {
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    ListBox1.ClearSelection();
                    Label1.Text = "inserted..🥰🥰";
                    Print();
                }
            }
            else
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Std] SET [Name] = @Name, [Age] = @Age, [Grade] = @Grade WHERE [Id] = @Id", con);
                cmd.Parameters.AddWithValue("Name", TextBox1.Text);
                cmd.Parameters.AddWithValue("Age", TextBox2.Text);
                if (ListBox1.SelectedItem.Selected)
                {
                    Grade = ListBox1.SelectedValue;
                }
                cmd.Parameters.AddWithValue("Grade", Grade);
                cmd.Parameters.AddWithValue("Id",ViewState["Id"]);
                con.Open();
                int res = cmd.ExecuteNonQuery();
                con.Close();
                if (res == 1)
                {
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    ListBox1.ClearSelection();
                    Label1.Text = "Updated..🥰🥰";
                    Button1.Text = "insert";
                    Print();
                }
            }
            
        }
        public void Print()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT [Id], [Name], [Age], [Grade] FROM [Std]",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            SqlCommand cmd = new SqlCommand("DELETE FROM [Std] WHERE [Id] = "+btn.CommandArgument, con);
            cmd.Parameters.AddWithValue("Id",btn.CommandArgument);
            
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Label1.Text = "Deleted..😛😛";
            Print();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            SqlDataAdapter da = new SqlDataAdapter("SELECT [Id], [Name], [Age], [Grade] FROM [Std] WHERE [Id] = "+btn.CommandArgument, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            TextBox1.Text = dt.Rows[0][1].ToString();
            TextBox2.Text = dt.Rows[0][2].ToString();
            ListBox1.SelectedValue= dt.Rows[0][3].ToString();
            ViewState["Id"] = btn.CommandArgument;
            Button1.Text = "Update";
        }
    }
}