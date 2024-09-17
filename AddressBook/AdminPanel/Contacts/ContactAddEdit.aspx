<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="ContactAddEdit.aspx.cs" Inherits="AddressBook.AdminPanel.Contacts.ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <div class="container">
        <div class="row mb-4">
            <div class="col-md-12">
                <h2>Contact <asp:Label ID="lblAddEdit" runat="server"></asp:Label></h2>
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-md-12">
                <asp:Label ID="lblMsj" runat="server" EnableViewState="false" CssClass="text-danger"></asp:Label>
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="lblContactName" runat="server" Text="Contact Name: " CssClass="form-label"></asp:Label>
                    <asp:RequiredFieldValidator ID="rfvContactName" runat="server" ErrorMessage="**" ControlToValidate="txtContactName" Display="Dynamic" ForeColor="Red" ValidationGroup="SaveData"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtContactName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label ID="lblContactNo" runat="server" Text="Contact No.: " CssClass="form-label"></asp:Label>
                    <asp:RequiredFieldValidator ID="rfvContactNo" runat="server" ErrorMessage="**" ControlToValidate="txtContactNo" Display="Dynamic" ForeColor="Red" ValidationGroup="SaveData"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revContactNo" runat="server" ErrorMessage="Enter Valid Mobile No." ControlToValidate="txtContactNo" Display="Dynamic" ForeColor="Red" ValidationExpression="^(\+91[\-\s]?)?[0]?(91)?[789]\d{9}$"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="txtContactNo" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label ID="lblContactImg" runat="server" Text="Contact Image: " CssClass="form-label"></asp:Label>
                    <asp:RequiredFieldValidator ID="rfvContactImg" runat="server" ErrorMessage="**" ControlToValidate="fuContactImg" Display="Dynamic" ForeColor="Red" ValidationGroup="SaveData"></asp:RequiredFieldValidator>
                    <asp:Image ID="imgContact" runat="server" CssClass="img-thumbnail" Width="150px" Height="150px" />
                    <asp:HiddenField ID="hfContactImg" runat="server" />
                    <asp:FileUpload ID="fuContactImg" CssClass="form-control" runat="server" />
                </div>
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="lblContactCategory" runat="server" Text="Category: " CssClass="form-label"></asp:Label>
                    <asp:CheckBoxList ID="cblContactCategory" CssClass="form-check" runat="server" RepeatColumns="4" CellSpacing="10" CellPadding="2" RepeatLayout="Flow">
                    </asp:CheckBoxList>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 text-center">
                <asp:Button ID="btnSave" CssClass="btn btn-success me-2" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="SaveData" />
                <asp:Button ID="btnCancel" CssClass="btn btn-danger" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>
</asp:Content>
