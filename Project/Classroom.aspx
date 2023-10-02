<%@ Page Title="" Language="C#" MasterPageFile="~/project.Master" AutoEventWireup="true" CodeBehind="Classroom.aspx.cs" Inherits="Project.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Add your CSS styling here -->
    <style>
        /* Page header styling */
        .page-header {
            background-color: #4285f4;
            color: #fff;
            padding: 20px;
        }

        /* Classroom header styling */
        .classroom-header {
            background-color: #f8f9fa;
            padding: 20px;
        }

        /* Classroom content styling */
        .classroom-content {
            margin: 20px;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .classroom-content h2 {
            margin: 0;
        }

        .classroom-content p {
            margin-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="page-header">
            <h1>Mathematics Classroom</h1>
        </div>
        <div class="row">
            <div class="col-md-12">
                <!-- Classroom Header -->
                <div class="classroom-header">
                    <h2>About this Classroom</h2>
                    <p>Teacher: John Doe</p>
                    <p>Join Code: ABC123</p>
                    <p>Description: This is a Mathematics classroom for Grade 10.</p>
                </div>

                <!-- Classroom Content -->
      
                <div class="classroom-content">
                    <h2>Announcements</h2>

                        <ItemTemplate>
                            <!-- Add margin to the card -->
                            <div class="card mb-3 my-2">
                                <div class="card-body">
                                    <!-- Add margin to card title -->
                                    <h5 class="card-title mb-2">Demo</h5>
                                    <!-- Add margin to card text -->
                                    <p class="card-text mb-2">This is demo content</p>
                                    <!-- Add margin to the small text -->
                                    <p class="card-text"><small class="text-muted mb-0">Posted by shaurya on today</small></p>
                                </div>
                            </div>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <p>No announcements at the moment.</p>
                        </EmptyDataTemplate>
                </div>


            </div>
        </div>
    </div>
</asp:Content>
