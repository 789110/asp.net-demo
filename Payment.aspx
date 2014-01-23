<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="iPayyDemo__ASP.NET_.Payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Transaction Status:
        <asp:Label ID="paymentStatus" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        Extra Information:<br />
        <asp:Label ID="extraInfo" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
