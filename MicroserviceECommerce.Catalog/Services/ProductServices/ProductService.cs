using AutoMapper;
using MicroserviceECommerce.Catalog.Dtos.ProductDtos;
using MicroserviceECommerce.Catalog.Entities;
using MicroserviceECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace MicroserviceECommerce.Catalog.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(product);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            var products = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(products);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var product = await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(product);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var product = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.Id == updateProductDto.Id, product);
        }
    }
}
