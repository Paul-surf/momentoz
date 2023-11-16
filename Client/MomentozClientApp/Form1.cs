using MomentozClientApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MomentozClientApp
{
    public partial class Form1 : Form
    {
        private async Task<List<Customer>?> GetCustomerDataAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://localhost:5114/api/customers";
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Customer>>(content);
                }
                else
                {
                    // Handle error
                    return null;
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void GETbtn_Click(object sender, EventArgs e)
        {
            List<Customer>? customers = await GetCustomerDataAsync();

            if (customers != null)
            {
                // Clear existing items in the ListView
                listView1.Items.Clear();

                // Add each customer to the ListView
                foreach (var customer in customers)
                {
                    ListViewItem item = new ListViewItem(customer.FirstName);
                    item.SubItems.Add(customer.LastName);
                    item.SubItems.Add(customer.MobilePhone);
                    item.SubItems.Add(customer.Email);
                    item.SubItems.Add(customer.FullName);

                    listView1.Items.Add(item);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}