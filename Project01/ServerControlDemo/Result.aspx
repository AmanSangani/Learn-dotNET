<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="Project01.ServerControlDemo.Result" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Bootstrap/css/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="~/Bootstrap/js/bootstrap.min.js"></script>
</head>
<body class="bg-dark">
    <form id="form1" runat="server">
        <div class="container mt-5 w-50">
            <div class="bg-secondary p-4 border border-warning rounded ">
                <asp:Label CssClass="col-sm-2 col-form-label" ID="lbl1" runat="server">Maths : </asp:Label>
                <asp:TextBox CssClass="form-control-sm border-0" ID="txtSub1" runat="server" MaxLength="3"></asp:TextBox>
                <br />
                <br />
                <asp:Label CssClass="col-sm-2 col-form-label" ID="lbl2" runat="server">Physics : </asp:Label>
                <asp:TextBox CssClass="form-control-sm border-0" ID="txtSub2" runat="server" MaxLength="3"></asp:TextBox>
                <br />
                <br />
                <asp:Label CssClass="col-sm-2 col-form-label" ID="lbl3" runat="server">Chemistry : </asp:Label>
                <asp:TextBox CssClass="form-control-sm border-0" ID="txtSub3" runat="server" MaxLength="3"></asp:TextBox>
                <br />
                <br />
                <asp:Label CssClass="col-sm-2 col-form-label" ID="lbl4" runat="server">Biology : </asp:Label>
                <asp:TextBox CssClass="form-control-sm border-0" ID="txtSub4" runat="server" MaxLength="3"></asp:TextBox>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;
                <asp:Button CssClass="btn btn-outline-warning" ID="Button1" runat="server" Text="Calculate" OnClick="Button1_Click" />

                <br />
                <br />
                <asp:Label CssClass="col-sm-2 col-form-label" ID="Label1" runat="server">Percentage : </asp:Label>
                <asp:Label CssClass="col-sm-2 col-form-label" ID="lblPercentage" runat="server"></asp:Label>
                <br />
                <br />
                <asp:Label CssClass="col-sm-2 col-form-label" ID="Label2" runat="server">Remarks : </asp:Label>
                <asp:Label CssClass="col-sm-2 col-form-label" ID="lblRemarks" runat="server"></asp:Label>
            </div>

        </div>
    </form>
</body>
</html>
</html>
