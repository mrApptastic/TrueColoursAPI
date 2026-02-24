using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace TrueColoursAPI.Helpers
{
    public class PizzaDudeColourHelper
    {
        public static async Task<Object> Hukkerhakker() {
            string pizzaDudeEndPoint = "https://api.color.pizza/v1/"; 
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(pizzaDudeEndPoint);

            Object product = null;

            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadFromJsonAsync<Object>();
            }
            return product;
        }     
    }

    public class PizzaObject {

    }

    public class PizzaItem {
        public string Name { get; set; }
        public string Hex { get; set; }
        public PizzaColour Rgb { get; set; }    
    }

    public class PizzaColour {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
    }

}
