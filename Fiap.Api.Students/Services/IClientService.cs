using Fiap.Api.Students.Models;

namespace Fiap.Api.Students.Services;

public interface IClientService
{
    IEnumerable<ClientModel> GetAllClients();
    ClientModel GetClientById(int id);
    void CreateClient(ClientModel client);
    void UpdateClient(ClientModel client);
    void DeleteCliente(int id);
}