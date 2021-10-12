using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Hotel_Management_System
{
    public partial class SuccessPayment : System.Web.UI.Page
    {
        public SqlConnection con;
        public string constr;
        string firstName;
        string lastName;
        string email;
        string mobileNumber;
        string roomNumber;
        string arivalDate;
        string departureDate;
        string laundryService;
        string foodService;
        string roomService;
        string wifiService;
        string turismService;
        string transactionId;
        protected void Page_Load(object sender, EventArgs e)
        {
            firstName = Request.Form["firstName"];
            lastName = Request.Form["lastName"];
            email = Request.Form["email"];
            mobileNumber = Request.Form["phone"];
            roomNumber = Request.Form["roomno"];
            arivalDate = Request.Form["arival"];
            departureDate = Request.Form["departure"];
            laundryService = Request.Form["laundary"];
            foodService = Request.Form["food"];
            roomService = Request.Form["room"];
            wifiService = Request.Form["wifi"];
            turismService = Request.Form["turism"];
            transactionId = Request.Form["txnid"];

            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\Rohit\\source\\repos\\Hotel Management System\\Hotel Management System\\App_Data\\RAvailibility.mdf';Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Book values('"+firstName+"','"+lastName+"','"+email+"','" + mobileNumber+ "','" + roomNumber + "','" + laundryService+ "','" + foodService+ "','" + roomService+ "','" + wifiService+ "','" + turismService+ "','" + arivalDate + "','" + departureDate + "')", con);
            int i=cmd.ExecuteNonQuery();
            con.Close();
            /* if (i==-1)
             {

             }*/
            //Label1.Text = "Transaction ID :" + transactionId + " has been successfully Completed";
            Response.Write(@"<script language='javascript'>alert('Transaction ID: " + transactionId + " has been successfully Completed')</script>");
        }
    }
}