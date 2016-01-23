<%@ Page Title="EmployeesFormView" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeesFormView.aspx.cs" Inherits="NorthwindEmployees.EmployeesFormView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:FormView runat="server" ID="EmployeeFormView" AllowPaging="true" OnPageIndexChanging="EmployeeFormView_PageIndexChanging">
        <ItemTemplate>
            <h3><%#: Eval("FirstName") + " " + Eval("LastName") %></h3>
                <table class="table table-striped table-hover">
                    <tr>
                        <td><b>Job Title: </b></td>
                        <td><%#:Eval("Title") %></td>
                    </tr>
                    <tr>
                        <td><b>Phone: </b></td>
                        <td><%#:Eval("HomePhone") %></td>
                    </tr>
                    <tr>
                        <td><b>Hire Date: </b></td>
                        <td><%#:Eval("HireDate") %></td>
                    </tr>
                    <tr>
                        <td><b>Notes: </b></td>
                        <td><%#:Eval("Notes") %></td>
                    </tr>
                </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
