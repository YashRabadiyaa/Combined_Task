using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;

namespace pro5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BooksConnectionString1"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT [Id], [Title], [Author], [Price] FROM [book]", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ds.WriteXml(Server.MapPath("XMLFile1.xml"));
            Literal1.Text = "data have written in xml file";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string xmlFilePath = Server.MapPath("XMLFile1.xml");

            // Check if the file exists before attempting to load it
            if (System.IO.File.Exists(xmlFilePath))
            {
                ds.ReadXml(xmlFilePath);

                // Optionally, bind the data to a GridView or another control
                GridView1.DataSource = ds;
                GridView1.DataBind();
                Literal1.Text = "Data has been read from the XML file.";
            }
            else
            {
                Literal1.Text = "XML file does not exist.";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [book] ([Title], [Author], [Price]) VALUES (@Title, @Author, @Price)", con);
            cmd.Parameters.AddWithValue("Title",TextBox1.Text);
            cmd.Parameters.AddWithValue("Author", TextBox2.Text);
            cmd.Parameters.AddWithValue("Price", TextBox3.Text);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res==1)
            {

                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                Literal1.Text= "data inserted..";

            }
        }
    }
}