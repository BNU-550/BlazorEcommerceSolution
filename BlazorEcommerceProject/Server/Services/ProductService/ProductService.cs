namespace BlazorEcommerceProject.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        
        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Product>>> GetProducts()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _context.Products.ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<Product>> GetProduct(int Id)
        {
            var response = new ServiceResponse<Product>();
            //var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == Id);
            var product = await _context.Products.FindAsync(Id);

            if(product == null)
            {
                response.IsSuccess = false;
                response.Message = $"No product found with id = {Id}";
            }
            else
            {
                response.IsSuccess = true;
                response.Data = product;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryURL)
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                    .Where(p => p.Category.URL.ToLower().Equals(categoryURL.ToLower()))
                    .ToListAsync()
            };

            return response;
        }
    }
}
