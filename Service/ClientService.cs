using Ecommerce_Models.Model.Entity;
using Ecommerce_Models.Response;
using Ecommerce_Models.Service;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Web_Ecommerce_Cilent.Service
{
    public class ClientService : IProduct
    {
        private const string BaseUrl = "api/product";
        private static JsonSerializerOptions JsonOptions()
        {
            return new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy   = JsonNamingPolicy.CamelCase,
                UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip
            };
        }

        public Task<ServiceResponse> AddProduct(Product model)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllProduct()
        {
            throw new NotImplementedException();
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

        public Task<List<Product>> GetProductfeatured(bool featuredProducts)
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
