namespace MicroserviceECommerce.Cargo.Entities.Dtos.CargoDetailDtos
{
    public record CreateCargoDetailDto
    {
        public string SenderCustomer { get; init; }
        public string ReceiverCustomer { get; init; }
        public int Barcode { get; init; }
        public int CargoCompanyId { get; init; }
    }
}
