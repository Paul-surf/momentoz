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
            CustomerController CustomerCtrl = new CustomerController();
            List<Customer>? customers = await CustomerCtrl.getCustomers();

            if (customers != null)
            {
                dataGridView1.DataSource = customers;
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

        private async void button1_Click(object sender, EventArgs e)
        {
            CustomerController CustomerCtrl = new CustomerController();
            String content = await CustomerCtrl.grabJsonInfo();
            updatePanel(content);
        }

        private void updatePanel(string content)
        {
            panel1.Controls.Clear();
            Label label = new Label
            {
                Text = content,
                AutoSize = true,
                Dock = DockStyle.Fill
            };
            panel1.Controls.Add(label);
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}