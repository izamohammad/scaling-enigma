using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ExpressVPN2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void BindLocationList()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("https://xvjune2014trial.apiary.io/")
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

            HttpResponseMessage response = client.GetAsync("locations").Result;
            if (response.IsSuccessStatusCode)
            {
                var location1 = response.Content.ReadAsAsync<IEnumerable<LocationList>>().Result;
                grdLocation.ItemsSource = location1;
            }
            else
            {
                MessageBox.Show("Error: " + response.StatusCode);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BindLocationList();
        }
    }
}

                



