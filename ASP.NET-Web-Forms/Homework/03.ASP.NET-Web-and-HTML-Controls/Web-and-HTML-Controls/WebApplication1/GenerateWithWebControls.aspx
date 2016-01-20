<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerateWithWebControls.aspx.cs" Inherits="GenerateRandoms.GenerateWithWebControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Literal ID="result" runat="server"></asp:Literal>
        <asp:TextBox ID="from" runat="server"></asp:TextBox>
        <asp:TextBox ID="to" runat="server"></asp:TextBox>
        <asp:Button ID="generate" runat="server" Text="Generate random number" OnClick="generate_Click" />
    </div>
    </form>
</body>
</html>
