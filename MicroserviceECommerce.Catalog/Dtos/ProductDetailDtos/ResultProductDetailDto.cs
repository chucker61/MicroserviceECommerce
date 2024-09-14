namespace MicroserviceECommerce.Catalog.Dtos.ProductDetailDtos
{
    public record ResultProductDetailDto
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }
        public string ProductId { get; set; }
    }
}
