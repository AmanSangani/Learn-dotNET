<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckBoxDemo.aspx.cs" Inherits="Project01.ServerControlDemo.CheckBoxDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="~/Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
     <link href="~/Bootstrap/css/bootstrap-theme.min.css" rel="stylesheet" />
     <script src="~/Bootstrap/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div>
                <asp:CheckBox ID="chkMale" runat="server" Text="Male" />&nbsp;
                <asp:CheckBox ID="chkFemale" runat="server" Text="Female" />&nbsp;
                <asp:CheckBox ID="chkOthers" runat="server" Text="Others" />&nbsp;

                <asp:Button ID="btnDisplay" runat="server" Text="Display" OnClick="btnDisplay_Click" /><br />

                <asp:Label ID="lblDisplay" runat="server" EnableViewState="False"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
