namespace Fiap.Api.Students.ViewModel;

public class ClientViewModel
{
    public int ClientId { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate{ get; set; }
    public string Observation { get; set; }
    public int RepresentativeId { get; set; }
    public RepresentativeViewModel? Representative { get; set; }
}
