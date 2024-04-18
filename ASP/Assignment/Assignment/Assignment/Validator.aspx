<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="Assignment.Validator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .yellow-textbox {
            background-color: yellow;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Validation</h2>
            <p>Insert your the Details:</p>
            <div>
                <asp:Label ID="lblName" runat="server" AssociatedControlID="txtName">Name:</asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtName" runat="server" CssClass="yellow-textbox"></asp:TextBox>
                <br />
                <br />
            </div>
            <div>
                <asp:Label ID="lblFamilyName" runat="server" AssociatedControlID="txtFamilyName">Family Name:</asp:Label>
                &nbsp;
                <asp:TextBox ID="txtFamilyName" runat="server" CssClass="yellow-textbox"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<span style="color: red;">*</span> differs from name<br />
                <br />
            </div>
            <div>
                <asp:Label ID="lblAddress" runat="server" AssociatedControlID="txtAddress">Address:</asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtAddress" runat="server" CssClass="yellow-textbox"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<span style="color: red;">*</span>atleast 2 chars<br />
                <br />
            </div>
            <div>
                <asp:Label ID="lblCity" runat="server" AssociatedControlID="txtCity">City:</asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtCity" runat="server" CssClass="yellow-textbox"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: red;"> *</span>atleast 2 chars<br />
                <br />
            </div>
            <div>
                <asp:Label ID="lblZipCode" runat="server" AssociatedControlID="txtZipCode">Zip Code:</asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtZipCode" runat="server" CssClass="yellow-textbox"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: red;">*</span>(xxxxx)<br />
                <br />
            </div>
            <div>
                <asp:Label ID="lblPhone" runat="server" AssociatedControlID="txtPhone">Phone:</asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtPhone" runat="server" CssClass="yellow-textbox"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: red;">*</span>(xx-xxxxxxx or xxx-xxxxxxx)<br />
                <br />
            </div>
            <div>
                <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail">Email:</asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtEmail" runat="server" CssClass="yellow-textbox"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: red;"><a href="mailto:*examaple@example.com">*</a></span><a href="mailto:*examaple@example.com">examaple@example.com</a><br />
                <br />
            </div>
            <div>
                <asp:Button ID="btnCheck" runat="server" Text="Check" OnClick="btnCheck_Click" />
            </div>
            <h4>&nbsp;</h4>
             <div id="details" runat="server">
          
            </div>
        </div>
    </form>
</body>
</html>
