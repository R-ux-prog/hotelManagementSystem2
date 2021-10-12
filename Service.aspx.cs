using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_Management_System
{
    public partial class Service : System.Web.UI.Page
    {
        String firstName;
        String lastName;
        String email;
        String mobileNumber;
        String roomNumber;
        String arivalDate;
        String departureDate;
        bool laundryService;
        bool foodService;
        bool roomService;
        bool wifiService;
        bool turismService;       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {          
            firstName =TextBox1.Text;
            lastName = TextBox2.Text;
            email = TextBox3.Text;
            mobileNumber = TextBox4.Text;
            roomNumber = TextBox5.Text;
            arivalDate = TextBox6.Text;
            departureDate = TextBox7.Text;
            laundryService = CheckBox1.Checked;
            foodService = CheckBox2.Checked;
            roomService = CheckBox3.Checked;
            wifiService = CheckBox4.Checked;
            turismService = CheckBox5.Checked;

            Session["firstName"] = firstName;
            Session["lastName"] = lastName;
            Session["email"] = email;
            Session["mobileNumber"] = mobileNumber;
            Session["roomNumber"] = roomNumber;
            Session["arivalDate"] = arivalDate;
            Session["departureDate"] = departureDate;
            Session["laundryService"] = laundryService.ToString();
            Session["foodService"] = foodService.ToString();
            Session["roomService"] = roomService.ToString();
            Session["wifiService"] = wifiService.ToString();
            Session["turismService"] = turismService.ToString();   

            Server.Transfer("Buy.aspx");           
        }


    }
}