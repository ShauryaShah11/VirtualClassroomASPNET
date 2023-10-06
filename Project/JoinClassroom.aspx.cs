using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Session["email"] as string;
            if (string.IsNullOrEmpty(email))
            {
                Response.Redirect("login.aspx");
            }
        }
        protected void btnJoinClassroom_Click(object sender, EventArgs e)
        {
            string email = Session["email"] as string;
            if (string.IsNullOrEmpty(email))
            {
                Response.Redirect("login.aspx");
            }
            string userId = GetUserIdByEmail(email);
            string classCode = classroomCode.Text;

            bool classCodeExists = CheckIfClassCodeExists(classCode, userId);

            if (classCodeExists)
            {
                // Redirect the user to the classroom page with the code in the query string
                Response.Redirect("Classroom.aspx?code=" + classCode);
            }
            else
            {
                // Display an error message to the user indicating that the class code is invalid
                errorMessage.Text = "Invalid classroom code. Please check and try again.";
            }


        }

        private bool CheckIfClassCodeExists(string classCode, string userId)
        {
     
            string connectionString = WebConfigurationManager.ConnectionStrings["classroomConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Check if the class code exists
                string classQuery = "SELECT ClassId FROM Classes WHERE ClassCode = @ClassCode";
                SqlCommand classCommand = new SqlCommand(classQuery, connection);
                classCommand.Parameters.AddWithValue("@ClassCode", classCode);

                connection.Open();
                object classResult = classCommand.ExecuteScalar();
                connection.Close();

                if (classResult != null)
                {
                    // The class code exists, so you can insert a new record into the ClassStudents table
                    string insertQuery = "INSERT INTO ClassStudents (ClassId, StudentId) VALUES (@ClassId, @StudentId)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@ClassId", classResult); // Use the ClassId retrieved
                    insertCommand.Parameters.AddWithValue("@StudentId", userId);

                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                    connection.Close();

                    // Return true to indicate that the class code exists and the user was added to the class
                    return true;
                }
            }

            // If the class code doesn't exist, return false
            return false;
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
    }
}