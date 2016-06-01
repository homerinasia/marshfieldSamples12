using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using System.Net.Http.Headers;

namespace wapi2wpf
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            btn0.Content = DateTime.Now.ToLongTimeString();
            dg0.ItemsSource= getData();
        }

        List<Person> getData()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49922");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/FindByLetter/e").Result;
                return  response.Content.ReadAsAsync<List<Person>>().Result;
            }
        }
    }

    class Person
    {
        public int Id { get; set; }
        public string Fname { get; set; }
    }
}
