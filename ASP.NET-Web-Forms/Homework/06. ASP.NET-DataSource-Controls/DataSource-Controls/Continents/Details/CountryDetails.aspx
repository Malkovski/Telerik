<%@ Page Title="Country Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CountryDetails.aspx.cs" Inherits="Continents.CountryDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <asp:FormView runat="server" ID="FormViewCountryDetails" ItemType="Continents.Models.Country" DataKeyNames="Id" Width="100%"
          SelectMethod="FormViewCountryDetails_GetItem">
        <ItemTemplate>
            <h2><%#: Title %></h2>
                <div class="row">
                    <div class="col-md-4">
                        NAME:
                    </div>
                    <div class="col=md-8">
                        <%#: Item.Name %>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        POPULATION:
                    </div>
                    <div class="col=md-8">
                         <%#: Item.Population %>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        CONTINENT:
                    </div>
                    <div class="col=md-8">
                         <%#: Item.Continent.Name %>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        LANGUAGE:
                    </div>
                    <div class="col=md-8">
                         <%#: Item.Language.Name %>
                    </div>
                </div>
        </ItemTemplate>
    </asp:FormView>
    
    <asp:Panel runat="server">
        <a class="btn btn-md btn-primary" href="/Countries"> Back </a>
    </asp:Panel>

</asp:Content>
