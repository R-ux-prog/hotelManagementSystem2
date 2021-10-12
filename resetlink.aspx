<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resetlink.aspx.cs" Inherits="Hotel_Management_System.resetlink" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 44%;
        }
        .style2
        {
            width: 128px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <table class="style1" align="center" style="background-color: #FFFF00">
            <tr>
                <td class="style2">
                    New Password
                </td>
                <td>
                    <asp:TextBox ID="txtpwd" runat="server" Width="158px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Confirm Password
                </td>
                <td>
                    <asp:TextBox ID="txtcofrmpwd" runat="server" Width="158px"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidatorPassword" runat="server" ControlToCompare="txtpwd"
                        ControlToValidate="txtcofrmpwd" ErrorMessage="Password does not match" Font-Names="Rockwell"
                        ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" Width="156px" OnClick="btnsubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
