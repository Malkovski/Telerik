<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="NorthwindCustomers.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:GridView runat="server" ID="GridViewCustomers" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" 
        OnPageIndexChanging="GridViewCustomers_PageIndexChanging" PageSize="10" PagerSettings-Mode="NumericFirstLast" PagerSettings-Position="TopAndBottom" 
        OnSorting="GridView_Sorting">

        <Columns>
            
            <asp:BoundField HeaderText="Name" DataField="ContactName" SortExpression="ContactName" />
            <asp:BoundField HeaderText="Title" DataField="ContactTitle" SortExpression="ContactTitle" />
            <asp:BoundField HeaderText="Country" DataField="Country" SortExpression="Country"/>
            <asp:BoundField HeaderText="City" DataField="City" SortExpression="City" />

        </Columns>
    </asp:GridView>
</asp:Content>
