<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListBox.aspx.cs" Inherits="Project01.ListControl.ListBox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListBox ID="lstbCountry" runat="server" SelectionMode="Multiple">
                <asp:ListItem Value="91">India</asp:ListItem>
                <asp:ListItem Value="92">SriLanka</asp:ListItem>
                <asp:ListItem Value="93">Bangladesh</asp:ListItem>
                <asp:ListItem Value="94">USA</asp:ListItem>
                <asp:ListItem Value="95">Canada</asp:ListItem>
                <asp:ListItem Value="96">Nepal</asp:ListItem>
            </asp:ListBox>
            <br />

            <br />

            <asp:Button ID="btnDisplay" runat="server" Text="Dispaly Selection" OnClick="btnDisplay_Click" />

            <br />

            <br />

            <asp:Label ID="lblResult" runat="server" EnableViewState="False"></asp:Label>
        </div>
    </form>
</body>
</html>
