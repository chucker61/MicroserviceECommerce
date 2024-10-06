using MicroserviceECommerce.Cargo.Entities.Models;

namespace MicroserviceECommerce.Cargo.Entities.Dtos.CargoDetailDtos
{
    public record ResultCargoDetailDto
    {
        public int Id { get; init; }
        public string SenderCustomer { get; init; }
        public string ReceiverCustomer { get; init; }
        public int Barcode { get; init; }
        public int CargoCompanyId { get; init; }
        public CargoCompany CargoCompany { get; init; }
    }
}
