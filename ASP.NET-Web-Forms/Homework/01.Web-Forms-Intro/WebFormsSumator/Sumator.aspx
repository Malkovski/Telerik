<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sumator.aspx.cs" Inherits="WebFormsSumator.Sumator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Sumator Web Forms</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <h2>Sumator</h2>
        <asp:Label ID="lbFirst" runat="server">First Number</asp:Label>
        <asp:TextBox ID="tbFirstNuber" runat="server"></asp:TextBox>
        <asp:Label ID="lbSecond" runat="server">Second Number</asp:Label>
        <asp:TextBox ID="tbSecondNumber" runat="server"></asp:TextBox>
        <asp:Button ID="btnSum" runat="server" Text="Sum me!" OnClick="ButtonSumator"/>
        <asp:Label ID="lblSum" runat="server">Result</asp:Label>
        <asp:TextBox ID="Sum" runat="server"></asp:TextBox>
    </div>
    </form>
</body>
</html>
