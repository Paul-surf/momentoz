using MomentozClientApp.Controller;
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
        readonly CustomerController _customerController;
        public Form1()
        {
            InitializeComponent();
            _customerController = new CustomerController();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load_2(object sender, EventArgs e)
        {

        }

        private async void GETbtn_Click_1(object sender, EventArgs e)
        {
            string processText = "OK"; 
            List<Customer>? fetchedCustomers = await _customerController.GetAllCustomers();

            if (fetchedCustomers != null) { 
                if (fetchedCustomers.Count >= 1) { 
                    processText = "Ok"; 
                } else { 
                    processText = "No persons found"; 
                } 
            } else { 
                processText = "Failure: An error occurred"; 
            }
            label2.Text = processText;
            ListBoxCustomers.DataSource = fetchedCustomers;
        }
    }
}