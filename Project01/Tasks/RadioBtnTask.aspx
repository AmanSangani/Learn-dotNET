<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RadioBtnTask.aspx.cs" Inherits="Project01.Tasks.RadioBtnTask" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web02</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>CHARUSAT UNIVERSITY</h1>
            <p>&nbsp;</p>

            <h3>Select Your College : </h3>
            <asp:RadioButton ID="rbtnDEPSTAR" runat="server" GroupName="College" Text="DEPSTAR" />
            &nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="rbtnCSPIT" runat="server" GroupName="College" Text="CSPIT" />
            <br />
            <br />

            <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" />

            <br />
            <br />

            <h3>Select Your Branch :</h3>
            <asp:RadioButton ID="rbtnBranch1" runat="server" GroupName="Branch" Text="" Visible="False"/>
            &nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="rbtnBranch2" runat="server" GroupName="Branch" Text="" Visible="False"/>

            <br />
            <br />

            <asp:Button ID="btnDispaly" runat="server" Text="Result" OnClick="btnDispaly_Click" />

            <br />
            <br />

            <asp:Label ID="lblTest" runat="server" EnableViewState="False"></asp:Label>

        </div>
    </form>
</body>
</html>
