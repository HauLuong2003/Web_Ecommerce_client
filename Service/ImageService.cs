using System.Text.Json.Serialization;
using System.Text.Json;

using Ecommerce_Models.Response;
using System.Net.Http;
using Ecommerce_Models.Model.Entity;
using Ecommerce_Models.Service;

namespace Web_Ecommerce_Cilent.Service
{
    public class ImageService(HttpClient httpClient) : IImage
    {
        private const string BaseUrl = "api/Image";
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
        public async Task<string> AddImage(MultipartFormDataContent Addimage)
        {
            // Send the request to the API
            var response = await httpClient.PostAsync(BaseUrl, Addimage);

            // Check if the response was successful
            response.EnsureSuccessStatusCode();

            // Read the JSON response as a string
            var apiResponse = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON response to an object with the image path
            var imagePath=  DeserializeJsonString<ImageResponse>(apiResponse);
            return imagePath?.ImagePath ?? string.Empty;


        }
    }

}
