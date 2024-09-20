namespace MicroserviceECommerce.Catalog.Dtos.CategoryDtos
{
    public record UpdateCategoryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
