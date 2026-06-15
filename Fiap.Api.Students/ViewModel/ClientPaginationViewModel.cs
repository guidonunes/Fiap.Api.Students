namespace Fiap.Api.Students.ViewModel;

public class ClientPaginationViewModel
{
    public IEnumerable<ClientViewModel> Clients { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public bool HasPreviousPage => CurrentPage > 1;
    public bool HasNextPage => Clients.Count() == PageSize;
    public string PreviousPageUrl => HasPreviousPage ? $"/api/Client/pagination?page={CurrentPage - 1}&size={PageSize}" : "";
    public string NextPageUrl => HasNextPage ? $"/api/Client/pagination?page={CurrentPage + 1}&size={PageSize}" : "";
}

public class ClientPaginationReferenceViewModel
{
    public IEnumerable<ClientViewModel> Clients { get; set; }
    public int PageSize { get; set; }
    public int Ref{get; set;}
    public int NextRef{get; set;}
    public string PreviousPageUrl => $"/Client?reference={Ref}&size={PageSize}";
    public string NextPageUrl => (Ref < NextRef) ? $"/Client?reference={Ref}&size={PageSize}" : "";
    
}
