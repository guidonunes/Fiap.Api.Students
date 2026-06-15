using Fiap.Api.Students.Models;

namespace Fiap.Api.Students.Services;

public interface IClientService
{
    IEnumerable<ClientModel> GetAllClients();
    IEnumerable<ClientModel> GetAllClients(int page, int size);
    ClientModel GetClientById(int id);
    void CreateClient(ClientModel client);
    void UpdateClient(ClientModel client);
    void DeleteClient(int id);
}
