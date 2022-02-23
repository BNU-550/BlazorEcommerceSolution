namespace BlazorEcommerceProject.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public List<Product> Products { get; set; } = new List<Product>();

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public async Task GetProducts()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/products");
            Products = result.Data;
        }

        public async Task<ServiceResponse<Product>> GetProductById(int productId)
        {
			var result = 
                await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/products/{productId}");
            
            return result;
        }
    }
}
