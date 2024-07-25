using System.Text.Json.Serialization;
using System.Text.Json;
using Ecommerce_Models.Service;
using Ecommerce_Models.Model.Entity;
using Ecommerce_Models.Response;
using System.Net.Http;

namespace Web_Ecommerce_Cilent.Service
{

    public class OrderService(HttpClient httpClient) : IOrderManage
    {
        private const string BaseUrl = "api/Order";
        private static string SerializeObj(object modelObj) => JsonSerializer.Serialize(modelObj, JsonOptions());
        private static T DeserializeJsonString<T>(string jsonString) => JsonSerializer.Deserialize<T>(jsonString, JsonOptions())!;
        private static StringContent GenerateStringContent(string serializedObj) => new(serializedObj, System.Text.Encoding.UTF8, "application/json");
        private static IList<T> DeserializeJsonStringList<T>(string jsonString) => JsonSerializer.Deserialize<IList<T>>(jsonString, JsonOptions())!;
        private static JsonSerializerOptions JsonOptions()
        {
            return new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip
            };
        }

        public async Task<List<Oder>> GetOrder()
        {
            var response = await httpClient.GetAsync($"{BaseUrl}");
            if (!response.IsSuccessStatusCode) return null!;
            var result = await response.Content.ReadAsStringAsync();
            return DeserializeJsonStringList<Oder>(result).ToList();
        }

        public async Task<List<Oder>> GetOderStatus(int status)
        {
            var response = await httpClient.GetAsync($"{BaseUrl}/status?status={status}");
            if (!response.IsSuccessStatusCode) return null!;
            var result = await response.Content.ReadAsStringAsync();
            return DeserializeJsonStringList<Oder>(result).ToList();
        }

        public Task<ServiceResponse> UpdateOrderStatus(int orderId, int status)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<Oder> AddOrder(Oder order)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderStatus>> OrderStatus()
        {
            var response = await httpClient.GetAsync($"{BaseUrl}/getStatus");
            //if (!response.IsSuccessStatusCode) return null!;
            var result = await response.Content.ReadAsStringAsync();
            return DeserializeJsonStringList<OrderStatus>(result).ToList();
        }
    }
}
