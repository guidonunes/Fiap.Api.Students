using Fiap.Api.Students.Data.Repository;
using Fiap.Api.Students.Models;

namespace Fiap.Api.Students.Services;

public class ClientService: IClientService
{
    private readonly IClientRepository _repository;

    public ClientService(IClientRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<ClientModel> GetAllClients() => _repository.GetAll();

    public IEnumerable<ClientModel> GetAllClients(int page, int size) => _repository.GetAll(page, size);

    public ClientModel GetClientById(int id) => _repository.GetById(id);

    public void CreateClient(ClientModel client) => _repository.Add(client);        

    public void UpdateClient(ClientModel client) => _repository.Update(client);

    public void DeleteClient(int id)
    {
        var client = _repository.GetById(id);
        if (client != null)
        {
            _repository.Delete(client);
        }
    }
}
