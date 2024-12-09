using Newtonsoft.Json;
using OrderManagementApp.Models;
using System.Net;
using System.Text;

namespace OrderManagementApp.Managers
{
    public class OrderManagementApiClient
    {
        public IEnumerable<OrderModel> GetAllOrders()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                    //client.BaseAddress = new Uri("https://localhost:7127");
                    client.BaseAddress = new Uri("https://localhost:7205");
                    HttpResponseMessage response = client.GetAsync("/api/OrderManagement/order").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        List<OrderModel> orders = JsonConvert.DeserializeObject<List<OrderModel>>(responseBody);
                        return orders;
                    }
                    else
                    {
                        var statusCode = response.StatusCode;
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        throw new Exception($"HTTP request zlyhal: {statusCode}");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public OrderModel GetOrderById(int id)
        {
            try
            {
                //int id = 1;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7205");
                    HttpResponseMessage response = client.GetAsync($"/api/OrderManagement/order/{id}").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        OrderModel order = JsonConvert.DeserializeObject<OrderModel>(responseBody);
                        return order;
                    }
                    else
                    {
                        var statusCode = response.StatusCode;
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        throw new Exception($"HTTP request zlyhal: {statusCode}");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public OrderModel PostNewOrder(OrderModel orderModel)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(orderModel);
                StringContent content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7205");
                    HttpResponseMessage response = client.PostAsync("/api/OrderManagement/order", content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        OrderModel order = JsonConvert.DeserializeObject<OrderModel>(responseBody);
                        return order;
                    }
                    else
                    {
                        var statusCode = response.StatusCode;
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        throw new Exception($"HTTP request zlyhal: {statusCode}");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateOrder(int id, OrderModel orderModel)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7205");

                    var jsonContent = new StringContent(JsonConvert.SerializeObject(orderModel), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.PutAsync($"/api/OrderManagement/order/{id}", jsonContent).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        //string responseBody = response.Content.ReadAsStringAsync().Result;
                        //BookingModel booking = JsonConvert.DeserializeObject<BookingModel>(responseBody);
                        return true;
                    }
                    else
                    {
                        var statusCode = response.StatusCode;
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        throw new Exception($"HTTP request zlyhal: {statusCode}");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteOrderById(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7205");
                    HttpResponseMessage response = client.DeleteAsync($"/api/OrderManagement/order/{id}").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        //string responseBody = response.Content.ReadAsStringAsync().Result;
                        //BookingModel booking = JsonConvert.DeserializeObject<BookingModel>(responseBody);
                        return true;
                    }
                    else
                    {
                        var statusCode = response.StatusCode;
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        throw new Exception($"HTTP request zlyhal: {statusCode}");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
