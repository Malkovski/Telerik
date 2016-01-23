<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyMobileBg.aspx.cs" Inherits="MyMobileBg.MyMobileBg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList runat="server" ID="Manufacturers" AutoPostBack="true" DataTextField="Name" DataValueField="Name" OnSelectedIndexChanged="Manufacturers_SelectedIndexChanged">
            <asp:ListItem Enabled="true">all</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList runat="server" ID="Models">
            <asp:ListItem>all</asp:ListItem>
        </asp:DropDownList>
        <asp:CheckBoxList runat="server" ID="ExtrasList" DataTextField="Name" DataValueField="Name">
        </asp:CheckBoxList>
        <asp:RadioButtonList runat="server" ID="EngineTypesList" RepeatDirection="Horizontal">
        </asp:RadioButtonList>
        <asp:Button Text="Show selection" runat="server" OnClick="Unnamed_Click"/>
        <hr />
        <asp:Literal runat="server" ID="ResultSelection"/>
    </div>
    </form>
</body>
</html>
