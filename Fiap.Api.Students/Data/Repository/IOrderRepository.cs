using Fiap.Api.Students.Models;

namespace Fiap.Api.Students.Data.Repository;

public interface IOrderRepository
{
    IEnumerable<OrderModel> GetAll();
    IEnumerable<OrderModel> GetAllWithDetails();
    OrderModel GetById(int id);
    OrderModel GetByIdWithDetails(int id);
    void Add(OrderModel pedido);
    void Update(OrderModel pedido);
    void Delete(OrderModel pedido);
}