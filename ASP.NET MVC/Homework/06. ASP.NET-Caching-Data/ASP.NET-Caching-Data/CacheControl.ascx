<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CacheControl.ascx.cs" Inherits="ASP.NET_Caching_Data.CacheControl" %>
<%@ OutputCache Duration="10" VaryByParam="none" Shared="false" %>

<div style="outline: 3px solid black; padding: 10px;">
    <h3>I am a cachable user control</h3>
    <h3>My time is: <%= DateTime.Now.ToString() %></h3>
</div>