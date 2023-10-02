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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Session["Email"] as string;
            if (string.IsNullOrEmpty(email))
            {
                Response.Redirect("login.aspx");
            }
        }
        protected void btnCreateClassroom_Click(object sender, EventArgs e)
        {
            string className = txtClassName.Text;
            string classDescription = txtClassDescription.Text;

            // Retrieve the email from the session.
            string email = Session["Email"] as string;

            // Retrieve the corresponding UserId from the database based on the email.
            string userId = GetUserIdByEmail(email);

            // Generate a unique class code
            string uniqueCode = GenerateUniqueClassCode();

            DateTime currentTime = DateTime.Now;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["classroomConnection"].ConnectionString;

            // Use parameterized query to prevent SQL injection
            string query = "INSERT INTO Classes (ClassName, ClassDescription, UserId, ClassCode, CreationDate) " +
                           "VALUES (@ClassName, @ClassDescription, @UserId, @ClassCode, @CreationDate)";

            try
            {
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@ClassName", className);
                        cmd.Parameters.AddWithValue("@ClassDescription", classDescription);
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@ClassCode", uniqueCode);
                        cmd.Parameters.AddWithValue("@CreationDate", currentTime);

                        cmd.Connection = conn;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        Response.Redirect("ClassroomList.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Errors : " + ex.Message);
            }
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

        private string GenerateUniqueClassCode()
        {
            // Generate a random 6-digit class code
            Random random = new Random();
            string uniqueCode = random.Next(100000, 999999).ToString();
            string connectionString = WebConfigurationManager.ConnectionStrings["classroomConnection"].ConnectionString;

            // Create a SQL connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Classes WHERE ClassCode = @ClassCode";

                // Create a SQL command
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the query
                    command.Parameters.AddWithValue("@ClassCode", uniqueCode);

                    // Open the connection
                    connection.Open();

                    // Execute the query
                    int codeExist = (int)command.ExecuteScalar();

                    // Close the connection
                    connection.Close();

                    if (codeExist == 1)
                    {
                        return GenerateUniqueClassCode(); 
                    }
                }
            }


            return uniqueCode;
        }

    }
}