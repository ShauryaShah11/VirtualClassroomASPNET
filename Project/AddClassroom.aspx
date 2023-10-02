<%@ Page Title="" Language="C#" MasterPageFile="~/project.Master" AutoEventWireup="true" CodeBehind="AddClassroom.aspx.cs" Inherits="Project.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Add your CSS styling here -->
    <style>
        .container {
            margin-top: 50px;
            text-align: center;
        }

        .form-container {
            max-width: 500px;
            margin: 0 auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .form-container label {
            display: block;
            text-align: left;
            margin-bottom: 5px;
        }

        .form-container input[type="text"],
        .form-container textarea {
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 3px;
        }

        .form-container input[type="submit"] {
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 10px 20px;
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Create a Classroom</h2>
        <div class="form-container">
            <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
                <div class="form-group">
                    <label for="className">Classroom Name:</label>
                    <asp:TextBox ID="txtClassName" runat="server" CssClass="form-control" placeholder="Enter classroom name" Required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="classDescription">Classroom Description:</label>
                    <asp:TextBox ID="txtClassDescription" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Enter classroom description" Required="true"></asp:TextBox>
                </div>
                <asp:Button ID="btnCreateClassroom" runat="server" Text="Create Classroom" CssClass="btn btn-primary" OnClick="btnCreateClassroom_Click" />
        </div>
    </div>
</asp:Content>
