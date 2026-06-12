using Fiap.Api.Students.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Students.Data.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly DatabaseContext _context;

    public OrderRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IEnumerable<OrderModel> GetAll()
    {
        return _context.Orders
            .ToList();
    }

    // Método para obter todos os pedidos com detalhes completos
    public IEnumerable<OrderModel> GetAllWithDetails()
    {
        return _context.Orders
            .Include(o => o.Client)  // Incluir dados do cliente
            .Include(o => o.Store)     // Incluir dados da loja
            .Include(o => o.OrderProducts)  // Incluir relacionamento PedidoProduto
            .ThenInclude(op => op.Product)  // E então incluir produtos de cada PedidoProduto
            .ThenInclude(op => op.Supplier)  // Incluir fornecedor de cada produto
            .ToList();
    }

    public OrderModel GetById(int id)
    {
        return _context.Orders.Find(id);
    }

    public OrderModel GetByIdWithDetails(int id)
    {
        return _context.Orders
            .Where(o => o.OrderId == id)
            .Include(o => o.Client)
            .Include(o => o.Store)
            .Include(o => o.OrderProducts)
            .ThenInclude(op => op.Product)
            .ThenInclude(op => op.Supplier)
            .FirstOrDefault();
    }

    public void Add(OrderModel order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }

    public void Update(OrderModel order)
    {
        _context.Update(order);
        _context.SaveChanges();
    }

    public void Delete(OrderModel order)
    {
        _context.Orders.Remove(order);
        _context.SaveChanges();
    }
}
