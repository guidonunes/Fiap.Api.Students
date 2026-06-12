namespace Fiap.Api.Students.ViewModel;

public class OrderViewModel
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public int ClientId { get; set; }
    public ClientViewModel Client { get; set; }
    public int StoreId { get; set; }
    public StoreViewModel Store { get; set; }
    public IEnumerable<ProductViewModel> Products { get; set; }
}