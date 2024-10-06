namespace MicroserviceECommerce.Cargo.Entities.Dtos.CargoOperationDtos
{
    public record CreateCargoOperationDto
    {
        public string Barcode { get; init; }
        public string Description { get; init; }
        public DateTime OperationDate { get; init; }
    }
}
