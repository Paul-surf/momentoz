using MomentozClientApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomentozClientApp.Servicelayer
{
    internal class ServiceConnection : IServiceConnection
    {
        private const string BaseUrl = "https://localhost:5114/api/";
        private const string Endpoint = "customers";
        public async Task<String> establishConnection()
        {
            String content = "";
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://localhost:5114/api/customers";
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                   content = await response.Content.ReadAsStringAsync();
                }
            }
            return content;
        }

        public async Task<List<Customer>?> GetCustomerDataAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://localhost:5114/api/customers";
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                try
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Customer>>(content) ?? new List<Customer>();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Deserialization Error: {ex.Message}");
                    return new List<Customer>();
                }
            }
        }
    }
}
