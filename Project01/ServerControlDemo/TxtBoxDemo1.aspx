<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TxtBoxDemo1.aspx.cs" Inherits="Project01.ServerControlDemo.TxtBoxDemo1" %>

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
                <div class="col-md-4">Text Box 1
                    :&nbsp;
                    <asp:TextBox ID="txtBox1" runat="server" BackColor="#CCCCFF" BorderColor="#666666" BorderStyle="Dashed" BorderWidth="3px"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Button ID="btnCopy" runat="server" Text="Copy" OnClick="btnCopy_Click" />
                </div>
                <div class="col-md-4">Text Box 2&nbsp; : <asp:TextBox ID="txtBox2" runat="server" BackColor="#CCCCFF" BorderColor="#333333" BorderStyle="Solid"></asp:TextBox>
                </div>
            </div>
        </div>
    </form>
    </body>
</html>
