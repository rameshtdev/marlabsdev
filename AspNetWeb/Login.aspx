<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AspNetWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
     <style>
        .width {
        width:300px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-lg-4">
            </div>
            <div class="col-lg-4">
                <table class="table">
                    <tr>
                        <th>
                            <h3>Login</h3>
                        </th>
                    </tr>
                    <tr>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" Font-Bold="true" Text="Email:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" CssClass="form-control width" placeholder="Enter Email.."></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter Valid Email Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                    </tr>
                    <tr>
                    <td>
                        <asp:Label ID="lblPassword" runat="server" Font-Bold="true" Text="Password"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control width" placeholder="Enter Password.." runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </td>
                    </tr>
                    <tr>
                    <td>
                        <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" Text="Login" OnClick="btnSubmit_Click" />
                    </tr>
                </table>
            </div>
            <div class="col-lg-4"></div>
        </div>
    </form>
</body>
</html>
