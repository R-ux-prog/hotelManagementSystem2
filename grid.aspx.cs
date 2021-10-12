using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Hotel_Management_System
{
    public partial class grid : System.Web.UI.Page
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
            //DataReader dr = new DataReader();
        }

        private void rep_bind()
        {
            //SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\Rohit\\source\\repos\\Hotel Management System\\Hotel Management System\\App_Data\\Da.mdf';Integrated Security=True");
            //con.Open();
            connection();
            String query = "select * from Room where Room_no="+TextBox1.Text;
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            connection();
            String query = "select * from Room where Room_no=" +TextBox1.Text;
            SqlCommand com = new SqlCommand(query, con);

            SqlDataReader dr;
            dr = com.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                rep_bind();
                GridView1.Visible = true;
                TextBox1.Text = "";
                Lable2.Text = "";
            }
            else
            {
                GridView1.Visible = false;
                Lable2.Text = "The search Term" + "Is Not Available in the Records";
            }
        }
    }
}