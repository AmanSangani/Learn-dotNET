<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="ContactAddEdit.aspx.cs" Inherits="AddressBook.AdminPanel.Contacts.ContactAddEdit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <div class="row">
        <div class="col-md-12 m-2">
            <h2>Contact Add / Edit</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="lblMsj" runat="server" EnableViewState="false"></asp:Label>
        </div>
    </div>
    <div class="row" forecolor="#CC0000">
        <div class="col-md-4">
            <asp:Label ID="lblContactName" runat="server" Text="Contact Name : "></asp:Label>
            <asp:RequiredFieldValidator ID="rfvContactName" runat="server" ErrorMessage="**" ControlToValidate="txtContactName" Display="Dynamic" ForeColor="Red" ValidationGroup="SaveData"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtContactName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <asp:Label ID="lblContactNo" runat="server" Text="Contact No. : "></asp:Label>
            <asp:RequiredFieldValidator ID="rfvContactNo" runat="server" ErrorMessage="**" ControlToValidate="txtContactNo" Display="Dynamic" ForeColor="Red" ValidationGroup="SaveData"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revContactNo" runat="server" ErrorMessage="Enter Valid Mobile No." ControlToValidate="txtContactNo" Display="Dynamic" ForeColor="Red" ValidationExpression="^(\+91[\-\s]?)?[0]?(91)?[789]\d{9}$"></asp:RegularExpressionValidator>
            <asp:TextBox ID="txtContactNo" CssClass="form-control" runat="server"></asp:TextBox>            
        </div>
        <div class="col-md-4">
            <asp:Label ID="lblContactImg" runat="server" Text="Contact Image : "></asp:Label>
            <asp:RequiredFieldValidator ID="rfvContactImg" runat="server" ErrorMessage="**" ControlToValidate="fuContactImg" Display="Dynamic" ForeColor="Red" ValidationGroup="SaveData"></asp:RequiredFieldValidator>
            <asp:FileUpload ID="fuContactImg" CssClass="form-control" runat="server" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-8 mt-4">
            <asp:Label ID="lblContactCategory" runat="server" Text="Category : "></asp:Label>
            <asp:CheckBoxList ID="cblContactCategory" CssClass="" runat="server" RepeatColumns="10" CellSpacing="100" CellPadding="2" RepeatLayout="Table">
                
            </asp:CheckBoxList>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 text-center mt-5">
            <asp:Button ID="btnSave" CssClass=" btn btn-success" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="SaveData" />
            <asp:Button ID="btnCancel" CssClass=" btn btn-danger" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
        </div>
    </div>
</asp:Content>
