namespace Fiap.Api.Students.ViewModel;

public class CreateOrderViewModel
{
    public DateTime OrderDate { get; set; }
    public int ClientId { get; set; }
    public int StoreId { get; set; }
    public List<int> ProductIds { get; set; }
}