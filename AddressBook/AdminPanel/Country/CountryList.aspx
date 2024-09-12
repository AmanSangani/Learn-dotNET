<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="CountryList.aspx.cs" Inherits="AddressBook.AdminPanel.Country.CountryList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <div class="row mt-4">
        <div class="col-md-8">
            <h2>List of Countries</h2>
        </div>
        <div class="col-md-4 text-right">
            <asp:HyperLink ID="hlCountryAdd" runat="server" CssClass="btn btn-dark" NavigateUrl="~/AdminPanel/Country/Add" Target="_self">Add</asp:HyperLink> 
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 m-2">
            <asp:Label ID="lblTemp" runat="server" EnableViewState="false"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 m-2 text-white">
            <asp:GridView ID="gvCountry" runat="server" OnRowCommand="gvCountry_RowCommand">
                <Columns>

                    <asp:TemplateField HeaderText="Modify Data">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnDelete" CssClass="btn btn-danger btn-sm mr-3" runat="server" Text="Delete" 
                                CommandName="DeleteRecord" CommandArgument=<%# Eval("CountryCode").ToString() %>/>
                            <asp:HyperLink ID="hlEdit" CssClass="btn btn-primary btn-sm mr-0" runat="server" Text="Edit"
                                NavigateUrl=<%# "~/AdminPanel/Country/Edit/" + Eval("CountryCode").ToString().Trim()  %>
                                CommandName="EditRecord" CommandArgument=<%# Eval("CountryCode").ToString() %>></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="CountryCode" HeaderText="Code" />
                    <asp:BoundField DataField="CountryName" HeaderText="Country" />
                    <asp:BoundField DataField="CountryCapital" HeaderText="Capital" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
