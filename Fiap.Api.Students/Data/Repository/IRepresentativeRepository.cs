using Fiap.Api.Students.Models;

namespace Fiap.Api.Students.Data.Repository;

public interface IRepresentativeRepository
{
    IEnumerable<RepresentativeModel> GetAll();
    RepresentativeModel GetById(int id);
    void Add(RepresentativeModel representative);
    void Update(RepresentativeModel representative);
    void Delete(RepresentativeModel representative);
}