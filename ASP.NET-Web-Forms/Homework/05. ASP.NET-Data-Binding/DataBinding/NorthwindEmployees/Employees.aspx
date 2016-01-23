<%@ Page Title="Employees" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="NorthwindEmployees.Employees" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="EmployeeListGrid" AutoGenerateColumns="false" AllowPaging="true">
        <Columns>
            <asp:TemplateField HeaderText="Name" SortExpression="FirstName">
            <EditItemTemplate>
                
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server"
                    Text='<%# Bind("FirstName") %>'></asp:Label>
                <asp:Label ID="Label2" runat="server"
                    Text='<%# Eval("LastName") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
           
            <asp:HyperLinkField HeaderText="Details for" DataTextField="FirstName" DataNavigateUrlFields="EmployeeId" DataNavigateUrlFormatString="Details.aspx?id={0}"/>
        </Columns>
    </asp:GridView>
</asp:Content>
