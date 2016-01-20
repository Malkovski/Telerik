<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerateWithHtmlControls.aspx.cs" Inherits="GenerateRandoms.GenerateWithHtmlControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div class="container">
         <form id="form1" runat="server">
            <div>
                <input id="lowRange" type="number" runat="server" value="from"/>
                <input id="topRange" type="number" runat="server" value="to"/>
                <input type="button" runat="server" id="ButtonGenerate" value="Generate random number" onserverclick="ButtonGenerate_ServerClick"/>
            </div>
        </form>
    </div>
</body>
</html>
