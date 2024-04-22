<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calulator.aspx.cs" Inherits="JavaScript.Calulator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Enter two numbers:</h2>
        1st Number:&nbsp;&nbsp;
        <asp:TextBox ID="num1" runat="server" placeholder="First Number"></asp:TextBox>
        <br /><br />
        2nd number:&nbsp; <asp:TextBox ID="num2" runat="server" placeholder="Second Number"></asp:TextBox>
        <br /><br />
        <asp:Button ID="btnMultiply" runat="server" Text="Multiply" OnClick="btnMultiply_Click" />
        <asp:Button ID="btnDivide" runat="server" Text="Divide" OnClick="btnDivide_Click" />
        <br /><br />
        <asp:Label ID="lblResult" runat="server"></asp:Label>
    </form>
</body>
</html>