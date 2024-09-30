namespace MicroserviceECommerce.Catalog.Entities.Exceptions
{
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(string message) : base(message)
        {
        }
    }
}
