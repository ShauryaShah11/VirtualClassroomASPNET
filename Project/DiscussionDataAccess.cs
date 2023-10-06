using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Project
{
    public class DiscussionDataAccess
    {
        private string connectionString;

        public DiscussionDataAccess()
        {
            // Get the connection string from web.config
            connectionString = WebConfigurationManager.ConnectionStrings["classroomConnection"].ConnectionString;
        }

        public List<Discussion> GetDiscussionsByClassroomCode(string classroomCode)
        {
            List<Discussion> discussions = new List<Discussion>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT D.DiscussionId, D.ClassId, D.Title, D.Description, D.AuthorId, D.DiscussionDate, U.UserName
                    FROM Discussions D
                    INNER JOIN Users U ON D.AuthorId = U.UserId
                    WHERE D.ClassId = (SELECT ClassId FROM Classes WHERE ClassCode = @ClassCode)
                    ORDER BY D.DiscussionDate DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClassCode", classroomCode);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Discussion discussion = new Discussion
                            {
                                DiscussionId = (int)reader["DiscussionId"],
                                ClassId = (int)reader["ClassId"],
                                Title = reader["Title"].ToString(),
                                Description = reader["Description"].ToString(),
                                AuthorId = (int)reader["AuthorId"],
                                DiscussionDate = (DateTime)reader["DiscussionDate"],
                                Username = reader["Username"].ToString() // Add AuthorName property
                            };

                            discussions.Add(discussion);
                        }
                    }
                }
            }

            return discussions;
        }

    }
}
