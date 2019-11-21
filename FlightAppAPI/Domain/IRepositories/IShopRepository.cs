using System.Collections.Generic;

namespace FlightAppAPI.Domain.IRepositories
{
    public interface IShopRepository
    {
        void PlaceOrder(int flight, Order order);
        IList<Order> GetOrdersBy(int flight);
        void HandleOrder(int order);
        Product GetProductById(int id);

        IList<Product> GetProducts();
        void SaveChanges();
    }
}
