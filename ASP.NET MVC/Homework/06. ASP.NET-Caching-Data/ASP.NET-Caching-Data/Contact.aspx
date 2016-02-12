<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ASP.NET_Caching_Data.Contact" %>

<%@ Register Src="~/CacheControl.ascx" TagPrefix="my" TagName="CacheControl" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <h3>Current time : <%= DateTime.Now %></h3>
    <h3>This time will change every 10 seconds:
        <my:CacheControl runat="server" />
    </h3>

</asp:Content>
