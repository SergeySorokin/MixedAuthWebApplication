<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginWin.aspx.cs" Inherits="MixedModeWebApplication.LoginWin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Current page: LoginWin.aspx
        Current user: <%=HttpContext.Current.User.Identity.Name %>
    </div>
        Navigate to <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/WebForm.aspx">WebForm.aspx</asp:HyperLink>
    </form>
</body>
</html>
