<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Random.aspx.cs" Inherits="Random.Random" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formRandom" runat="server">
    <div>
        <input id="lowRange" type="number" runat="server" value="from"/>
        <input id="topRange" type="number" runat="server" value="to"/>
        <input type="button" runat="server" id="ButtonGenerate" value="Generate random number" onserverclick="ButtonGenerate_ServerClick"/>
    </div>
    </form>
</body>
</html>
