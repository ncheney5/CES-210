using System;
using System.Net.Http;
using System.Threading.Tasks;

public class WebsiteAccess
{
    public static async Task Main(string[] args)
    {
        string url = "https://archive.org/stream/j-r-r-tolkien-lord-of-the-rings-01-the-fellowship-of-the-ring-retail-pdf/j-r-r-tolkien-lord-of-the-rings-01-the-fellowship-of-the-ring-retail-pdf_djvu.txt"; 
        // // Replace with the target URL

        try
        {
            // Create a new HttpClient
            using (var client = new HttpClient())
            {
                // Make the HTTP GET request
                HttpResponseMessage response = await client.GetAsync(url);

                // Ensure the request was successful (status code 200-299)
                response.EnsureSuccessStatusCode();

                // Read the response content (as a string)
                string responseBody = await response.Content.ReadAsStringAsync();

                // Print the response body to the console
                Console.WriteLine(responseBody);

                // You can also parse the response body as HTML or other formats
                // depending on the website's content type
            }
        }
        catch (Exception e)
        {
            // Handle any errors (e.g., network issues, invalid URL)
            Console.WriteLine($"Error accessing website: {e.Message}");
        }
    }
}