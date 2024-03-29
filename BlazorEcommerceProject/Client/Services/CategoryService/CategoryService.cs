﻿namespace BlazorEcommerceProject.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient http;

        public List<Category> Categories { get; set; } = new List<Category>();

        public CategoryService(HttpClient http)
        {
            this.http = http;
        }
        public async Task GetCategories()
        {
            var response = await http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category");
            if(response != null && response.Data != null)
                Categories = response.Data;
        }
    }
}
