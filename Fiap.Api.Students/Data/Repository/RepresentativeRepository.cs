using Fiap.Api.Students.Models;

namespace Fiap.Api.Students.Data.Repository;

public class RepresentativeRepository: IRepresentativeRepository
{
    private readonly DatabaseContext _context;

    public RepresentativeRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IEnumerable<RepresentativeModel> GetAll() => _context.Representatives.ToList();

    public RepresentativeModel GetById(int id) => _context.Representatives.Find(id);

    public void Add(RepresentativeModel representante)
    {
        _context.Representatives.Add(representante);
        _context.SaveChanges();
    }

    public void Update(RepresentativeModel representante)
    {
        _context.Representatives.Update(representante);
        _context.SaveChanges();
    }

    public void Delete(RepresentativeModel representante)
    {
        _context.Representatives.Remove(representante);
        _context.SaveChanges();
    }
}