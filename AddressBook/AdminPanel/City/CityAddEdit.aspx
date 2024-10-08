﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="CityAddEdit.aspx.cs" Inherits="AddressBook.AdminPanel.City.CityAddEdit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <div class="row">
        <div class="col-md-12 m-2">
            <asp:Label ID="lblAddEdit" runat="server"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="lblMsj" runat="server" EnableViewState="false"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <asp:Label ID="lblCountryCode" runat="server" Text="Country Name : "></asp:Label>
            <asp:RequiredFieldValidator ID="rfvCountryCode" runat="server" ErrorMessage="**" ControlToValidate="ddlCountryCode" Display="Dynamic" ForeColor="Red" InitialValue="-1" ValidationGroup="SaveData"></asp:RequiredFieldValidator>
            <asp:DropDownList ID="ddlCountryCode" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountryCode_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="col-md-3">
            <asp:Label ID="lblStateName" runat="server" Text="State Name : "></asp:Label>
            <asp:RequiredFieldValidator ID="rfvStateName" runat="server" ErrorMessage="**" ControlToValidate="ddlStateName" Display="Dynamic" ForeColor="Red" InitialValue="-1" ValidationGroup="SaveData"></asp:RequiredFieldValidator>
            <asp:DropDownList ID="ddlStateName" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>
        <div class="col-md-3">
            <asp:Label ID="lblCityCode" runat="server" Text="City Code : "></asp:Label>
            <asp:RequiredFieldValidator ID="rfvCityCode" runat="server" ErrorMessage="**" ControlToValidate="txtCityCode" Display="Dynamic" ForeColor="Red" ValidationGroup="SaveData"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtCityCode" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:Label ID="lblCityName" runat="server" Text="City Name : "></asp:Label>
            <asp:RequiredFieldValidator ID="rfvCityName" runat="server" ErrorMessage="**" ControlToValidate="txtCityName" Display="Dynamic" ForeColor="Red" ValidationGroup="SaveData"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtCityName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 text-center mt-5">
            <asp:Button ID="btnSave" CssClass=" btn btn-success" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="SaveData" />
            <asp:Button ID="btnCancel" CssClass=" btn btn-danger" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
        </div>
    </div>
</asp:Content>