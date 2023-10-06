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

        /* Style for joined users */
        .joined-users {
            margin-top: 20px;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .joined-users h2 {
            margin: 0;
        }

        .user-entry {
            display: flex;
            align-items: center;
            margin-bottom: 10px;
        }

        .user-avatar {
            width: 40px;
            height: 40px;
            border-radius: 50%;
            background-color: #ccc;
            margin-right: 10px;
            overflow: hidden;
        }

        .user-avatar img {
            max-width: 100%;
            max-height: 100%;
            object-fit: cover;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="page-header">
            <h1><asp:Label ID="lblClassroomName" runat="server" Text="Mathematics Classroom"></asp:Label></h1>
        </div>
        <div class="row">
            <div class="col-md-12">
                <!-- Classroom Header -->
                <div class="classroom-header">
                    <h2>About this Classroom</h2>
                    <p><asp:Label ID="lblTeacher" runat="server" Text="Teacher: John Doe"></asp:Label></p>
                    <p><asp:Label ID="lblJoinCode" runat="server" Text="Join Code: ABC123"></asp:Label></p>
                    <p><asp:Label ID="lblDescription" runat="server" Text="Description: This is a Mathematics classroom for Grade 10."></asp:Label></p>
                </div>

                <!-- Discussion Form -->
                <div class="classroom-content">
                    <h2>Discussions</h2>

                    <!-- Discussion Form -->
                    <div class="form-group">
                        <label for="discussionTitle">Discussion Title</label>
                        <asp:TextBox ID="discussionTitle" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="discussionContent">Discussion Content</label>
                        <asp:TextBox ID="discussionContent" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnSubmitDiscussion" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmitDiscussion_Click" />

                    <hr /> <!-- Add a horizontal line to separate the form from discussions -->

                    <!-- Discussion List -->
                    <asp:Repeater ID="rptDiscussions" runat="server">
                        <ItemTemplate>
                            <!-- Display discussions in a card-like format -->
                            <div class="card mb-3 my-2">
                                <div class="card-header">
                                    <h5 class="card-title"><%# Eval("Title") %></h5>
                                    <p class="card-text text-muted">Posted by <%# Eval("Username") %> on <%# Eval("DiscussionDate", "{0:MMMM dd, yyyy}") %></p>
                                </div>
                                <div class="card-body">
                                    <p class="card-text"><%# Eval("Description") %></p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Panel ID="noDiscussionsMessage" runat="server" Visible="false">
                        <p>No discussions yet.</p>
                    </asp:Panel>

                    <!-- Joined Users Section -->
                    <asp:Panel ID="joinedUsersSection" runat="server" CssClass="joined-users">
                        <h2>Joined Users</h2>
                        <asp:Repeater ID="rptJoinedUsers" runat="server">
                            <ItemTemplate>
                                <div class="user-entry">
                                    <asp:Label ID="lblUserName" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </asp:Panel>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
