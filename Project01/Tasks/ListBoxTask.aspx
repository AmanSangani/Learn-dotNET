<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListBoxTask.aspx.cs" Inherits="Project01.Tasks.ListBoxTask" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web05</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Country Name : <asp:TextBox ID="txtCountryName" runat="server"></asp:TextBox>
            Country Code : <asp:TextBox ID="txtCountryCode" runat="server"></asp:TextBox>

            &nbsp;<asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" />

            <br />
            <br />

            New Country Name :
            <asp:TextBox ID="txtNewCountryName" runat="server"></asp:TextBox>
            &nbsp;New Country Code :
            <asp:TextBox ID="txtNewCountryCode" runat="server"></asp:TextBox>

            &nbsp<asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />


            <br />
            <br />

            <asp:Label ID="lblMsg" runat="server"></asp:Label>

            <hr />
            <table>

                <tr>
                    <td>
                        <asp:ListBox ID="lstbCountry" runat="server" SelectionMode="Multiple">
                            
                        </asp:ListBox>
                    </td>
                    <td>
                        <asp:Button ID="btnMoveRight" runat="server" Text=">" OnClick="btnMoveRight_Click" />
                        <asp:Button ID="btnMoveRightAll" runat="server" Text=">>" OnClick="btnMoveRightAll_Click" />
                        <asp:Button ID="btnMoveLeft" runat="server" Text="<" OnClick="btnMoveLeft_Click" />
                        <asp:Button ID="btnMoveLeftAll" runat="server" Text="<<" OnClick="btnMoveLeftAll_Click" />
                    </td>
                    <td>
                        <asp:ListBox ID="lstbMoved" runat="server" SelectionMode="Multiple">
                            
                        </asp:ListBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
