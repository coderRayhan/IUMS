namespace IUMS.Web.Areas.Academic.Models;
public class LookupDetailViewModel
{
    public LookupDetailViewModel()
    {
        Local = System.Globalization.CultureInfo.CurrentCulture.Name;

    }
    public int Id { get; set; }

    public string Code { get; set; }

    public int LookupId { get; set; }

    public string LookupName { get; set; }

    public string LookupNameBN { get; set; }

    public string Name { get; set; }

    public string NameBN { get; set; }

    public int ParentId { get; set; }

    public string ParentsName { get; set; }

    public string Description { get; set; }

    public string Status { get; set; } = "true";

    public string Local { get; set; }

    public string SLNoBN { get; set; }
    //---------
    public string MenuName { get; set; }
    public string MenuNameBN { get; set; }
    public string MenuUrl { get; set; }
    public int MenuId { get; set; }
}
