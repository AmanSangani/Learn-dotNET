<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChkBoxTask.aspx.cs" Inherits="Project01.Tasks.ChkBoxTask" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Select Your Fav Subject : </h1>

            <asp:CheckBox ID="chkALl" runat="server" Text="Select All" AutoPostBack="True" OnCheckedChanged="chkALl_CheckedChanged" />
            <asp:CheckBox ID="chkNone" runat="server" Text="Select None" AutoPostBack="True" OnCheckedChanged="chkNone_CheckedChanged" />
            <asp:CheckBox ID="chkReverse" runat="server" Text="Reverse Selection" AutoPostBack="True" OnCheckedChanged="chkReverse_CheckedChanged" />

            <br />
            <br />

            <asp:CheckBox ID="chkMaths" runat="server" Text="Maths"/>
            <br />
            <asp:CheckBox ID="chkPhysics" runat="server" Text="Physics"/>
            <br />
            <asp:CheckBox ID="chkChemistry" runat="server" Text="Chemistry"/>

            <br />
            <br />

            <asp:Button ID="btnDisplay" runat="server" Text="GO" OnClick="btnDisplay_Click" />

            <br />
            <br />

            <asp:Label ID="lblResult" runat="server"></asp:Label>

        </div>
    </form>
</body>
</html>
