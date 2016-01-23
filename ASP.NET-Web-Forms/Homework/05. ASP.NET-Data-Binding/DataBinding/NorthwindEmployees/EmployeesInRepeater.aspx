<%@ Page Title="EmployeesInRepeater" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeesInRepeater.aspx.cs" Inherits="NorthwindEmployees.EmployeesInRepeater" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater runat="server" ID="EmployeeRepeater">
        <HeaderTemplate>
            <table  class="table table-striped table-hover">
                <tr>
                    <th>Name</th>
                    <th>Job Title</th>
                    <th>Phone</th>
                    <th>Hire Date</th>
                    <th>Notes</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#: Eval("FirstName") + " " + Eval("LastName") %></td>
                <td><%#:Eval("Title") %></td>
                <td><%#:Eval("HomePhone") %></td>
                <td><%#:Eval("HireDate") %></td>
                <td><%#: Eval("Notes") %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>