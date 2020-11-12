using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;

namespace ClassLibraryWebClient
{
    public class ShoppingManager
    {
        public static List<ShoppingItem> _shopitems;
        public static ShoppingItem _shopitem;
        public static string shopCreateMessage;
        public static string shopUpdateMessage;
        public static string shopDeleteMessage;


        private static async Task<List<ShoppingItem>> GetShoppingItems()
        {
            var client = new HttpClient();
            
           // client.BaseAddress = new Uri("http://localhost:63754/");
            client.BaseAddress = new Uri("https://webapi-serhii.azurewebsites.net/");
            client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

            var url = "/api/shoppingcart";
            
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();

            _shopitems = JsonConvert.DeserializeObject<List<ShoppingItem>>(resp);//output for this method

            return _shopitems;
        }

        public void GetShopApply()
        {
            _shopitems = new List<ShoppingItem>();
           

            var t = Task.Run(() => GetShoppingItems());
            t.Wait();

          
        }
        private static async Task<ShoppingItem> GetShoppingItem(Guid id)
        {
            var client = new HttpClient();


            // client.BaseAddress = new Uri("http://localhost:63754/");
            client.BaseAddress = new Uri("https://webapi-serhii.azurewebsites.net/");
            client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

            ShoppingItem shopitem = null;
            var url = "/api/shoppingcart/";
            HttpResponseMessage response = await client.GetAsync(url + id);
            if (response.IsSuccessStatusCode)
            {
                shopitem = await response.Content.ReadAsAsync<ShoppingItem>();
            }
            _shopitem = shopitem;
            return shopitem;


        }

        public ShoppingItem GetShoppingApply(Guid id)
        {
            _shopitems = new List<ShoppingItem>();


            var t = Task.Run(() => GetShoppingItem(id));
            t.Wait();

            return _shopitem;
        }

        static async Task<Uri> CreateShoppingAsync(ShoppingItem shopitem)//(Product product)
        {
            var client = new HttpClient();


            // client.BaseAddress = new Uri("http://localhost:63754/");
            client.BaseAddress = new Uri("https://webapi-serhii.azurewebsites.net/");
            client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

            
            HttpResponseMessage response = await client.PostAsJsonAsync("api/shoppingcart/", shopitem);
            try
            {


                response.EnsureSuccessStatusCode();




                shopCreateMessage = "Shopping Item created succesfully!";
                // return URI of the created resource.
                return response.Headers.Location;
            }
            catch (Exception e)
            {
                shopCreateMessage = $"Shopping Item creation not succesful. Error message: {e.ToString()}";
                return response.Headers.Location;

            }

        }

        public string CreateShoppingApply(ShoppingItem shopitem)
        {
            var url = Task.Run(() => CreateShoppingAsync(shopitem));
            url.Wait();

            return shopCreateMessage;
        }

        static async Task<ShoppingItem> UpdateShoppingAsync(ShoppingItem shopitem)
        {
            var client = new HttpClient();


           //  client.BaseAddress = new Uri("http://localhost:63754/");
            client.BaseAddress = new Uri("https://webapi-serhii.azurewebsites.net/");
            client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {

                HttpResponseMessage response = await client.PutAsJsonAsync(
                    $"api/shoppingcart/", shopitem);
                response.EnsureSuccessStatusCode();

                shopUpdateMessage = "ShoppingItem updated succesfully!";


            }
            catch (Exception e)
            {
                shopUpdateMessage = $"ShoppingItem updating not succesful. Error message: {e.ToString()}";

            }

            return shopitem;
        }

        public string UpdateShoppingApply(ShoppingItem shopitem)
        {
            var upd = Task.Run(() => UpdateShoppingAsync(shopitem));
            upd.Wait();

            return shopUpdateMessage;
        }

        static async Task<HttpStatusCode> DeleteShoppingAsync(Guid id)
        {
            var client = new HttpClient();


            // client.BaseAddress = new Uri("http://localhost:63754/");
            client.BaseAddress = new Uri("https://webapi-serhii.azurewebsites.net/");
            client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            
            HttpResponseMessage response = await client.DeleteAsync($"api/shoppingcart/{id}");

            try
            {
                shopDeleteMessage = "ShoppingItem deleting succesfully!";
                return response.StatusCode;
            }
            catch (Exception e)
            {
                shopDeleteMessage = $"ShoppingItem deleting not succesful. Error message: {e.ToString()}";
                return response.StatusCode;
            }
        }

        public string DeleteShoppingApply(Guid id)
        {
            var del = Task.Run(() => DeleteShoppingAsync(id));
            del.Wait();

            return shopDeleteMessage;
        }
    }
}
