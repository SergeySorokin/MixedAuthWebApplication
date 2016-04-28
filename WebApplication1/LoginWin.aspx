<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginWin.aspx.cs" Inherits="WebApplication1.LoginWin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Current page: LoginWin.aspx
        Current user: <%=HttpContext.Current.User.Identity.ToString() %>
    </div>
        Navigate to <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/WebForm1.aspx">WebForm.aspx</asp:HyperLink>
    </form>
</body>
</html>
