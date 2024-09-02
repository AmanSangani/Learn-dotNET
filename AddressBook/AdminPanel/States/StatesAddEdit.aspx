<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="StatesAddEdit.aspx.cs" Inherits="AddressBook.AdminPanel.States.StatesAddEdit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <div class="row">
        <div class="col-md-12 m-2">
            <h2>States Add / Edit</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="lblMsj" runat="server" EnableViewState="false"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <asp:Label ID="lblStateCode" runat="server" Text="State Code : "></asp:Label>
            <asp:RequiredFieldValidator ID="rfvStateCode" runat="server" ErrorMessage="**" ControlToValidate="txtStateCode" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtStateCode" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:Label ID="lblStateName" runat="server" Text="State Name : "></asp:Label>
            <asp:RequiredFieldValidator ID="rfvStateName" runat="server" ErrorMessage="**" ControlToValidate="txtStateName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtStateName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:Label ID="lblStateCpaital" runat="server" Text="State Capital : "></asp:Label>
            <asp:RequiredFieldValidator ID="rfvStateCapital" runat="server" ErrorMessage="**" ControlToValidate="txtStateCapital" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtStateCapital" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:Label ID="lblCountryCode" runat="server" Text="Country Code : "></asp:Label>
            <asp:RequiredFieldValidator ID="rfvCountryCode" runat="server" ErrorMessage="**" ControlToValidate="txtCountryCode" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtCountryCode" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 text-center mt-5">
            <asp:Button ID="btnSave" CssClass=" btn btn-danger" runat="server" Text="Save" OnClick="btnSave_Click" />
        </div>
    </div>
</asp:Content>
