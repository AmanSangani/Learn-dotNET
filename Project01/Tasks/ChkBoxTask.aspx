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

            <br />

        </div>
        <div>
            <h1>Select Your College :</h1>
            <p>
                <asp:CheckBox ID="chkDepstar" runat="server" Text="Depstar" />
                <br />
                <asp:CheckBox ID="chkCspit" runat="server" Text="Cspit" />
            </p>
            <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" />
            <p>
                <asp:CheckBox ID="chkBranch1" runat="server" Visible="False" />
            </p>
            <p>
                <asp:CheckBox ID="chkBranch2" runat="server" Visible="False" />
            </p>
            <p>
                <asp:CheckBox ID="chkBranch3" runat="server" Visible="False" />
            </p>
            <p>
                <asp:CheckBox ID="chkBranch4" runat="server" Visible="False" />
            </p>
            <asp:Button ID="btnResult" runat="server" Text="Result" Visible="False" OnClick="btnResult_Click" />

            <br />
            <br />

            <asp:Label ID="lblClg" runat="server" EnableViewState="False"></asp:Label>
        </div>
    </form>
</body>
</html>
