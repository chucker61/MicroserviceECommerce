namespace MicroserviceECommerce.Catalog.Dtos.ProductDtos
{
    public record CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryId { get; set; }
    }
}
