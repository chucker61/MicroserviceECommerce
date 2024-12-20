﻿namespace MicroserviceECommerce.Catalog.Dtos.ProductImageDtos
{
    public record GetByIdProductImageDto
    {
        public string Id { get; set; }
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }
        public string ProductId { get; set; }
    }
}
