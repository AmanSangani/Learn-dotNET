<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="ContactList.aspx.cs" Inherits="AddressBook.AdminPanel.Contacts.ContactList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <div class="row mt-4">
        <div class="col-md-8">
            <h2>Your Contacts</h2>
        </div>
        <div class="col-md-4 text-right">
            <asp:HyperLink ID="hlContactAdd" runat="server" CssClass="btn btn-dark" NavigateUrl="~/AdminPanel/Contact/Add" Target="_self">Add</asp:HyperLink>
        </div>
    </div>
    <div>
        <asp:Label ID="lblMsj" runat="server"></asp:Label>
    </div>
    <div class="row">
        <div class="col-md-12 m-2 text-white">
            <%--<asp:GridView ID="gvContact" runat="server" AllowSorting="True" AutoGenerateColumns="False" OnRowCommand="gvContact_RowCommand">
                <Columns>

                    <asp:TemplateField HeaderText="Modify Data">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnDelete" CssClass="btn btn-danger btn-sm mr-3" runat="server" Text="Delete" 
                                CommandName="DeleteRecord" CommandArgument=<%# Eval("ContactID").ToString() + ";" + Eval("ContactImg").ToString() %>/>
                            <asp:HyperLink ID="hlEdit" CssClass="btn btn-primary btn-sm mr-0" runat="server" Text="Edit"
                                NavigateUrl=<%# "~/AdminPanel/Contacts/ContactAddEdit.aspx?ContactID=" + Eval("ContactID").ToString()  %>
                                CommandName="EditRecord" CommandArgument=<%# Eval("ContactID").ToString() %>></asp:HyperLink>
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
            </asp:GridView>--%>
            <asp:DataList ID="dlContact" runat="server" RepeatColumns="5" OnItemCommand="dlContact_ItemCommand" RepeatDirection="Horizontal" CellPadding="20">
                <ItemTemplate>
                    <asp:Image ID="imgContact" runat="server" AlternateText="ContactImg" CssClass="rounded img-fluid"
                        ImageUrl='<%# Eval("ContactImg") != null ? ResolveUrl(Eval("ContactImg").ToString()) : "~/images/default-image.png" %>' Height="150px"/>
                    <br />

                    <asp:Label ID="lblContactName" runat="server" Text='<%# Eval("ContactName") %>' CssClass="form-label"></asp:Label>
                    <br />
                    <asp:Label ID="lblContactNo" runat="server" Text='<%# Eval("ContactNo") %>' CssClass="form-label"></asp:Label>
                    <br />

                    <asp:LinkButton ID="LinkButton1" runat="server" Text="Delete" CommandName="DeleteRecord"
                        CommandArgument='<%# Eval("ContactID").ToString() + ";" + Eval("ContactImg").ToString() %>' CssClass="btn btn-danger btn-sm" />
                    <asp:HyperLink ID="HyperLink1" runat="server" Text="Edit" CssClass="btn btn-primary btn-sm" 
                        NavigateUrl='<%# "~/AdminPanel/Contact/Edit/" + Eval("ContactID").ToString() %>' />
                    <br />
                    <br />
                </ItemTemplate>
            </asp:DataList>

        </div>
    </div>
</asp:Content>
