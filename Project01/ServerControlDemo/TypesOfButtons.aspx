<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TypesOfButtons.aspx.cs" Inherits="Project01.ServerControlDemo.TypesOfButtons" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="lbtnClickMe" runat="server" Text="Click Me" OnClick="lbtnClickMe_Click"></asp:LinkButton>
            <br />
            <br />
            <asp:ImageButton ID="imgbtnClickMe" runat="server" ImageUrl="https://charusat.online/images/CHARUSAT_Online_Logo.png" OnClick="imgbtnClickMe_Click" style="margin-right: 0px" Width="276px" />
            <br />
            <br />
            <asp:Button ID="btnClickMe" runat="server" Text="Click Me" OnClick="btnClickMe_Click" />

            <br />
            <br />
            <br />

            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
