using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using CredaData.Client;



namespace ImageSyncApplication
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;
        public Form1(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("CredaApiClient");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Example: Get data from the "Project" API endpoint
                //var projects = await _httpClient.GetFromJsonAsync<ProjectModel[]>("project-endpoint");

                // Display or process the data as needed
                //foreach (var project in projects)
                //{
                //    MessageBox.Show(project.ProjectName);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
