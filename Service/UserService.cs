using Ecommerce_Models.Model.Entity;
using Ecommerce_Models.Response;
using Ecommerce_Models.Service;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Web_Ecommerce_Cilent.Service
{
    public class UserService(HttpClient httpClient) : IUser
    {
        private const string BaseUrl = "api/User";
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
        public Task<ServiceResponse> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllUser()
        {
            var response = await httpClient.GetAsync($"{BaseUrl}");
            if (!response.IsSuccessStatusCode) return null!;
            var result = await response.Content.ReadAsStringAsync();
            return DeserializeJsonStringList<User>(result).ToList();
        }

        public Task<User> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetUserByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByPhone(string phone)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(int userId, User user)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllAdmin()
        {
            var response = await httpClient.GetAsync($"{BaseUrl}/Admin");
            if (!response.IsSuccessStatusCode) return null!;
            var result = await response.Content.ReadAsStringAsync();
            return DeserializeJsonStringList<User>(result).ToList();
        }
    }
}
