<%@ Page Title="Languages" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Languages.aspx.cs" Inherits="Continents.Languages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <asp:Repeater runat="server" ID="RepeaterLanguages" ItemType="Continents.Models.Language" SelectMethod="RepeaterLanguages_GetData">
        <ItemTemplate>
            <div class="row">
                <asp:HyperLink NavigateUrl='<%# string.Format("~/LanguageDetails.aspx?id={0}", Item.Id) %>' runat="server" ID="LinkLanguage" Text='<%#: Item.Name %>'/>
            </div>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>
