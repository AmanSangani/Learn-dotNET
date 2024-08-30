<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Project01.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            UserName :
            <asp:TextBox ID="txtUserName" runat="server" BackColor="#CCFF99" BorderColor="Black" BorderStyle="Dashed" BorderWidth="3px" ForeColor="#666666" MaxLength="100">amanangani</asp:TextBox>
            <br />
            <br />
            Password :
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            Address :
            <asp:TextBox ID="txtAddress" runat="server" Columns="20" Height="100px" Rows="3" TextMode="MultiLine" Width="300px"></asp:TextBox>
        </div>
    </form>
</body>
</html>
