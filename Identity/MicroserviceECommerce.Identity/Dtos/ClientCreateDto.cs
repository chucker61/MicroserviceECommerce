namespace MicroserviceECommerce.Identity.Dtos
{
    public record ClientCreateDto
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string DisplayName { get; set; }
    }
}
