using ApiClientLib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            Console.WriteLine("API Response For Details: " + result);

            string jsonResponse = apiClient.GetEmployeeDetailsAsync(); //Employee List
            string formattedJson = JValue.Parse(jsonResponse).ToString();
            Console.WriteLine("API Response For Employee List: "+ '\n' + formattedJson);
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
