<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="StudentsAndCourses.Students" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="form-group">
        <asp:Label ID="lblFirstName" runat="server" CssClass="col-lg-2 control-label">First Name</asp:Label>    
        <asp:TextBox ID="tbFirstName" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Label ID="lblLastName" runat="server" CssClass="col-lg-2 control-label">Last Name</asp:Label>
        <asp:TextBox ID="tbLastName" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
         <asp:Label ID="lblFacultyNumber" runat="server" CssClass="col-lg-2 control-label">Faculty Number</asp:Label>
        <asp:TextBox ID="tbFacultyNumber" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
         <asp:Label ID="lblUniversities" runat="server" CssClass="col-lg-2 control-label">University</asp:Label>
        <asp:DropDownList ID="ddUniversities" runat="server" CssClass="form-control" AutoPostBack="False">
        </asp:DropDownList>
    </div>
    <div class="form-group">
        <asp:Label ID="lblSpecialty" runat="server" CssClass="col-lg-2 control-label">Specialty</asp:Label>
        <asp:DropDownList ID="ddSpecialties" runat="server"  CssClass="form-control" AutoPostBack="False">
        </asp:DropDownList>
    </div>
    <div class="form-group">
        <asp:Label ID="lblCourses" runat="server" CssClass="col-lg-2 control-label">Courses</asp:Label>
        <asp:ListBox ID="lbCourses" runat="server" CssClass="form-control" AutoPostBack="False" SelectionMode="Multiple" DataTextField="Name" DataValueField="Id">
            <asp:ListItem Value="1">Pasha</asp:ListItem>
            <asp:ListItem Value="2">Prehodi</asp:ListItem>
            <asp:ListItem Value="3">Vodopoi</asp:ListItem>
            <asp:ListItem Value="4">Doene</asp:ListItem>
        </asp:ListBox>
    </div>
    <div class="form-group">
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" CssClass="btn btn-md btn-primary"/>
    </div>
     <hr />
    <div class="well">
        <asp:Literal ID="LiteralResult" runat="server"></asp:Literal>
    </div>
    </div>
</asp:Content>
