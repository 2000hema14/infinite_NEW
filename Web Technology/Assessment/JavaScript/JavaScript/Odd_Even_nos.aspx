<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Odd_Even_nos.aspx.cs" Inherits="JavaScript.Odd_Even_nos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Button  Event</title>
</head>
<body>
<h2 style="color: blue;">Click the Button</h2>
<button id="MyyButton">Click Here...!!</button>
 
   
<div id="message"></div>
 
   
<div id="clickCount">Button Click Count: 0</div>
 
    <script>
        var clickCount = 0;

        function handleClick() {
            clickCount++;
            var messageElement = document.getElementById('message');
            messageElement.innerHTML = "Button is been clicked..!";
            var clickCountElement = document.getElementById('clickCount');
            clickCountElement.innerHTML = "Button Click Count is : " + clickCount;
        }


        var button = document.getElementById('MyyButton');


        button.addEventListener('click', handleClick);
</script>
</body>
</html>