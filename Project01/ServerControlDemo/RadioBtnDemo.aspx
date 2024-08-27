<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RadioBtnDemo.aspx.cs" Inherits="Project01.ServerControlDemo.RadioBtnDemo" %>

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
                <asp:RadioButton ID="rbtnMale" runat="server" Text="Male" GroupName="gender" />
                <asp:RadioButton ID="rbtnFemale" runat="server" Text="Female" GroupName="gender" />
                <asp:RadioButton ID="rbtnOthers" runat="server" Text="Others" GroupName="gender" />

                <asp:Button ID="btnDisplay" runat="server" Text="Display" OnClick="btnDisplay_Click" /><br />

                <asp:Label ID="lblDisplay" runat="server" EnableViewState="False"></asp:Label>

                <asp:HyperLink ID="hlResult" runat="server" Text="Result" NavigateUrl="~/ServerControlDemo/Result.aspx" Target="_blank"></asp:HyperLink>

                <br />

                <asp:Image ID="imgLogo" runat="server" ImageUrl="https://images.pexels.com/photos/27438918/pexels-photo-27438918/free-photo-of-a-beach-with-rocks-and-sand-at-sunset.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2" Height="424px" Width="640px" />
            </div>
        </div>
    </form>
</body>
</html>
