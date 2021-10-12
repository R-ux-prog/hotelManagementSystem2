using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using System.Data;


namespace Hotel_Management_System
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\Rohit\\source\\repos\\Hotel Management System\\Hotel Management System\\App_Data\\Database2mdf.mdf';Integrated Security=True");
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsend_Click(object sender, EventArgs e)
        {

            try
            {

                Session["email"] = txtemail.Text;

                SqlDataAdapter adp = new SqlDataAdapter("select * from hotel1 where email=@email", con);
                con.Open();

                adp.SelectCommand.Parameters.AddWithValue("@email", txtemail.Text);

                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    SqlCommand cmd = new SqlCommand("Update hotel1 set password where email='" + txtemail.Text + "'", con);

                    cmd.ExecuteNonQuery();

                    SendEmail();

                    lbresult.Text = "successfully sent reset link on  your mail ,please check once! Thank you.";
                    con.Close();

                    cmd.Dispose();

                    txtemail.Text = "";

                }
                else
                {

                    lbresult.Text = "Please enter vaild email ,please check once! Thank you.";

                }

            }

            catch (Exception )
            {

            }

        }

        // using this method we sent the mail to reciever

        private void SendEmail()
        {

            try
            {

                StringBuilder sb = new StringBuilder();
                sb.Append("Hi,<br/> Click on below given link to Reset Your Password<br/>");
               // sb.Append("<a href=http://http://localhost:50561/resetlink.aspx?username=" + UserGetemail(txtemail.Text));
                sb.Append("&email=" + txtemail.Text + ">Click here to change your password</a><br/>");
                sb.Append("<b>Thanks</b>,<br> Code Solution <br/>");
                sb.Append("<br/><b> for more post </b> <br/>");
                // sb.Append("<br/><a href=http://neerajcodesolution.blogspot.in");
                sb.Append("thanks");

                MailMessage message = new System.Net.Mail.MailMessage("rohitthorat75832@gmail.com", txtemail.Text.Trim(), "Reset Your Password", sb.ToString());

                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";

                smtp.Port = 587;

                smtp.Credentials = new System.Net.NetworkCredential("rohitthorat75832@gmail.com", "Rohit@123");

                smtp.EnableSsl = true;

                message.IsBodyHtml = true;

                smtp.Send(message);

            }
            catch (Exception )
            {

            }
        }

    }
}