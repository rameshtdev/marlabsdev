<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelfAssessment.aspx.cs" Inherits="AspNetWeb.SelfAssessment"%>
<%@ OutputCache Duration="15" VaryByParam="None" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <title></title>
</head>

<body>
    <form id="form1" runat="server" style="">
    <div>
    <table>
        <tr><td colspan="2">Self Assessment Page</td></tr>
        <tr><td>
            <asp:Label ID="lblFirstName" runat="server" Text="FirstName"></asp:Label>
            </td><td>
                <asp:TextBox ID="txtFirstName" runat="server" placeholder="Enter first name"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFirstName" ErrorMessage="FirstName is Required">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr><td>
            <asp:Label ID="lblLastName" runat="server" Text="LastName"></asp:Label>
            </td><td>
                <asp:TextBox ID="textLastName" runat="server" placeholder="Enter last name"></asp:TextBox>
            </td>
             <td>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="textLastName" ErrorMessage="LastName is Required">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr><td>
            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
            </td><td>
                <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter email"></asp:TextBox>
            </td>
             <td>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is Required">*</asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is not in Valid format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr><td>
            <asp:Label ID="lblAge" runat="server" Text="Age"></asp:Label>
            </td><td>
                <asp:TextBox ID="txtAge" runat="server" placeholder="Enter age"></asp:TextBox>
            </td>
             <td>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAge" ErrorMessage="Age is Required">*</asp:RequiredFieldValidator>
                 <asp:RangeValidator runat="server" ControlToValidate="txtAge" ErrorMessage="Age is not in allowed range" MinimumValue="18" MaximumValue="35" Type="Integer">*</asp:RangeValidator>
            </td>
        </tr>
        <tr><td>
            <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
            </td><td>
                <asp:RadioButtonList ID="rdGender" runat="server">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList>
            </td>
             <td>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="rdGender" ErrorMessage="Gender is Required">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr><td>
            <asp:Label ID="lblCountry" runat="server" Text="Country"></asp:Label>
            </td><td>
                <asp:DropDownList ID="ddlCountry" runat="server">
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
            <asp:Label ID="lblExpertise" runat="server" Text="Expertise"></asp:Label>
            </td><td>
                <asp:ListBox ID="lstExpertise" SelectionMode ="Multiple" runat="server"></asp:ListBox>
            </td>
             <td>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="lstExpertise" ErrorMessage="Expertise is Required">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr><td>
            <asp:Label ID="lblQualification" runat="server" Text="Qualification"></asp:Label>
            </td><td>
                <asp:CheckBoxList ID="chkQualification" runat="server">
                    <asp:ListItem>Master Degree - Completed</asp:ListItem>
                    <asp:ListItem>Master Degree - In Progress</asp:ListItem>
                    <asp:ListItem>Existing work Experience</asp:ListItem>
                </asp:CheckBoxList>
            </td> </tr>
        <tr><td colspan="2">
            <asp:Button ID="btnSumbit" runat="server" Text="Submit" OnClick="btnSumbit_Click" />
            </td></tr>
        <tr><td colspan="2">
            <asp:ValidationSummary runat="server" HeaderText="Errors:" DisplayMode="BulletList" ShowSummary="true"/>           

            </td></tr>
        <tr><td colspan="2">
              <asp:GridView ID="grdAssessments" runat="server" AllowPaging="true" PageSize="5" OnPageIndexChanging="grdAssessments_PageIndexChanging">
        </asp:GridView>
             </td></tr>
    </table>
    </div>
    </form>
</body>
</html>
