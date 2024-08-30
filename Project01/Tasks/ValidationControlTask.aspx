
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidationControlTask.aspx.cs" Inherits="Project01.Tasks.ValidationControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validation Control Task</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>

    <script type = "text/javascript">
        function ValidateTerms(sender, args) {
            if (document.getElementById("<%=chkTerms.ClientID %>").checked == true) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }
    </script>

</head>
<body class="bg-dark">
    <form id="form1" runat="server">
        <div class="text-success m-2">
            <asp:Label ID="lblSaveMsg" runat="server" EnableViewState="False"></asp:Label>
        </div>
        <div class="container m-5 p-3 text-white border border-2 border-white rounded">
            <div class="text-center mb-4">
                <h2>Student Enrollment Form</h2>
            </div>
            <div class="row g-3">
                <div class="col-md-6">
                    <asp:Label ID="lblName" CssClass="form-label" runat="server">Name:</asp:Label>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="**" ControlToValidate="txtName" ForeColor="Red" Display="Dynamic" ValidationGroup="Register"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server" Placeholder="Enter your name"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lblEnrollmentNo" CssClass="form-label" runat="server">Enrollment No:</asp:Label>
                    <asp:RequiredFieldValidator ID="rfvEnrollmentNo" runat="server" ErrorMessage="**" ForeColor="Red" ControlToValidate="txtEnrollmentNo" Display="Dynamic" ValidationGroup="Register"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtEnrollmentNo" CssClass="form-control" runat="server" Placeholder="Enter enrollment number"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lblInstitute" CssClass="form-label" runat="server">Institute Name:</asp:Label>
                    <asp:RequiredFieldValidator ID="rfvInstitute" runat="server" ErrorMessage="**" ForeColor="Red" ControlToValidate="ddlInstitute" Display="Dynamic" InitialValue="-1" ValidationGroup="Register"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="ddlInstitute" CssClass="form-select" runat="server">
                        <asp:ListItem Value="-1">Select Institute</asp:ListItem>
                        <asp:ListItem Value="Depstar">Depstar</asp:ListItem>
                        <asp:ListItem Value="Cspit">Cspit</asp:ListItem>
                        <asp:ListItem Value="IIIM">IIIM</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lblDepartment" CssClass="form-label" runat="server">Department Name:</asp:Label>
                    <asp:RequiredFieldValidator ID="rfvDepartment" runat="server" ErrorMessage="**" ForeColor="Red" ControlToValidate="ddlDepartment" Display="Dynamic" InitialValue="-1" ValidationGroup="Register"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="ddlDepartment" CssClass="form-select" runat="server">
                        <asp:ListItem Value="-1">Select Department</asp:ListItem>
                        <asp:ListItem Value="CE">CE</asp:ListItem>
                        <asp:ListItem Value="CSE">CSE</asp:ListItem>
                        <asp:ListItem Value="IT">IT</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblSemester" CssClass="form-label" runat="server">Semester:</asp:Label>
                    <asp:TextBox ID="txtSemester" CssClass="form-control" runat="server" Placeholder="Enter semester"></asp:TextBox>
                    <asp:RangeValidator ID="rvSemester" runat="server" ErrorMessage="Enter Valid Semester" ControlToValidate="txtSemester" Display="Dynamic" ForeColor="Red" MaximumValue="8" MinimumValue="1" Type="Integer" ValidationGroup="Register"></asp:RangeValidator>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblBirthDate" CssClass="form-label" runat="server">Birth Date:</asp:Label>
                    <asp:TextBox ID="txtBirthDate" CssClass="form-control" runat="server" Placeholder="DD/MM/YYYY"></asp:TextBox>
                    <asp:CompareValidator ID="cvBirthDate" runat="server" ErrorMessage="Enter valid BirthDate" ControlToValidate="txtBirthDate" Display="Dynamic" ForeColor="Red" Operator="DataTypeCheck" Type="Date" ValidationGroup="Register"></asp:CompareValidator>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblEmail" CssClass="form-label" runat="server">Email:</asp:Label>
                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" Placeholder="Enter your email"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Enter Valid Email" ControlToValidate="txtEmail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" ValidationGroup="Register"></asp:RegularExpressionValidator>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lblMobile" CssClass="form-label" runat="server">Mobile:</asp:Label>
                    <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ErrorMessage="**" ForeColor="Red" ControlToValidate="txtMobile" Display="Dynamic" ValidationGroup="Register"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtMobile" CssClass="form-control" runat="server" Placeholder="Enter your mobile number" ControlToValidate="txtMobile"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revMobile" runat="server" ErrorMessage="Enter Valid Mobile No" ControlToValidate="txtMobile" Display="Dynamic" ForeColor="Red" ValidationExpression="^[6-9]\d{9}$" ValidationGroup="Register"></asp:RegularExpressionValidator>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lblPassword" CssClass="form-label" runat="server">Password:</asp:Label>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="**" ForeColor="Red" ControlToValidate="txtPassword" Display="Dynamic" ValidationGroup="Register"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" Placeholder="Enter password"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revPassword" runat="server" ErrorMessage="Minimum eight characters, at least one letter, one number and one special character" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Gray" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&amp;])[A-Za-z\d@$!%*#?&amp;]{8,}$" ValidationGroup="Register"></asp:RegularExpressionValidator>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lblRePassword" CssClass="form-label" runat="server">Retype Password:</asp:Label>
                    <asp:RequiredFieldValidator ID="rfvRePassword" runat="server" ErrorMessage="**" ForeColor="Red" ControlToValidate="txtRePassword" Display="Dynamic" ValidationGroup="Register"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtRePassword" CssClass="form-control" runat="server" TextMode="Password" Placeholder="Retype password"></asp:TextBox>
                    <asp:CompareValidator ID="cvRePassword" runat="server" ErrorMessage="Password does not match" ControlToCompare="txtPassword" ControlToValidate="txtRePassword" Display="Dynamic" ForeColor="Red" ValidationGroup="Register"></asp:CompareValidator>
                </div>
            </div>

            <div class="text-center mt-4">
                <asp:Label ID="lblTerms" CssClass="form-check-label" runat="server" Text="Agree to Terms &amp; Conditions"></asp:Label>
                <asp:CustomValidator ID="cstvTerms" runat="server" ErrorMessage="**" ForeColor="Red" ClientValidationFunction="ValidateTerms" Display="Dynamic"></asp:CustomValidator>
                <asp:CheckBox ID="chkTerms" runat="server" CssClass="ms-2" ControlToValidate="chkTerms" />
            </div>

            <div class="d-flex justify-content-center mt-4">
                <asp:Button ID="btnSave" CssClass="btn btn-success btn-lg" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="Register" />
            </div>
        </div>
    </form>
</body>
</html>
