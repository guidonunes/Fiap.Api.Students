namespace Fiap.Api.Students.Models;

public class SupplierModel
{
    public int SupplierId { get; set; }
    public string Name { get; set; }
    
    public List<ProductModel> Products { get; set; }
}