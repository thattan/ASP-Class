<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Hello World
            <asp:Button ID="btnEnter" runat="server" Text="Button" OnClick="btnEnter_Click" />
            <br />
            <asp:Label ID="lblOutput" runat="server" Text="Label"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
