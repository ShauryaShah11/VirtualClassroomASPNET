<%@ Page Title="Join Classroom" Language="C#" MasterPageFile="~/project.Master" AutoEventWireup="true" CodeBehind="JoinClassroom.aspx.cs" Inherits="Project.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Page container styles */
        .container {
            margin: 20px;
            padding: 20px;
        }

        /* Page header styles */
        .page-header {
            background-color: #4285f4;
            color: #fff;
            padding: 20px;
        }

        /* Content container styles */
        .content-container {
            background-color: #f8f9fa;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        /* Heading styles */
        h1 {
            font-size: 24px;
            margin-bottom: 20px;
        }

        /* Input field styles */
        input[type="text"] {
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        /* Button styles */
        .btn {
            background-color: #4285f4;
            color: #fff;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .btn:hover {
            background-color: #3579d8;
        }

        /* Error message styles */
        .error-message {
            color: #d93025;
            margin-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="page-header">
            <h1>Join a Classroom</h1>
        </div>
        <div class="content-container">
            <p>Enter the classroom code to join:</p>
            <asp:TextBox ID="classroomCode" runat="server" CssClass="form-control" placeholder="Enter Classroom Code"></asp:TextBox>
            <asp:Button ID="joinButton" runat="server" Text="Join" CssClass="btn btn-primary" OnClick="btnJoinClassroom_Click" />
            <asp:Label ID="errorMessage" runat="server" CssClass="error-message" OnClick="btnJoinClassroom_Click"></asp:Label>
        </div>
    </div>
</asp:Content>

