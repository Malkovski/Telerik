<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EscapingExample.aspx.cs" Inherits="Escaping.EscapingExample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="InputText" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="ShowText" runat="server" Text="Show escaped text" OnClick="ShowText_Click" />
        <br />
        <asp:Literal ID="LiteralText" runat="server" Mode="Encode"></asp:Literal>
        <asp:TextBox ID="EscapedText" runat="server"></asp:TextBox>
    </div>
    </form>
</body>
</html>
