<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Button Event.aspx.cs" Inherits="JavaScript.Button_Event" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Button Event</title>
</head>
<body>
<h2 style="color: deeppink;">Click the Button</h2>
<button id="MyyButton">Click Here...!!</button>
 
    <div id="message"></div>
 
    <script>
        function handleClick() {
            var messageElement = document.getElementById('message');
            messageElement.innerHTML = "Button is been clicked...!";
        }


        var button = document.getElementById('MyyButton');


        button.addEventListener('click', handleClick);
</script>
</body>
</html>