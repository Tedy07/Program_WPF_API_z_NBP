using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;

namespace Program_WPF_API_z_NBP;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void button_Click(object sender, RoutedEventArgs e)
    {
        using var httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://api.nbp.pl/api/")
        };
        using var response = await httpClient.GetAsync("exchangerates/rates/A/USD");
        var content = await response.Content.ReadAsStringAsync();
        var rate = JsonConvert.DeserializeObject<TableRow>(content);
        label.Content = rate.Rates[0].Mid;
        textBlock.Text = rate.Rates[0].Mid.ToString();
    }

    private class TableRow
    {
        public List<Rate> Rates { get; set; }
    }

    private class Rate
    {
        public decimal Mid { get; set; }
    }

    private void button1_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}

// ver. 1.0 działający program z poprawkami Karola
// ver.1.1 dodano button close