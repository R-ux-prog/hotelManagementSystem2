using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Hotel_Management_System
{
    public partial class resetlink : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string email = Session["email"].ToString();

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
          string email = Session["email"].ToString();

            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\Rohit\\source\\repos\\Hotel Management System\\Hotel Management System\\App_Data\\Database2mdf.mdf';Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Update hotel1 set password = '" + txtpwd.Text + "'where email= '" + email + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert ('your password has been successfully updated')</script>");
            txtpwd.Text = "";
            txtcofrmpwd.Text = "";
        }
    }
}