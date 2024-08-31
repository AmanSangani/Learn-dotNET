<%@ Page Title="" Language="C#" MasterPageFile="~/Content/DemoMaster.Master" AutoEventWireup="true" CodeBehind="ContactPage.aspx.cs" Inherits="Project01.WebWithMasterPage.WebForm2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">

    <h2>Contact Us</h2>

    <p>CHARUSAT believes in the principles of Honesty, Integrity and Transparency. 
        The University aims to provide a harmonic environment to 
        all the students, employees, associates and stakeholders. 
        To facilitate these, various cells at University are established 
        like Grievance Redressal Cell, Equal Opportunity Cell,
        Women Development Cell, Cell for Prevention of Sexual Harassment and Anti-Ragging Cell. 
        Any stakeholder who finds any discrepancy under the aegis of 
        different cells can use this E-box to register a complaint
        and University will take further actions to resolve the problem.
    </p>

    <asp:Button ID="btnSkinTest" runat="server" Text="Skin Test"/>


</asp:Content>
