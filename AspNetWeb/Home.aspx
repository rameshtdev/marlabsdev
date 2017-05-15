<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="AspNetWeb.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="row">
    <div class="col-lg-4"></div>
    <div class="col-lg-4">
     Welcome  
        <asp:Label ID="lblEmail" Font-Bold="true" runat="server" Text="Label"></asp:Label>
    </div>
    <div class="col-lg-4"></div>
    </div>
    </form>
</body>
</html>
