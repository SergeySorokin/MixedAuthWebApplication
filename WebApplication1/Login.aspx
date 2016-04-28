<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MixedModeWebApplication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Current page: Login.aspx
        <br />
        Current user: <%=HttpContext.Current.User.Identity.Name %>
        <br />
        <asp:Button ID="ButtonLogin" runat="server" Text="Log in as TestUser"  OnClick="ButtonLogin_Click"/>      
        <asp:Button ID="ButtonWinLogin" runat="server" Text="Log in using windows credentials"  OnClick="ButtonWinLogin_Click"/>
    </div>
        Navigate to <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/WebForm.aspx">WebForm.aspx</asp:HyperLink>
    </form>
</body>
</html>
