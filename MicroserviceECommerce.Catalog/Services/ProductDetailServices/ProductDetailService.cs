using AutoMapper;
using MicroserviceECommerce.Catalog.Dtos.ProductDetailDtos;
using MicroserviceECommerce.Catalog.Entities;
using MicroserviceECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace MicroserviceECommerce.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;
        public ProductDetailService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var productDetail = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _productDetailCollection.InsertOneAsync(productDetail);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetailCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync()
        {
            var productDetails = await _productDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(productDetails);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var productDetail = await _productDetailCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(productDetail);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var productDetail = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productDetailCollection.FindOneAndReplaceAsync(x => x.Id == updateProductDetailDto.Id, productDetail);
        }
    }
}
