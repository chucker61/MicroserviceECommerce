﻿namespace MicroserviceECommerce.Catalog.Dtos.ProductImageDtos
{
    public record CreateProductImageDto
    {
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }
        public string ProductId { get; set; }
    }
}