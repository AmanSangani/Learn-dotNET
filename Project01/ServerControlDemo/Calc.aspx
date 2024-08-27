<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calc.aspx.cs" Inherits="Project01.ServerControlDemo.Calc" %>

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
    <div class="row">
        <div class="col-md-4">
            <asp:TextBox ID="txtNo1" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <asp:TextBox ID="txtNo2" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <asp:Button ID="btnAdd" runat="server" Text="Add(+)" OnClick="btnAdd_Click"/>
            <asp:Button ID="btnSub" runat="server" Text="Sub(-)" OnClick="btnSub_Click"/>
            <asp:Button ID="btnMultiply" runat="server" Text="Multiply(*)" OnClick="btnMul_Click"/>
            <asp:Button ID="btnDivide" runat="server" Text="Div(/)" OnClick="btnDiv_Click"/>
        </div>
        <div class="col-md-4">
            <asp:Label ID="lblAnswer" runat="server"></asp:Label>
        </div>
    </div>
</div>
    </form>
</body>
</html>
