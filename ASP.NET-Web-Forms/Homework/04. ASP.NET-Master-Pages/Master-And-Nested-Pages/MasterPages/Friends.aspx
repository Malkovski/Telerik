<%@ Page Title="Friends" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Friends.aspx.cs" Inherits="MasterPages.Friends" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListViewFriends" runat="server">
            <LayoutTemplate>
                <h3>Friends list</h3>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </LayoutTemplate>

            <ItemSeparatorTemplate>
                <hr />
            </ItemSeparatorTemplate>

            <ItemTemplate>
                <div class="product-description">
                    <h4><%#: Eval("Name") + " known from " + Eval("from") %></h4>
            </ItemTemplate>
        </asp:ListView>
</asp:Content>
