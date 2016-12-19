<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="POC3.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Olá <%=User.Identity.Name %>!!!
        <%= User.Identity.IsAuthenticated %>
        <%= User.Identity.AuthenticationType %>
    </div>
    <asp:Button ID="BtnLogout" Text="Logout" runat="server"/>
    </form>
</body>
</html>
