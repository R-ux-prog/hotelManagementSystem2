<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grid.aspx.cs" Inherits="Hotel_Management_System.grid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                     Search
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server">

                        </asp:TextBox>
                    &nbsp;
                    </td>
                    <td>
                        &nbsp;<asp:Button ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
            <table><tr><td><p>
                <asp:Label ID="Lable2" runat="server" Text="lable"></asp:Label>
                           </p></td></tr></table>
            <asp:GridView ID="GridView1" runat="server" ></asp:GridView>
        </div>
    </form>
</body>
</html>
