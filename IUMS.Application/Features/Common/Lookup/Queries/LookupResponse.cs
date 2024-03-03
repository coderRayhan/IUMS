namespace IUMS.Application.Features.Academic.Lookup.Queries;
public class LookupResponse
{
    public int Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public string NameBN { get; set; }

    public int ParentId { get; set; }

    public string ParentsName { get; set; }

    public string Status { get; set; }
}
