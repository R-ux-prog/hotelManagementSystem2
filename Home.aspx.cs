using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Hotel_Management_System
{
    public partial class Home : System.Web.UI.Page
    {
        public SqlConnection con;
        public string constr;

        public void connection()
        {
            //constr = ConfigurationManager.ConnectionStrings["emp"].ToString();
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\Rohit\\source\\repos\\Hotel Management System\\Hotel Management System\\App_Data\\RAvailibility.mdf';Integrated Security=True");
            con.Open();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        private void rep_bind()
        {
            //SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\Rohit\\source\\repos\\Hotel Management System\\Hotel Management System\\App_Data\\Da.mdf';Integrated Security=True");
            //con.Open();
            connection();
            String query = "select * from Room where (Date<='" + TextBox2.Text + "' and Room_Type='" + DropDownList2.Text + "') or Status='Available'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }

       

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox2.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
            Calendar1.Visible = false;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            connection();
            String query = "select * from Room where (Date<='"+ TextBox2.Text+"' and Room_Type='" + DropDownList2.Text+"') or Status='Available'";
            SqlCommand com = new SqlCommand(query, con);

            

            SqlDataReader dr;
            dr = com.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                rep_bind();
                GridView1.Visible = true;



            }
            else
            {
                GridView1.Visible = false;
                Response.Write(@"<script language='javascript'>alert('Room is not Available')</script>");

            }

            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Service.aspx");
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
        }
    }
}