<%@ Page Title="Countries" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Countries.aspx.cs" Inherits="Continents.Countries" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView runat="server" ID="GridViewCountries" ItemType="Continents.Models.Country" Width="100%"
        AllowPaging="true" AllowSorting="true" PageSize="15" DataKeyNames="Id" 
        SelectMethod="GridViewCountries_GetData"
        DeleteMethod="GridViewCountries_DeleteItem"
        UpdateMethod="GridViewCountries_UpdateItem"
        AutoGenerateColumns="false">

        <Columns>
            <asp:HyperLinkField HeaderText="Name" DataNavigateUrlFormatString="~/Details/CountryDetails.aspx?id={0}" DataNavigateUrlFields="Id" DataTextField="Name"/>
            <asp:BoundField DataField="Continent.Name" HeaderText="Continent" />
            <asp:CommandField HeaderText="Action" ShowEditButton="true" ShowDeleteButton="true" />
        </Columns>
      
    </asp:GridView>

</asp:Content>
