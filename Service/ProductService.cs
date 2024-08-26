using Ecommerce_Models.Model.Entity;
using Ecommerce_Models.Model.Request;
using Ecommerce_Models.Response;
using Ecommerce_Models.Service;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
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
        public async Task<ServiceResponse> AddProduct(AddProductDTO addProduct)
        {
            var response = await httpClient.PostAsync(BaseUrl,GenerateStringContent(SerializeObj(addProduct)));
           
            //read response
            if (!response.IsSuccessStatusCode )
            {
                return new ServiceResponse(false, "Error ");
            }
            var apiResponse =await response.Content.ReadAsStringAsync();
            return DeserializeJsonString<ServiceResponse>(apiResponse);
        }
        public async Task<List<Product>> GetProductfeatured(bool featuredProducts)
        {
            var response = await httpClient.GetAsync($"{BaseUrl}/featured?featured={featuredProducts}");
            //if (!response.IsSuccessStatusCode) return null!;
            var result = await response.Content.ReadAsStringAsync();
            return  DeserializeJsonStringList<Product>(result).ToList();

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

        public async Task<List<Product>> GetProductByBrand(int brandId)
        {
            var response = await httpClient.GetAsync($"{BaseUrl}/search-brand?brandId={brandId}");
            var result = await response.Content.ReadAsStringAsync();
            return DeserializeJsonStringList<Product>(result).ToList();
        }

        public async Task<Product> GetProductById(int productId)
        {
            var response = await httpClient.GetAsync($"{BaseUrl}/{productId}");
            var result = await response.Content.ReadAsStringAsync();
            return DeserializeJsonString<Product>(result); 
        }

        public async Task<List<Product>> GetProductByName(string name)
        {
            var response = await httpClient.GetAsync($"{BaseUrl}/search-name?name={name}");
            var result = await response.Content.ReadAsStringAsync();
            return DeserializeJsonStringList<Product>(result).ToList();
        }

        public async Task<List<Product>> GetProductByPrice(float price)
        {
            var response = await httpClient.GetAsync($"{BaseUrl}/search-price?price={price}");
            var result = await response.Content.ReadAsStringAsync();
            return DeserializeJsonStringList<Product>(result).ToList();
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
