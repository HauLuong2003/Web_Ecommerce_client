using Ecommerce_Models.Model.Entity;
using Ecommerce_Models.Response;
using Ecommerce_Models.Service;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

namespace Web_Ecommerce_Cilent.Service
{
    public class ProductService(HttpClient httpClient): IProduct
    {
        
        private const string BaseUrl = "api/Product";
        private static string SerializeObj(object modelObj) => JsonSerializer.Serialize(modelObj,JsonOptions());
        private static T DeserializeJsonString<T>(string jsonString) => JsonSerializer.Deserialize<T>(jsonString, JsonOptions())!;
        private static StringContent GenerateStringContent(string serializedObj) => new(serializedObj, System.Text.Encoding.UTF8, "application/json");
        private static IList<T> DeserializeJsonStringList<T>(string jsonString) =>JsonSerializer.Deserialize<IList<T>>(jsonString, JsonOptions())!;
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

        public async Task<ServiceResponse> AddProduct(Product model)
        {
            var response = await httpClient.PostAsync(BaseUrl,GenerateStringContent(SerializeObj(model)));
            //read response
            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse(false, "Error occured . Try later.");
            }
            var apiResponse =await response.Content.ReadAsStringAsync();
            return DeserializeJsonString<ServiceResponse>(apiResponse);

        }
        public async Task<List<Product>> GetProductfeatured(bool featuredProducts)
        {
            var response = await httpClient.GetAsync($"{BaseUrl}/featured?featured={featuredProducts}");
            if (response.IsSuccessStatusCode) return null!;
            var result = await response.Content.ReadAsStringAsync();
            return [.. DeserializeJsonStringList<Product>(result)];

        }
        public Task<ServiceResponse> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllProduct()
        {
            var response = await httpClient.GetAsync($"{BaseUrl}/getAll");
            if (!response.IsSuccessStatusCode) return null!;
            var result = await response.Content.ReadAsStringAsync();
            return DeserializeJsonStringList<Product>(result).ToList();

        }

        public Task<List<Price>> GetPrice()
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProductByBrand(int brandId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProductByPrice(float price)
        {
            throw new NotImplementedException();
        }

      

        public Task<Price> GetProductPrice(int ProductId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProduct(int id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
