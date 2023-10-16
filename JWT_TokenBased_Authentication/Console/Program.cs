using ApiClientLib;
using System;

class Program
{
    static async Task Main(string[] args)
    {
        string baseAddress = "http://localhost:5228/"; // My API URL

        var apiClient = new ApiClient(baseAddress);

        try
        {
            var result = apiClient.GetDetailsAsync(); //Details();
            Console.WriteLine("API Response: " + result);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("API Request Failed: " + ex.Message);
            if (ex.InnerException != null)
            {
                Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
            }
        }
    }
}
