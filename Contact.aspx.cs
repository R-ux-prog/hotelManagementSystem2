using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Hotel_Management_System
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = 'C:\\Users\\Rohit\\source\\repos\\Hotel Management System\\Hotel Management System\\App_Data\\Contact.mdf'; Integrated Security = True");
            SqlCommand cmd = new SqlCommand("insert into Contact" + "(Name,Email,Phone_Number,Message) values (@Name,@Email,@Phone_Number,@Message)", con);
            cmd.Parameters.AddWithValue("@Name", TextBox1.Text);
            cmd.Parameters.AddWithValue("@Email", TextBox2.Text);
            cmd.Parameters.AddWithValue("@Phone_Number", TextBox3.Text);
            cmd.Parameters.AddWithValue("@Message", TextBox4.Text);
            
            DataTable dt = new DataTable();
            con.Open();
            int i = 0;
           
            try
            {
                i = cmd.ExecuteNonQuery();

            }
            catch (SqlException)
            {
                //Label5.Text = "Email already in use";
            }
           
            if (i > 0)
            {

               Response.Write(@"<script language='javascript'>alert('Thank You for Contact')</script>");
               
                //Response.Redirect("LoginForm1.aspx");

            }
            else
            {
                // Response.Write(@"<script language='javascript'>alert('Register Unsuccesful')</script>");

                // Label5.Text = "Your username and password incorrect";
            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }
    }
}