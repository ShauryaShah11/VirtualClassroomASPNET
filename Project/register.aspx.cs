using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string firstname = txtFirstName.Text;
            string lastname = txtLastName.Text;
            string email = txtEmail.Text;
            DateTime currentTime = DateTime.Now;

            if (emailExist(email))
            {
                lblErrorMessage.Text = "Email already Exist.";
                lblErrorMessage.Visible = true;

            }
            else
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["classroomConnection"].ConnectionString;
                string query = "INSERT INTO Users (Username,Password,FirstName,LastName,Email,RegistrationDate) VALUES (@Username, @Password,@FirstName,@LastName,@Email,@RegistrationDate)";
                try
                {
                    using (conn)
                    {
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Parameters.AddWithValue("@Username", username);
                            cmd.Parameters.AddWithValue("@Password", password);
                            cmd.Parameters.AddWithValue("@FirstName", firstname);
                            cmd.Parameters.AddWithValue("@LastName", lastname);
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@RegistrationDate", currentTime);

                            cmd.Parameters.AddWithValue("@DOB", "2019-03-28");
                            cmd.Connection = conn;
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();

                            Response.Redirect("login.aspx");

                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Errors : " + ex.Message);
                }
            }
        }
        protected Boolean emailExist(string email)
        {
            // Define your connection string from web.config
            string connectionString = WebConfigurationManager.ConnectionStrings["classroomConnection"].ConnectionString;

            // Create a SQL connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Define your SQL query to retrieve user data based on email and password
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";

                // Create a SQL command
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the query
                    command.Parameters.AddWithValue("@Email", email);

                    // Open the connection
                    connection.Open();

                    // Execute the query
                    int emailCount = (int)command.ExecuteScalar();

                    // Close the connection
                    connection.Close();

                    // Check if a user with the provided credentials exists
                    if (emailCount == 1)
                    {
                        return true; // Authentication successful
                    }
                }
            }

            return false; // Authentication failed
        }
    }
}