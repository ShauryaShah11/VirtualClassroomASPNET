<%@ Page Language="C#" MasterPageFile="~/project.Master" CodeBehind="login.aspx.cs" Inherits="Project.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .text-danger {
    color: #721c24; /* Red color for danger messages */
    font-size: 16px; /* Adjust the font size as needed */
    /* Add more styling as needed */
}

    </style>
    <!-- Link to Bootstrap CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <h2 class="card-title text-center">Login</h2>
                        <hr />

                            <div class="text-center">
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger"></asp:Label>
                            </div>



                        <div class="form-group">
                            <asp:TextBox ID="txtLoginEmail" runat="server" CssClass="form-control" placeholder="Enter email" />
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtLoginPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter password" />
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary btn-block" OnClick="btnLogin_Click" />
                        </div>

                        <div class="text-center mt-3">
                            <a href="register.aspx" class="btn btn-link">Register</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Link to Bootstrap JS and jQuery -->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</asp:Content>

