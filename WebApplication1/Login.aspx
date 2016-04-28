<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Login.aspx
        <asp:Button ID="Button1" runat="server" Text="Button"  OnClick="Button1_Click"/>
    </div>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/WebForm1.aspx">WebForm.aspx</asp:HyperLink>
    </form>
</body>
</html>
