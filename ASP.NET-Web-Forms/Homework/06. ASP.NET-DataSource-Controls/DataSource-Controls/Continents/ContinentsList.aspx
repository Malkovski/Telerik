<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContinentsList.aspx.cs" Inherits="Continents.ContinentsList" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:ListBox runat="server" ID="ListBoxContinents" ItemType="Continents.Models.Continent" Width="100%"
        SelectMethod="ListBoxContinents_SelectMethod" 
         OnSelectedIndexChanged="ListBoxContinents_SelectedIndexChanged"
         DataValueField="ID" DataTextField="Name" AutoPostBack="True">
        
    </asp:ListBox>
</asp:Content>
