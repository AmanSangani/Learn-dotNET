<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="StatesList.aspx.cs" Inherits="AddressBook.AdminPanel.States.StatesList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <div class="row mt-4">
        <div class="col-md-8">
            <h2>List of States</h2>
        </div>
        <div class="col-md-4 text-right">
            <asp:HyperLink ID="hlStateAdd" runat="server" CssClass="btn btn-dark" NavigateUrl="~/AdminPanel/State/Add" Target="_self">Add</asp:HyperLink>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 m-2 text-white">
            <asp:GridView ID="gvState" runat="server" OnRowCommand="gvState_RowCommand">
                <Columns>

                    <asp:TemplateField HeaderText="Modify Data">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnDelete" CssClass="btn btn-danger btn-sm mr-3" runat="server" Text="Delete" 
                                CommandName="DeleteRecord" CommandArgument=<%# Eval("StateCode").ToString() %>/>
                            <asp:HyperLink ID="hlEdit" CssClass="btn btn-primary btn-sm mr-0" runat="server" Text="Edit"
                                NavigateUrl=<%# "~/AdminPanel/State/Edit/" + Eval("StateCode").ToString().Trim()  %>
                                CommandName="EditRecord" CommandArgument=<%# Eval("StateCode").ToString() %>></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="StateCode" HeaderText="Code" />
                    <asp:BoundField DataField="StateName" HeaderText="State" />
                    <asp:BoundField DataField="StateCapital" HeaderText="Capital" />
                    <asp:BoundField DataField="CountryName" HeaderText="Country" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
