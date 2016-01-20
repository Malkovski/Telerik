<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="StudentsAndCourses.Students" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblFirstName" runat="server">First Name</asp:Label>
        <br />
        <asp:TextBox ID="tbFirstName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblLastName" runat="server">Last Name</asp:Label>
        <br />
        <asp:TextBox ID="tbLastName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblFacultyNumber" runat="server">Faculty Number</asp:Label>
        <br />
        <asp:TextBox ID="tbFacultyNumber" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblUniversities" runat="server">University</asp:Label>
        <br />
        <asp:DropDownList ID="ddUniversities" runat="server" AutoPostBack="True" Width="180">
            <asp:ListItem Value="2">UNSS</asp:ListItem>
            <asp:ListItem Value="1">SU</asp:ListItem>
            <asp:ListItem Value="3">NBU</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblSpecialty" runat="server">Specialty</asp:Label>
        <br />
        <asp:DropDownList ID="ddSpecialties" runat="server" AutoPostBack="True" Width="180">
            <asp:ListItem Value="1">Ovcharche</asp:ListItem>
            <asp:ListItem Value="2">Cowboyche</asp:ListItem>
            <asp:ListItem Value="3">Kozarche</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblCourses" runat="server">Courses</asp:Label>
        <br />
         <asp:ListBox ID="lbCourses" runat="server" AutoPostBack="True" Width="180" 
             SelectionMode="Multiple" Height="56">
            <asp:ListItem Value="1">Pasha</asp:ListItem>
            <asp:ListItem Value="2">Prehodi</asp:ListItem>
            <asp:ListItem Value="3">Vodopoi</asp:ListItem>
            <asp:ListItem Value="3">Doene</asp:ListItem>
        </asp:ListBox>
        <br />
        <hr />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit"/>
        <br />
        <hr />
        <asp:Literal ID="LiteralResult" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
