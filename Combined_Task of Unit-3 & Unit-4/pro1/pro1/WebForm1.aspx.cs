using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace pro1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        String Department;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeesConnectionString1"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Print();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [Emp] ([EmpName], [DateOfBirth], [Department], [ProfileImage]) VALUES (@EmpName, @DateOfBirth, @Department, @ProfileImage)", con);
            cmd.Parameters.AddWithValue("EmpName",TextBox1.Text);
            cmd.Parameters.AddWithValue("DateOfBirth", TextBox2.Text);
            if (DropDownList1.SelectedItem.Selected)
            {
                Department = DropDownList1.SelectedValue;
            }

            cmd.Parameters.AddWithValue("Department", Department);
            cmd.Parameters.AddWithValue("ProfileImage", FileUpload1.FileName);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();

            if (res==1)
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
                DropDownList1.ClearSelection();
                FileUpload1.SaveAs(Server.MapPath("image\\" + FileUpload1.FileName));
                Label1.Text = "Record inserted..🥰🥰";
                Print();
            }
        }

        public void Print()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT [Id], [EmpName], [DateOfBirth], [Department], [ProfileImage] FROM [Emp]", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}