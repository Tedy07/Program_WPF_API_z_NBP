using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Program_WPF_API_z_NBP
{
    
        public class Program
        {
            public static async Task Main()
            {
                var httpClient = new HttpClient()
                {
                    BaseAddress = new Uri("http://api.nbp.pl/api/")
                };
                var response = await httpClient.GetAsync("exchangerates/rates/A/USD");
                var content = await response.Content.ReadAsStringAsync();
                var rate = JsonConvert.DeserializeObject<TableRow>(content);
                Console.Write(rate.Rates[0].Mid);
            }

            public class TableRow
            {
                public List<Rate> Rates { get; set; }
            }

            public class Rate
            {
                public decimal Mid { get; set; }
            }
        }



    
}
