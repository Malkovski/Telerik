<%@ Page Title="Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="NorthwindEmployees.Details" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DetailsView runat="server" ID="EmpDetails" AutoGenerateRows="true"/>
    <asp:Button ID="ButtonBack" Text="Back" runat="server" OnClick="ButtonBack_Click"/>
</asp:Content>
