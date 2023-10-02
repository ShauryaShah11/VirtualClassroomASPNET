<%@ Page Title="" Language="C#" MasterPageFile="~/project.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Project.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
        }

        .container {
            text-align: center;
            padding-top: 100px;
        }

        .logo {
            width: 200px; /* Adjust the size of your logo */
            margin-bottom: 20px;
        }

        .signin-button {
            background-color: #4285f4; /* Google blue */
            color: #fff;
            font-size: 18px;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .signin-button:hover {
            background-color: #357ae8; /* Slightly darker blue on hover */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <div class="container">
        <img class="logo" src="data:image/png;base64,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" alt="Your Logo">
        <h1>Welcome to Your Virtual Classroom</h1>
        <p>Unlock the power of online learning!</p>
        <asp:Button ID="btnLogin" runat="server" Text="Sign In" CssClass="btn btn-primary btn-block" OnClick="SignInButton_Click" />

    </div>
</asp:Content>
