using AutoMapper;
using Fiap.Api.Students.Models;
using Fiap.Api.Students.Services;
using Fiap.Api.Students.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Students.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ClientController: ControllerBase
{
    private readonly IClientService _service;
    private readonly IMapper _mapper;

    public ClientController(IClientService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize(Roles = "operador,analista,gerente")]
    public ActionResult<IEnumerable<ClientViewModel>> Get()
    {
        var clients = _service.GetAllClients();
        var viewModelList = _mapper.Map<IEnumerable<ClientViewModel>>(clients);
        return Ok(viewModelList);
    }

    [HttpGet("{id}")]
    [Authorize(Roles="analista,gerente")]
    public ActionResult<ClientViewModel> Get(int id)
    {
        var client = _service.GetClientById(id);
        if (client == null)
            return NotFound();

        var viewModel = _mapper.Map<ClientViewModel>(client);
        return Ok(viewModel);
    }

    [HttpPost]
    public ActionResult Post([FromBody] ClientViewModel clientViewModel)
    {
        var client = _mapper.Map<ClientModel>(clientViewModel);
        _service.CreateClient(client);
        return CreatedAtAction(nameof(Get), new {id = client.ClientId}, clientViewModel);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] ClientViewModel clientViewModel)
    {
        var client = _service.GetClientById(id);
        if (client == null)
            return NotFound();
        _mapper.Map(clientViewModel, client);
        _service.UpdateClient(client);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _service.DeleteClient(id);
        return NoContent();
    }
}