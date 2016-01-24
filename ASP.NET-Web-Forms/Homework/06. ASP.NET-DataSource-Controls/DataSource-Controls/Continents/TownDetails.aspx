<%@ Page Title="Town Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TownDetails.aspx.cs" Inherits="Continents.TownDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:FormView runat="server" ID="FormViewTownDetails" ItemType="Continents.Models.Town" DataKeyNames="Id" Width="100%"
          SelectMethod="FormViewTownDetails_GetItem">
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
                        COUNTRY:
                    </div>
                    <div class="col=md-8">
                         <%#: Item.Country.Name %>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        LANGUAGE:
                    </div>
                    <div class="col=md-8">
                         <%#: Item.Country.Language.Name %>
                    </div>
                </div>
        </ItemTemplate>
    </asp:FormView>

    <asp:Panel runat="server">
        <a class="btn btn-md btn-primary" href="/Towns"> Back </a>
    </asp:Panel>

</asp:Content>
