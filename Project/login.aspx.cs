using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Get the username and password entered by the user.
            string email = txtLoginEmail.Text;
            string password = txtLoginPassword.Text;

            if (AuthenticateUser(email, password))
            {
                // Redirect to the desired page after successful login.
                Session["email"] = email;
                Response.Redirect("ClassroomList.aspx");
            }
            else
            {
                // Authentication failed. Show an error message.
                lblErrorMessage.Text = "Invalid username or password.";
                lblErrorMessage.Visible = true;
            }
        }

        public static bool AuthenticateUser(string email, string password)
        {
            // Define your connection string from web.config
            string connectionString = WebConfigurationManager.ConnectionStrings["classroomConnection"].ConnectionString;

            // Create a SQL connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Define your SQL query to retrieve user data based on email and password
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND Password = @Password";

                // Create a SQL command
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the query
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    // Open the connection
                    connection.Open();

                    // Execute the query
                    int userCount = (int)command.ExecuteScalar();

                    // Close the connection
                    connection.Close();

                    // Check if a user with the provided credentials exists
                    if (userCount == 1)
                    {
                        return true; // Authentication successful
                    }
                }
            }

            return false; // Authentication failed
        }
    }
}
