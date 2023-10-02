<%@ Page Language="C#" MasterPageFile="~/project.Master" CodeBehind="register.aspx.cs" Inherits="Project.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>User Registration</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 mb-5">
        <h2 class="text-center">User Registration</h2>
        <hr />
        <div class="text-center">
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger"></asp:Label>
        </div>
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="txtFirstName">First Name:</label>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" />
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="txtLastName">Last Name:</label>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" />
                </div>
            </div>
        </div>

        <div class="form-group">
            <label for="txtUsername">Username:</label>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" ValidationGroup="Register" />
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername"
                InitialValue="" ErrorMessage="Username is required." Display="Dynamic" ForeColor="Red" ValidationGroup="Register" />
        </div>

        <div class="form-group">
            <label for="txtPassword">Password:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" ValidationGroup="Register" />
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                InitialValue="" ErrorMessage="Password is required." Display="Dynamic" ForeColor="Red" ValidationGroup="Register" />
        </div>

        <div class="form-group">
            <label for="txtConfirmPassword">Confirm Password:</label>
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control" ValidationGroup="Register" />
            <asp:CompareValidator ID="cvPassword" runat="server" ControlToValidate="txtConfirmPassword"
                ControlToCompare="txtPassword" Operator="Equal" Type="String"
                ErrorMessage="Passwords must match." ForeColor="Red" ValidationGroup="Register" Display="Dynamic" />
        </div>

        <div class="form-group">
            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ValidationGroup="Register" />
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ErrorMessage="Enter a valid email address." ForeColor="Red" ValidationGroup="Register" Display="Dynamic" />
        </div>

        <div class="text-center">
            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-primary btn-register" OnClick="btnRegister_Click" ValidationGroup="Register" />
        </div>
    </div>
</asp:Content>
