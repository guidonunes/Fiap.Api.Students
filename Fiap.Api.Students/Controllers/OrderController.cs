using AutoMapper;
using Fiap.Api.Students.Models;
using Fiap.Api.Students.Services;
using Fiap.Api.Students.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Students.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController: ControllerBase
{
    private readonly IOrderService _service;
    private readonly IMapper _mapper;

    public OrderController(IOrderService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<OrderViewModel>> Get()
    {
        var orders = _service.GetAllOrdersWithDetails();
        var orderModels = _mapper.Map<IEnumerable<OrderViewModel>>(orders);
        return Ok(orderModels);
    }

    [HttpGet("{id}")]
    public ActionResult<OrderViewModel> GetOrderById(int id)
    {
        var order = _service.GetOrderByIdWithDetails(id);
        if (order == null)
        {
            return NotFound();
        }
        
        var orderViewModel = _mapper.Map<OrderViewModel>(order);
        return Ok(orderViewModel);
    }


    [HttpPost]
    public ActionResult Post([FromBody] CreateOrderViewModel createOrderViewModel)
    {
        var order = _mapper.Map<OrderModel>(createOrderViewModel);

        try
        {
            _service.AddOrder(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderId }, createOrderViewModel);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
}
