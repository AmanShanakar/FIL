using System;

namespace ApiClientLib
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(string baseAddress)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseAddress);
        }
        public string GetDetailsAsync()
        {
            string apiResponse = string.Empty;
            using (var response = _httpClient.GetAsync("api/Employee/Details").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    apiResponse = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    apiResponse = response.StatusCode.ToString();
                }
            }
            return apiResponse;
        }
    }
}