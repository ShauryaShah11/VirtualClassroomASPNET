<%@ Page Title="" Language="C#" MasterPageFile="~/project.Master" AutoEventWireup="true" CodeBehind="ClassroomList.aspx.cs" Inherits="Project.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Add your CSS styling here -->
    <style>
        /* Page header styling */
        .page-header {
            background-color: #4285f4;
            color: #fff;
            padding: 20px;
        }

        /* Classroom card styling */
        .classroom-card {
            border: 1px solid #ccc;
            border-radius: 5px;
            margin: 20px;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .classroom-card h3 {
            margin: 0;
        }

        .classroom-card p {
            margin-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="page-header">
            <h1>Your Classrooms</h1>
        </div>
        <div class="row">
            <asp:Repeater ID="rptClassrooms" runat="server">
                <ItemTemplate>
                    <div class="col-md-4">
                        <div class="classroom-card">
                            <h3><%# Eval("ClassName") %></h3>
                            <p>Join Code: <%# Eval("ClassCode") %></p>
                            <p>Creation date: <%# Eval("CreationDate") %></p>

                            <a href="Classroom.aspx?code=<%# Eval("ClassCode") %>" class="btn btn-primary">Go to Classroom</a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

