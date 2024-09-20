namespace MicroserviceECommerce.Catalog.Dtos.CategoryDtos
{
    public record GetByIdCategoryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
