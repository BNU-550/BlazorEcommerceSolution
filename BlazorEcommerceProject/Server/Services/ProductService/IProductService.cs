 namespace BlazorEcommerceProject.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProducts();
        Task<ServiceResponse<Product>> GetProduct(int Id);
        Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl);
    }
}
