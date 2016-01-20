<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Greeting.aspx.cs" Inherits="Greeting.Greeting" %>

<!DOCTYPE html>
<script runat="server">
   protected String GreetMe()
   {
       var a = "From aspx: Hello, ";
       string b;
       if (this.tbMyName.Text == "")
       {
            b = "whoever you are!";
       }
       else
       {
           b = this.tbMyName.Text.ToString();
       }
        
       
       return a + b;
   }
   
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1><%=GreetMe()%></h1>
        <asp:Literal ID="greeting" runat="server"></asp:Literal>
        <asp:Label ID="lblMyName" runat="server">Enter your name please!</asp:Label>
        <asp:TextBox ID="tbMyName" runat="server" ></asp:TextBox>

        <asp:Button ID="btnGreet" runat="server" OnClick="Greet" Text="Greet" />
    </div>
    </form>
</body>
</html>
