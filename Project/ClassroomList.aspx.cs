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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Session["email"] as string;
            if (string.IsNullOrEmpty(email))
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                ClassroomDataAccess dataAccess = new ClassroomDataAccess();
                string userId = GetUserIdByEmail(email);

                List<Classroom> classrooms = dataAccess.GetUserClassrooms(userId);

                // Now you have the list of classrooms for the user to display on your page.
                rptClassrooms.DataSource = classrooms;
                rptClassrooms.DataBind();
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
    }
}