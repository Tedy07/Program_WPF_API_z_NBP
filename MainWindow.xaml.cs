using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace Program_WPF_API_z_NBP
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void button_Click(object sender, RoutedEventArgs e)
        {
            static async Task Main()
            {
                var httpClient = new HttpClient()
                {
                    BaseAddress = new Uri("http://api.nbp.pl/api/")
                };
                var response = await httpClient.GetAsync("exchangerates/rates/A/USD");
                var content = await response.Content.ReadAsStringAsync();
                var rate = JsonConvert.DeserializeObject<TableRow>(content);
                Label.Content (rate.Rates[0].Mid);
            }
        }

         class TableRow
        {
            public List<Rate> Rates { get; set; }
        }

        public class Rate
        {
            public decimal Mid { get; set; }
        }


    }
    }

