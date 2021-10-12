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
    public partial class Booking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\Rohit\\source\\repos\\Hotel Management System\\Hotel Management System\\App_Data\\RAvailibility.mdf';Integrated Security=True");
            SqlCommand cmd = new SqlCommand("insert into Book" + "(First_Name,Last_Name,Email,Mobile_Number,Room_No,Arrival_Date,Despature_Date) values (@First_Name,@Last_Name,@Email,@Mobile_Number,@Room_No,@Arrival_Date,@Despature_Date)", con);
            cmd.Parameters.AddWithValue("@First_Name", TextBox1.Text);
            cmd.Parameters.AddWithValue("@Last_Name", TextBox2.Text);
            cmd.Parameters.AddWithValue("@Email", TextBox3.Text);
            cmd.Parameters.AddWithValue("@Mobile_Number", TextBox4.Text);
            cmd.Parameters.AddWithValue("@Room_No", TextBox7.Text);
            cmd.Parameters.AddWithValue("@Arrival_Date", TextBox5.Text);
            cmd.Parameters.AddWithValue("@Despature_Date", TextBox6.Text);
            DataTable dt = new DataTable();
            con.Open();
            int i = 0;
            try
            {
                i = cmd.ExecuteNonQuery();

            }
            catch (SqlException )
            {
               
            }
            con.Close();
            if (i > 0)
            {
                Response.Redirect("Buy.aspx?price=" + Label9.Text);


            }
            else
            {
                // Response.Write(@"<script language='javascript'>alert('Register Unsuccesful')</script>");

                // Label5.Text = "Your username and password incorrect";
            }


        }
    }
}