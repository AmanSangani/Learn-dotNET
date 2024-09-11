<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="ContactList.aspx.cs" Inherits="AddressBook.AdminPanel.Contacts.ContactList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <div class="row mt-4">
        <div class="col-md-8">
            <h2>Your Contacts</h2>
        </div>
        <div class="col-md-4 text-right">
            <asp:HyperLink ID="hlContactAdd" runat="server" CssClass="btn btn-dark" NavigateUrl="~/AdminPanel/Contacts/ContactAddEdit.aspx" Target="_self">Add</asp:HyperLink>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 m-2 text-white">
            <asp:GridView ID="gvContact" runat="server" AllowSorting="True" AutoGenerateColumns="False" OnRowCommand="gvContact_RowCommand">
                <Columns>

                    <asp:TemplateField HeaderText="Modify Data">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnDelete" CssClass="btn btn-danger btn-sm mr-3" runat="server" Text="Delete" 
                                CommandName="DeleteRecord" CommandArgument=<%# Eval("ContactID").ToString() + ";" + Eval("ContactImg").ToString() %>/>
<%--                            <asp:HyperLink ID="hlEdit" CssClass="btn btn-primary btn-sm mr-0" runat="server" Text="Edit"
                                NavigateUrl=<%# "~/AdminPanel/Contacts/ContactAddEdit.aspx?ContactID=" + Eval("ContactID").ToString()  %>
                                CommandName="EditRecord" CommandArgument=<%# Eval("").ToString() %>></asp:HyperLink>--%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="ContactName" HeaderText="Name" />
                    <asp:BoundField DataField="ContactNo" HeaderText="Number" />

                    <asp:TemplateField HeaderText="Photo">
                        <ItemTemplate>
                            <asp:Image ID="imgContactImg" runat="server" AlternateText="ContactImg" 
                                 ImageUrl='<%# Eval("ContactImg").ToString() %>' Height="50px"/>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
