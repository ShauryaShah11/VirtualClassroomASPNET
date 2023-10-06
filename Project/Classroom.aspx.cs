using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace Project
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the 'code' parameter exists in the URL
                if (Request.QueryString["code"] != null)
                {
                    string classroomCode = Request.QueryString["code"].ToString();

                    // Fetch classroom data based on the code
                    Classroom classroom = GetClassroomDataByCode(classroomCode);

                    if (classroom != null)
                    {
                        // Populate page elements with classroom data
                        lblClassroomName.Text = classroom.ClassName;
                        lblTeacher.Text = "Teacher: " + classroom.UserName;
                        lblJoinCode.Text = "Join Code: " + classroom.ClassCode;
                        lblDescription.Text = "Description: " + classroom.ClassDescription;

                        LoadAndDisplayDiscussions(classroomCode);
                        LoadAndDisplayJoinedUsers(classroomCode);
                    }
                    else
                    {
                        // Handle the case where the classroom with the given code doesn't exist.
                        // You might want to display an error message or redirect to an error page.
                        Response.Write("Classroom not found.");
                    }
                }
                else
                {
                    // Handle the case where the 'code' parameter is missing in the URL.
                    // You might want to display an error message or redirect to an error page.
                    Response.Write("Code parameter missing.");
                }
            }
        }
        private void LoadAndDisplayJoinedUsers(string classroomCode)
        {
            // Fetch joined users associated with the classroom (you'll need to implement this method)
            List<User> joinedUsers = GetJoinedUsersByClassroomCode(classroomCode);

            if (joinedUsers.Count > 0)
            {
                // Bind the joined users to the repeater
                rptJoinedUsers.DataSource = joinedUsers;
                rptJoinedUsers.DataBind();
            }
            else
            {
                // No joined users available, hide the section
                joinedUsersSection.Visible = false;
            }
        }

        private List<User> GetJoinedUsersByClassroomCode(string classroomCode)
        {
            List<User> joinedUsers = new List<User>();

            // Assuming you have a connection string in your web.config
            string connectionString = WebConfigurationManager.ConnectionStrings["classroomConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Define your SQL query to fetch joined users and the class owner
                string query = @"
                    SELECT U.UserName
                    FROM Users U
                    INNER JOIN ClassStudents M ON U.UserId = M.StudentId
                    INNER JOIN Classes C ON M.ClassId = C.ClassId
                    WHERE C.ClassCode = @ClassCode";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClassCode", classroomCode);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string username = reader["Username"].ToString();
                            joinedUsers.Add(new User { Username = username });
                        }
                    }
                }
            }

            return joinedUsers;
        }


        protected void btnSubmitDiscussion_Click(object sender, EventArgs e)
        {
            string title = discussionTitle.Text;
            string content = discussionContent.Text;

            // Retrieve the email from the session.
            string email = Session["Email"] as string;

            // Ensure that the email is not null before proceeding.
            if (string.IsNullOrEmpty(email))
            {
                // Handle the case where email is not available.
                Response.Write("User email not found.");
                return;
            }

            // Retrieve the corresponding UserId from the database based on the email.
            string userId = GetUserIdByEmail(email);

            if (string.IsNullOrEmpty(userId))
            {
                // Handle the case where UserId is not found.
                Response.Write("User not found.");
                return;
            }

            string classroomCode = Request.QueryString["code"].ToString();

            string classId = GetClassIdByCode(classroomCode);

            if (string.IsNullOrEmpty(classId))
            {
                // Handle the case where ClassId is not found.
                Response.Write("Class not found.");
                return;
            }

            // Generate a unique class code
            DateTime currentTime = DateTime.Now;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["classroomConnection"].ConnectionString;

            // Use parameterized query to prevent SQL injection
            string query = "INSERT INTO Discussions (ClassId, Title, Description, AuthorId, DiscussionDate) " +
                           "VALUES (@ClassId, @Title, @Description, @AuthorId, @DiscussionDate)";

            try
            {
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@ClassId", classId);
                        cmd.Parameters.AddWithValue("@Title", title);
                        cmd.Parameters.AddWithValue("@Description", content);
                        cmd.Parameters.AddWithValue("@AuthorId", userId);
                        cmd.Parameters.AddWithValue("@DiscussionDate", currentTime);

                        cmd.Connection = conn;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        // Redirect to the same classroom page after successful submission
                        Response.Redirect("Classroom.aspx?code=" + classroomCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("An error occurred while submitting the discussion. Please try again later.");
            }
        }
        private void LoadAndDisplayDiscussions(string classroomCode)
        {
            // Fetch discussions associated with the classroom (you'll need to implement this method)
            List<Discussion> discussions = GetDiscussionsByClassroomCode(classroomCode);

            if (discussions.Count > 0)
            {
                // Bind the discussions to a control like a Repeater for display
                rptDiscussions.DataSource = discussions;
                rptDiscussions.DataBind();
            }
            else
            {
                // No discussions available, display a message
                rptDiscussions.Visible = false; // Hide the Repeater
                noDiscussionsMessage.Visible = true; // Show a message
            }
        }

        private List<Discussion> GetDiscussionsByClassroomCode(string classroomCode)
        {
           
            DiscussionDataAccess dataAccess = new DiscussionDataAccess();
            return dataAccess.GetDiscussionsByClassroomCode(classroomCode);

        }

        private Classroom GetClassroomDataByCode(string code)
        {
            ClassroomDataAccess dataAccess = new ClassroomDataAccess();
            return dataAccess.GetClassroomDataByCode(code);
        }
        private string GetUserIdByEmail(string email)
        {
            // Define your connection string from web.config
            string connectionString = WebConfigurationManager.ConnectionStrings["classroomConnection"].ConnectionString;

            // Create a SQL connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Define your SQL query to retrieve UserId based on email
                string query = "SELECT UserId FROM Users WHERE Email = @Email";

                // Create a SQL command
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the query
                    command.Parameters.AddWithValue("@Email", email);

                    // Open the connection
                    connection.Open();

                    // Execute the query and retrieve UserId
                    object result = command.ExecuteScalar();

                    // Close the connection
                    connection.Close();

                    // Check if UserId was found
                    if (result != null)
                    {
                        return result.ToString();
                    }
                }
            }

            // If no UserId found, return an empty string or handle the situation as needed.
            return "";
        }
        private string GetClassIdByCode(string ClassCode)
        {
            // Define your connection string from web.config
            string connectionString = WebConfigurationManager.ConnectionStrings["classroomConnection"].ConnectionString;

            // Create a SQL connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Define your SQL query to retrieve UserId based on email
                string query = "SELECT ClassId FROM Classes WHERE ClassCode = @ClassCode";

                // Create a SQL command
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the query
                    command.Parameters.AddWithValue("@ClassCode", ClassCode);

                    // Open the connection
                    connection.Open();

                    // Execute the query and retrieve UserId
                    object result = command.ExecuteScalar();

                    // Close the connection
                    connection.Close();

                    // Check if UserId was found
                    if (result != null)
                    {
                        return result.ToString();
                    }
                }
            }

            // If no UserId found, return an empty string or handle the situation as needed.
            return "";
        }

    }
}
