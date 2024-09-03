<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="CityList.aspx.cs" Inherits="AddressBook.AdminPanel.City.CityList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <div class="row mt-4">
        <div class="col-md-8">
            <h2>List of City</h2>
        </div>
        <div class="col-md-4 text-right">
            <asp:HyperLink ID="hlCityAdd" runat="server" CssClass="btn btn-dark" NavigateUrl="~/AdminPanel/City/CityAddEdit.aspx" Target="_self">Add</asp:HyperLink>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 m-2 text-white">
            <asp:GridView ID="gvCity" runat="server">
                <Columns>
                    <asp:BoundField DataField="CityCode" HeaderText="Code" />
                    <asp:BoundField DataField="CityName" HeaderText="City" />
                    <asp:BoundField DataField="StateName" HeaderText="State" />
                    <asp:BoundField DataField="CountryName" HeaderText="Country" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
