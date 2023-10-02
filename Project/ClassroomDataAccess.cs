using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Project
{
    public class ClassroomDataAccess
    {
        private string connectionString;

        public ClassroomDataAccess()
        {
            // Get the connection string from web.config
            connectionString = WebConfigurationManager.ConnectionStrings["classroomConnection"].ConnectionString;
        }

        public List<Classroom> GetUserClassrooms(string UserId)
        {
            List<Classroom> classrooms = new List<Classroom>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Classes WHERE UserId = @UserId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", UserId);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Classroom classroom = new Classroom
                            {
                                // Map database columns to Classroom properties
                                ClassName = reader["ClassName"].ToString(),
                                ClassDescription = reader["ClassDescription"].ToString(),
                                ClassCode = reader["ClassCode"].ToString(),
                                CreationDate = (DateTime)reader["CreationDate"],
                                // Add more properties as needed
                            };

                            classrooms.Add(classroom);
                        }
                    }
                }
            }

            return classrooms;
        }
    }
}