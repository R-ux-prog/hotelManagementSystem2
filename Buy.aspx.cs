using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Hotel_Management_System
{
    public partial class Buy : System.Web.UI.Page
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
        double amount;
        double roomPrice;

        protected void Page_Load(object sender, EventArgs e)
        {
            firstName = Session["firstName"].ToString();
            lastName = Session["lastName"].ToString();
            email = Session["email"].ToString();
            mobileNumber = Session["mobileNumber"].ToString();
            roomNumber = Session["roomNumber"].ToString();
            arivalDate = Session["arivalDate"].ToString();
            departureDate = Session["departureDate"].ToString();
            laundryService = Session["laundryService"].ToString();
            foodService = Session["foodService"].ToString();
            roomService = Session["roomService"].ToString();
            wifiService = Session["wifiService"].ToString();
            turismService = Session["turismService"].ToString();
            
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\Rohit\\source\\repos\\Hotel Management System\\Hotel Management System\\App_Data\\RAvailibility.mdf';Integrated Security=True");
                con.Open();
                roomPrice = 0.00;
                string query = "select Cost from Room where Room_no=" + roomNumber;
                SqlCommand com = new SqlCommand(query, con);

                SqlDataReader da = com.ExecuteReader();
                if (da.HasRows)
                {
                    da.Read();
                    roomPrice = Convert.ToDouble((int)da["Cost"]);
                }
                da.Close();
                con.Close();
                amount += roomPrice;
                rPrice.Text = "Room Price :" + roomPrice.ToString();
                if (laundryService == "True")
                {
                    laundry.Text = "Laundry Service : 500rs";
                    amount += 500.00;
                }
                if (foodService == "True")
                {
                    food.Text = "Food Service : 300rs";
                    amount += 300.00;
                }
                if (roomService == "True")
                {
                    room.Text = "Room Service : 200rs";
                    amount += 200.00;
                }
                if (wifiService == "True")
                {
                    wifi.Text = "Wifi Service : 150rs";
                    amount += 150.00;
                }
                if (turismService == "True")
                {
                    turism.Text = "Turism Service :1000rs";
                    amount += 1000.00;
                }
                pay.Text = "Total Amount:" + amount.ToString();
            //}
            Random random = new Random();
            txnid.Value = (Convert.ToString(random.Next(1000, 50000)));
            txnid.Value = "Form" + txnid.Value.ToString();         
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String text = key.Value.ToString() + "|" + txnid.Value.ToString() + "|" + amount + "|" + "Form Fee" + "|Rohit|rohitthorat75832@gmail.com|" + "1" + "|" + "1" + "|" + "1" + "|" + "1" + "|" + "1" + "||||||" + salt.Value.ToString();
            byte[] message = Encoding.UTF8.GetBytes(text);
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            SHA512Managed hashString = new SHA512Managed();
            string hex = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
               hex += String.Format("{0:x2}", x);
            }
            hash.Value = hex;
            System.Collections.Hashtable data = new System.Collections.Hashtable(); // adding values in gash table for data post

            data.Add("hash", hex.ToString());
            data.Add("txnid", txnid.Value);
            data.Add("key", key.Value);
            data.Add("amount", amount);
            data.Add("firstname", firstName.Trim());
            data.Add("lastname", lastName);
            data.Add("email", email.Trim());
            data.Add("phone", mobileNumber.Trim());
            data.Add("roomno", roomNumber.Trim());
            data.Add("arival", arivalDate.Trim());
            data.Add("departure", departureDate.Trim());
            data.Add("laundary", laundryService.ToString().Trim());
            data.Add("food", foodService.ToString().Trim());
            data.Add("room", roomService.ToString().Trim());
            data.Add("wifi", wifiService.ToString().Trim());
            data.Add("turism", turismService.ToString().Trim());
            data.Add("productinfo", "Form Fee");
            data.Add("udf1", "1");
            data.Add("udf2", "1");
            data.Add("udf3", "1");
            data.Add("udf4", "1");
            data.Add("udf5", "1");
            data.Add("surl", "http://localhost:50561/SuccessPayment.aspx");
            data.Add("furl", "http://localhost:50561/FailurePayment.aspx");
            data.Add("service_provider", "");
            string strForm = PreparePOSTForm("https://c1c4-103-249-133-86.ngrok.io/", data);
            //string strForm = PreparePOSTForm("https://secure.payu.in/_payment", data);
            Page.Controls.Add(new LiteralControl(strForm));
        }
        private string PreparePOSTForm(string url, System.Collections.Hashtable data) // post form
        {
            //Set a name for the form
            string formID = "PostForm";
            //Build the form using the specified data to be posted.
            StringBuilder strForm = new StringBuilder();
            strForm.Append("<form id=\"" + formID + "\" name=\"" + formID + "\" action=\"" + url +"\" method=\"POST\">");
            foreach (System.Collections.DictionaryEntry key in data)
            {
                strForm.Append("<input type=\"hidden\" name=\"" + key.Key +"\" value=\"" + key.Value + "\">");
            }
            strForm.Append("</form>");
            //Build the JavaScript which will do the Posting operation.
            StringBuilder strScript = new StringBuilder();
            strScript.Append("<script language='javascript'>");
            strScript.Append("var v" + formID + " = document." +
            formID + ";");
            strScript.Append("v" + formID + ".submit();");
            strScript.Append("</script>");
            //Return the form and the script concatenated.
            //(The order is important, Form then JavaScript)
            return strForm.ToString() + strScript.ToString();
        }
    }
}
