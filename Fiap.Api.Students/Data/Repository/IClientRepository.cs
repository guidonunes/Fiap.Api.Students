using Fiap.Api.Students.Models;

namespace Fiap.Api.Students.Data.Repository;

public interface IClientRepository
{
    IEnumerable<ClientModel> GetAll();
    ClientModel GetById(int id);
    void Add(ClientModel client);
    void Update(ClientModel client);
    void Delete(ClientModel client);
}