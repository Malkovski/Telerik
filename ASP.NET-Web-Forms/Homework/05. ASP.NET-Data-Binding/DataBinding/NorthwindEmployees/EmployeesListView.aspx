<%@ Page Title="EmployeesListView" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeesListView.aspx.cs" Inherits="NorthwindEmployees.EmployeesListView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView runat="server" ID="EmployeeListView" ItemType="NorthwindEmployees.Employee" OnPagePropertiesChanged="EmployeeListView_PagePropertiesChanged">
        <LayoutTemplate>
            <asp:PlaceHolder runat="server"  ID="itemPlaceholder"/>
            <asp:DataPager runat="server" ID="BeforeListDataPager"
                PagedControlID="EmployeeListView" 
                PageSize="3">
                <Fields>
                  <asp:NextPreviousPagerField ButtonType="Button"
                    ShowFirstPageButton="true"
                    ShowNextPageButton="false"
                    ShowPreviousPageButton="false" />
                  <asp:NumericPagerField ButtonCount="10" />
                  <asp:NextPreviousPagerField ButtonType="Button"
                    ShowLastPageButton="true"
                    ShowNextPageButton="false"
                    ShowPreviousPageButton="false"/>
                </Fields>
            </asp:DataPager>
        </LayoutTemplate>

        <ItemTemplate>
            <h3><%#: Item.FirstName + " " + Item.LastName %></h3>
                <table class="table table-striped table-hover">
                    <tr>
                        <td><b>Job Title: </b></td>
                        <td><%#: Item.Title %></td>
                    </tr>
                    <tr>
                        <td><b>Phone: </b></td>
                        <td><%#:Item.HomePhone %></td>
                    </tr>
                    <tr>
                        <td><b>Hire Date: </b></td>
                        <td><%#:Item.HireDate %></td>
                    </tr>
                    <tr>
                        <td><b>Notes: </b></td>
                        <td><%#:Item.Notes %></td>
                    </tr>
                </table>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>