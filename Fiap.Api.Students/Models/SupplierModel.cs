namespace Fiap.Api.Students.Models;

public class SupplierModel
{
    public int supplierId { get; set; }
    public string Name { get; set; }
    
    public List<ProductModel> Products { get; set; }
}