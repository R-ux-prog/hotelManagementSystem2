<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Hotel_Management_System.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">    

    <style>
        *{
            box-sizing:border-box;
            margin:0;
            padding:0;
        }
     body{
         background-color:#071A52;
     }
    .menu{
        display: flex;
        flex-direction:row;
        justify-content: space-between;
        width:100%;
        line-height:2.5;
        background-color:#086972;
        height:6rem;
    }
    .menu .logo > img{
        height:150px;
        width:150px;

    }
    .menu .links{
        display: flex;
        flex-direction:row;
        justify-content: space-around;

    }
    .menu .links div{
        margin:5px;
        padding:0 10px;
        font-size:2rem;
        color:#FFD082;
        
        
    }
     .menu .links div:hover{
        background-color:#06565E;
        
      }
      .auto-style1 {
          width: 423px;
      }
      .container {
          display:flex;
        height:32rem;
        width:100%;
        background-image: url('Image/Room.png');
        background-repeat:no-repeat;
        background-size:100%;
        border:1px solid white;
        justify-content:center;
      }

       .container .btn{
         display:flex;
         height:30px;
         width:100px;
         justify-content:center;

       }
        
        </style>
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
       <div class="menu">
           <div class="logo"><img alt="" class="auto-style1" src="Image/royal.png" /></div>
               
        <div class="links">
        <div class="home" onclick="location.href = 'Home.aspx';">Home</div>
        <div class="about" onclick="location.href = 'about.aspx';">About</div>
        <div class="services" onclick="location.href = 'Service.aspx';">Services</div>
        <div class="contact" onclick="location.href = 'Contact.aspx';">Contact</div>
         <div class="logout" onclick="location.href = 'LoginForm1.aspx';">Logout<br />
            </div>
        </div>
    </div>
        
    
       <div class="menu">
        <div class="container">
            <div class="btn">
               
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:TextBox ID="TextBox2" runat="server"  Height="28px" Width="268px" ReadOnly="True"  ></asp:TextBox>
                <asp:Button ID="Button2" runat="server" Text="..." BackColor="Lime" OnClick="Button2_Click1" />
                <asp:Calendar ID="Calendar1" runat="server" BackColor="#99FF33" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" Width="400px" NextPrevFormat="FullMonth" OnSelectionChanged="Calendar1_SelectionChanged" TitleFormat="Month" Visible="False" VisibleDate="2021-09-12" SelectedDate="09/12/2021 10:36:04">
                    <DayHeaderStyle BackColor="#CCCCCC" ForeColor="#333333" Height="10pt" Font-Bold="True" Font-Size="7pt" />
                    <DayStyle Width="14%" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" ForeColor="#333333" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" Width="1%" />
                    <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                    <TodayDayStyle BackColor="#CCCC99" />
                </asp:Calendar>
               
         <asp:DropDownList ID="DropDownList2" runat="server" Height="28px" Width="268px">
            <asp:ListItem>Single</asp:ListItem>
            <asp:ListItem>Double</asp:ListItem>
            <asp:ListItem>Triple</asp:ListItem>
            <asp:ListItem>Quad</asp:ListItem>
            <asp:ListItem>Studio</asp:ListItem>
        </asp:DropDownList>
                <br />
                <br />
                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Check Availability" BackColor="Red" />
                <br />
                <br />
&nbsp;
                
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
       </div>
            <div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Panel ID="Panel1" runat="server">
            <asp:GridView ID="GridView1" runat="server" Width="378px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                <EmptyDataTemplate>
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </EmptyDataTemplate>
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#330099" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                <SortedAscendingCellStyle BackColor="#FEFCEB" />
                <SortedAscendingHeaderStyle BackColor="#AF0101" />
                <SortedDescendingCellStyle BackColor="#F6F0C0" />
                <SortedDescendingHeaderStyle BackColor="#7E0000" />
            </asp:GridView>
                <asp:Button ID="Button1" runat="server" OnClick="Button5_Click" Text="Book Now" BackColor="#FF3300" />
                </asp:Panel>
           </div>
            <br />
            <br />
            <br />
            
            </div>
           <div>
            </div>
            
           </div>
    </form>
    
       
        
   
       
</body>
</html>
