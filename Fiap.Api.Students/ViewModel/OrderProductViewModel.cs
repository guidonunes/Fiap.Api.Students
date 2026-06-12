namespace Fiap.Api.Students.ViewModel;

public class OrderProductViewModel
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public ProductViewModel Product { get; set; }
}