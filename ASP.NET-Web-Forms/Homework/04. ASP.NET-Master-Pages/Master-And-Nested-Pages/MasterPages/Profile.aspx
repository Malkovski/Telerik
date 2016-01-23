<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="MasterPages.Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListViewProfile" runat="server">
            <LayoutTemplate>
                <h3>Profile</h3>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </LayoutTemplate>

            <ItemSeparatorTemplate>
                <hr />
            </ItemSeparatorTemplate>

            <ItemTemplate>
                <div class="product-description">
                    <h4><%#: Eval("fName") + " " + Eval("lName") %></h4>
                    <p> <%# "Family status: " + "<b>" + Eval("status") + "</b>" %></p>
                    <p> <%#: "Phome number: " + Eval("phone") %></p>
                </div>
            </ItemTemplate>
        </asp:ListView>
</asp:Content>
