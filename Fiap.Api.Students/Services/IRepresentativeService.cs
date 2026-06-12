using Fiap.Api.Students.Models;

namespace Fiap.Api.Students.Services;

public interface IRepresentativeService
{
    IEnumerable<RepresentativeModel> GetAllRepresentatives();
    RepresentativeModel GetRepresentativeById(int id);
    void CreateRepresentative(RepresentativeModel representative);
    void UpdateRepresentative(RepresentativeModel representative);
    void DeleteRepresentative(int id);
}