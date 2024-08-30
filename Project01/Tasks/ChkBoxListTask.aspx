<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChkBoxListTask.aspx.cs" Inherits="Project01.Tasks.ChkBoxListTask" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web06</title>
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


            <asp:CheckBoxList ID="cblSubject" runat="server">

            </asp:CheckBoxList>
            
            <br />
            
            <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" />

            <br />
            <br />

            <asp:Label ID="lblShow" runat="server" EnableViewState="False"></asp:Label>
        </div>
    </form>
</body>
</html>
