namespace MicroserviceECommerce.Catalog.Dtos.ProductDetailDtos
{
    public record CreateProductDetailDto
    {
        public string Description { get; set; }
        public string Info { get; set; }
        public string ProductId { get; set; }
    }
}
