using Fiap.Api.Students.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Students.Data.Repository;

public class ClientRepository: IClientRepository
{
    private readonly DatabaseContext _context;

    public ClientRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IEnumerable<ClientModel> GetAll() => _context.Clients.Include(c => c.Representative).ToList();

    public IEnumerable<ClientModel> GetAll(int page, int size)
    {
        return _context.Clients.Include(c => c.Representative)
            .Skip((page - 1) * size)
            .Take(size)
            .AsNoTracking()
            .ToList();
    }

    public IEnumerable<ClientModel> GetAllReference(int lastReference, int size)
    {
        var clients = _context.Clients.Include(c => c.Representative)
            .Where(c => c.ClientId == lastReference)
            .OrderBy(c => c.ClientId)
            .Take(size)
            .AsNoTracking()
            .ToList();
        return clients;
    }

    public ClientModel GetById(int id) => _context.Clients.Find(id);

    public void Add(ClientModel client)
    {
        _context.Clients.Add(client);
        _context.SaveChanges();
    }

    public void Update(ClientModel client)
    {
        _context.Update(client);
        _context.SaveChanges();
    }

    public void Delete(ClientModel client)
    {
        _context.Clients.Remove(client);
        _context.SaveChanges();
    }
}