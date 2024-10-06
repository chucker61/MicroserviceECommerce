namespace MicroserviceECommerce.Cargo.Entities.Dtos.CargoCustomerDtos
{
    public record ResultCargoCustomerDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
        public string Email { get; init; }
        public string Phone { get; init; }
        public string District { get; init; }
        public string City { get; init; }
        public string Address { get; init; }
        public string? UserCustomerId { get; init; }
    }
}
