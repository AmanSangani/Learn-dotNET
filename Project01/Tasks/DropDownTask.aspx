<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DropDownTask.aspx.cs" Inherits="Project01.Tasks.DropDownTask" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web04</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:TextBox ID="txtCountryName" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtCountryCode" runat="server"></asp:TextBox>

            <br />
            <br />

            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" />

            <br />

            <br />
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
            <br />
            <br />
            <hr />

            <asp:DropDownList ID="ddlCountry" runat="server">

            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
