<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Current page: Login.aspx
        Current user: <%=HttpContext.Current.User.Identity.ToString() %>
        <asp:Button ID="ButtonLogin" runat="server" Text="Log in as TestUser"  OnClick="Button1_Click"/>
        <asp:Button ID="ButtonLogout" runat="server" Text="Log out"  OnClick="Button2_Click"/>
    </div>
        Navigate to <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/WebForm.aspx">WebForm.aspx</asp:HyperLink>
    </form>
</body>
</html>
