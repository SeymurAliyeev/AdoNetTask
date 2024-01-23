using System;
using System.Data.SqlClient;
using System.Text.Json;

public static class Data
{
    static async Task Main()
    {
        string Url = "https://jsonplaceholder.typicode.com/posts";

        using (HttpClient httpClient = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(Url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        using (HttpClient client = new HttpClient())
        {
            string response = await client.GetStringAsync(Url);
            List<Post>? posts = JsonSerializer.Deserialize<List<Post>>(response);
            foreach (var post in posts)
            {
                Console.WriteLine($"UserId:  {post.userId};  Id:  {post.id};  Title:  {post.title}");
            }
        }
    }
}





