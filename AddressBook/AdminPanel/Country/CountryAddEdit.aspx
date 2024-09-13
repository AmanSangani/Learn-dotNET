<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="CountryAddEdit.aspx.cs" Inherits="AddressBook.AdminPanel.Country.CountryAddEdit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <div class="row">
        <div class="col-md-12 m-2">
            <h2>Country <asp:Label ID="lblAddEdit" runat="server"></asp:Label></h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="lblMsj" runat="server" EnableViewState="false"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Label ID="lblCountryCode" runat="server" Text="Country Code : "></asp:Label>
            <asp:RequiredFieldValidator ID="rfvCountryCode" runat="server" ErrorMessage="**" ControlToValidate="txtCountryCode" Display="Dynamic" ForeColor="Red" ValidationGroup="SaveValidation"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtCountryCode" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <asp:Label ID="lblCountryName" runat="server" Text="Country Name : "></asp:Label>
            <asp:RequiredFieldValidator ID="rfvCountryName" runat="server" ErrorMessage="**" ControlToValidate="txtCountryName" Display="Dynamic" ForeColor="Red" ValidationGroup="SaveValidation"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtCountryName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <asp:Label ID="lblCountryCpaital" runat="server" Text="Country Capital : "></asp:Label>
            <asp:RequiredFieldValidator ID="rfvCountryCapital" runat="server" ErrorMessage="**" ControlToValidate="txtCountryCapital" Display="Dynamic" ForeColor="Red" ValidationGroup="SaveValidation"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtCountryCapital" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 text-center mt-5">
            <asp:Button ID="btnSave" CssClass=" btn btn-success  mr-2" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="SaveValidation" />
            <asp:Button ID="btnCancel" CssClass=" btn btn-danger" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
        </div>
    </div>
</asp:Content>
