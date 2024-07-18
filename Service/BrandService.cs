using Ecommerce_Models.Model.Entity;
using Ecommerce_Models.Response;
using Ecommerce_Models.Service;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Web_Ecommerce_Cilent.Service
{
    public class BrandService(HttpClient httpClient) : IBrand
    {
        private const string BaseUrl = "api/Brand";
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
        public Task<ServiceResponse> AddBrand(Brand brand)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBrand(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Brand>> GetAllBrands()
        {
            var response = await httpClient.GetAsync($"{BaseUrl}");
            //if (response.IsSuccessStatusCode) return null!;
            var result = await response.Content.ReadAsStringAsync();
            return DeserializeJsonStringList<Brand>(result).ToList();
        }

        public Task<Brand> GetBrandById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Brand> UpdateBrand(int id, Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
