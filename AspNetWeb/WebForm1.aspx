<%@ Page Language="C#" AutoEventWireup="true"   CodeBehind="WebForm1.aspx.cs" Inherits="AspNetWeb.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>test page</title>    
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblUserName" runat="server" Text="UserName"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblFirstName" runat="server" Text="Firstname"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblLastName" runat="server" Text="LastName"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLastname" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Button ID="btnSave" CssClass="btn btn-default" runat="server" Text="Save" /> &nbsp&nbsp                   
                        <asp:Button ID="btnCancel" CssClass="btn btn-default" runat="server" Text="Cancel" />
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
