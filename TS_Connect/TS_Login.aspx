<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TS_Login.aspx.cs" Inherits="TS_Connect.TS_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" Text="Enter UserId"></asp:Label>
    <asp:TextBox ID="textBox_user" runat="server" class="badge-pill" ></asp:TextBox>
        <br />
          <asp:Label runat="server" Text="Enter Password"></asp:Label>
        <asp:TextBox ID="textBox_password" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button ID="Button1"  class="btn btn-primary" runat="server" Text="Button" />
    
    </div>
    </form>
</body>
</html>
