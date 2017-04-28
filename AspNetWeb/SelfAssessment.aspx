<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelfAssessment.aspx.cs" Inherits="AspNetWeb.SelfAssessment"%>
<%@ OutputCache Duration="15" VaryByParam="None" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Self Assessment</title>
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
    <div class="col-lg-2"></div>
    <div class="col-lg-8">
    <table class="table table-hover">
        <tr><th colspan="2" ><h1> Assessment Page</h1></th></tr>
        <tr><td>
            <h5><asp:Label ID="lblFirstName" runat="server" Font-Bold="true" Text="FirstName"></asp:Label></h5>
            </td><td>
                <asp:TextBox ID="txtFirstName" runat="server"  CssClass="form-control width" placeholder="Enter first name"></asp:TextBox>
                
            </td>
            
        <td>
            <h5><asp:Label ID="lblLastName" runat="server" Font-Bold="true" Text="LastName"></asp:Label></h5>
            </td><td>
                
                <asp:TextBox ID="textLastName" CssClass="form-control width" placeholder="Enter last name" runat="server"></asp:TextBox>
            </td>
             <td>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="textLastName" ErrorMessage="LastName is Required">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr><td>
           <h5> <asp:Label ID="lblEmail" runat="server" Font-Bold="true" Text="Email"></asp:Label></h5>
            </td><td>
                
                <asp:TextBox ID="txtEmail" class="form-control width" placeholder="Enter email id" runat="server"></asp:TextBox>
            </td>
             
        <td>
           <h5> <asp:Label ID="lblAge" runat="server" Font-Bold="true" Text="Age"></asp:Label></h5>
            </td><td>
                <asp:TextBox ID="txtAge" runat="server" CssClass="form-control width" placeholder="Enter age"></asp:TextBox>
                
            </td>
             <td>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAge" ErrorMessage="Age is Required">*</asp:RequiredFieldValidator>
                 <asp:RangeValidator runat="server" ControlToValidate="txtAge" ErrorMessage="Age is not in allowed range" MinimumValue="18" MaximumValue="35" Type="Integer">*</asp:RangeValidator>
            </td>
        </tr>
        <tr><td>
            <h5><asp:Label ID="lblGender" Font-Bold="true" runat="server" Text="Gender"></asp:Label></h5>
            </td>
            <td>
                <asp:RadioButtonList ID="rdGender" CssClass="width" Font-Bold="false" runat="server" RepeatDirection="Horizontal" >
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            
       <td>
            <h5><asp:Label ID="lblCountry" Font-Bold="true" runat="server" Text="Country"></asp:Label></h5>
            </td>
            <td>
                <asp:DropDownList ID="ddlCountry" CssClass="form-control" runat="server">
                    <asp:ListItem>Canada</asp:ListItem>
                    <asp:ListItem>USA</asp:ListItem>
                    <asp:ListItem>Mexico</asp:ListItem>
                    <asp:ListItem>Brazil</asp:ListItem>
                </asp:DropDownList>
            </td>
             <td>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlCountry" ErrorMessage="Country is Required">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr><td>
           <h5> <asp:Label ID="lblExpertise" Font-Bold="true" runat="server" Text="Expertise"></asp:Label></h5>
            </td><td>
                <asp:ListBox ID="lstExpertise" SelectionMode ="Multiple" runat="server"></asp:ListBox>
            </td>
            
        </tr>
        <tr><td>
            <h5><asp:Label ID="lblQualification" runat="server" Font-Bold="true" Text="Qualification"></asp:Label></h5>
            </td><td>
                <asp:CheckBoxList ID="chkQualification" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>Master Degree - Completed</asp:ListItem>
                    <asp:ListItem>Master Degree - In Progress</asp:ListItem>
                    <asp:ListItem>Existing work Experience</asp:ListItem>
                </asp:CheckBoxList>
            </td> </tr>
        <tr><td colspan="2">
            <asp:Button ID="btnSumbit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnSumbit_Click" />
            </td></tr>
        <tr><td colspan="2">
            <asp:ValidationSummary runat="server" HeaderText="Errors:" DisplayMode="BulletList" ShowSummary="true"/>           

            </td></tr>
        <tr><td colspan="2">
              
             </td></tr>
    </table>
    </div>
    <div class="col-lg-2"></div>
    </div>
    <div class="col-lg-offset-3">
    <asp:GridView ID="grdAssessments" runat="server" AllowPaging="true" PageSize="5" OnPageIndexChanging="grdAssessments_PageIndexChanging">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
