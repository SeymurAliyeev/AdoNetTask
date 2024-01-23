using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

public class Post
{
    public int userId { get; set; }
    public int id { get; set; }
    public string title { get; set; }
    public string body { get; set; }

    static void InsertDataIntoMySQL(string connString, List<Post> people)
    {
        using (SqlConnection conn = new SqlConnection(connString))
        {
            conn.Open();

            foreach (var post in posts)
            {
                using (SqlCommand insertCmd = new SqlCommand("INSERT INTO Posts (userId, id, title) VALUES (@userId, @id, @title)", conn))
                {
                    insertCmd.Parameters.AddWithValue("@userId", post.userId);
                    insertCmd.Parameters.AddWithValue("@id", post.id);
                    insertCmd.Parameters.AddWithValue("@title", post.title);
                    insertCmd.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Data inserted successfully into the MySQL table.");
        }
    }

    void Create(int userId, int id, string title)
    {
        string connString = @"Server=2GR9KAF\SQLEXPRESS;Database=Post;Trusted_Connection=true;\Posts";
        string query = "insert into Posts values (userId,id,'title')";

        using (SqlConnection conn = new SqlConnection(connString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                int affectedRow = cmd.ExecuteNonQuery();
                if (affectedRow > 0)
                {
                    Console.WriteLine("Successfully added");
                }
            }
        }
    }
}
