namespace MicroserviceECommerce.Cargo.Entities.Dtos.CargoCompanyDtos
{
    public record UpdateCargoCompanyDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
    }
}
