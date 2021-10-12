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
    public partial class Registration : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\Rohit\\source\\repos\\Hotel Management System\\Hotel Management System\\App_Data\\Database2mdf.mdf';Integrated Security=True");
            SqlCommand cmd = new SqlCommand("insert into hotel1" + "(FName,LName,Email,Gender,Address,Phone,Password) values (@FName,@LName,@Email,@Gender,@Address,@Phone,@Password)", con);
            cmd.Parameters.AddWithValue("@FName", TextBox1.Text);
            cmd.Parameters.AddWithValue("@LName", TextBox2.Text);
            cmd.Parameters.AddWithValue("@Email", TextBox3.Text);
            cmd.Parameters.AddWithValue("@Gender", DropDownList1.Text);
            cmd.Parameters.AddWithValue("@Address", TextBox5.Text);
            cmd.Parameters.AddWithValue("@Phone", TextBox6.Text);
            cmd.Parameters.AddWithValue("@Password", TextBox7.Text);
            DataTable dt = new DataTable();
            con.Open();
            int i = 0;
            try
            {
                 i = cmd.ExecuteNonQuery();
               
            }
            catch(SqlException )
            {
                Label10.Text = "Email already in use" ;
            }
            con.Close();

            if (i > 0)
            {

               // Response.Write(@"<script language='javascript'>alert('Registration Succesfull\n Go to login page')</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(),"alert", "alert('Registration Successful Visit Login Page') ;window.location ='LoginForm1.aspx';", true);
                
                //Response.Redirect("LoginForm1.aspx");
              
            }
            else
            {
               // Response.Write(@"<script language='javascript'>alert('Register Unsuccesful')</script>");

                // Label5.Text = "Your username and password incorrect";
            }
        

        }
    }
}