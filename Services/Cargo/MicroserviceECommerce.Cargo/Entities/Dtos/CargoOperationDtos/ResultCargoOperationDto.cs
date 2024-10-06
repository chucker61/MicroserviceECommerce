namespace MicroserviceECommerce.Cargo.Entities.Dtos.CargoOperationDtos
{
    public record ResultCargoOperationDto
    {
        public int Id { get; init; }
        public string Barcode { get; init; }
        public string Description { get; init; }
        public DateTime OperationDate { get; init; }
    }
}
