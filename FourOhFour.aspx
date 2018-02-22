<%@ Page Language="C#" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Eeep, where'd that page go wonder to?</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
        <h1>
            Oh my, I can't seem to find the page you requested!</h1>
        <p>
            DON'T PANIC, but the page you requested cannot be found.</p>
        <p>
            <asp:Label ID="YouCameFrom" runat="server" Font-Italic="True" ForeColor="#C00000"></asp:Label>&nbsp;</p>
    
    </div>
	</form>
</body>
</html>

