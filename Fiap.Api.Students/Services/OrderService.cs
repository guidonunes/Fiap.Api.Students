using Fiap.Api.Students.Data.Repository;
using Fiap.Api.Students.Models;

namespace Fiap.Api.Students.Services;

public class OrderService: IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    // Método para obter todos os pedidos
    public IEnumerable<OrderModel> GetAllOrders()
    {
        return _orderRepository.GetAll();
    }

    // Método para obter todos os pedidos com detalhes completos
    public IEnumerable<OrderModel> GetAllOrdersWithDetails()
    {
        return _orderRepository.GetAllWithDetails();
    }

    // Método para obter um pedido por ID
    public OrderModel GetOrderById(int id)
    {
        return _orderRepository.GetById(id);
    }

    // Método para obter um pedido por ID com detalhes completos
    public OrderModel GetOrderByIdWithDetails(int id)
    {
        return _orderRepository.GetByIdWithDetails(id);
    }

    // Método para adicionar um novo pedido
    public void AddOrder(OrderModel order)
    {
        if (order.OrderProducts == null || order.OrderProducts.Count == 0)
        {
            throw new ArgumentException("O pedido deve ter pelo menos um produto associado.");
        }
        _orderRepository.Add(order);
    }

    // Método para atualizar um pedido existente
    public void UpdateOrder(OrderModel order)
    {
        if (order.OrderProducts == null || order.OrderProducts.Count == 0)
        {
            throw new ArgumentException("O pedido deve ter pelo menos um produto associado.");
        }
        _orderRepository.Update(order);
    }

    // Método para deletar um pedido
    public void DeleteOrder(OrderModel order)
    {
        _orderRepository.Delete(order);
    }
}