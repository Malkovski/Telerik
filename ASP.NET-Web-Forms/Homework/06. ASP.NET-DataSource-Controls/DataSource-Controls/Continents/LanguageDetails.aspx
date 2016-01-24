<%@ Page Title="Language Detail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LanguageDetails.aspx.cs" Inherits="Continents.LanguageDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:FormView runat="server" ID="LanguageDetail" ItemType="Continents.Models.Language" SelectMethod="LanguageDetail_GetItem" Width="90%">
        <ItemTemplate>
            <h2><%#: Item.Name %></h2>
                <div class="row">
                    <div class="col-md-4">
                        NAME:
                    </div>
                    <div class="col=md-8">
                        <%#: Item.Name %>
                    </div>
                </div>
        </ItemTemplate>
    </asp:FormView>

</asp:Content>
