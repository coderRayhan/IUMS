namespace IUMS.Web.Areas.Academic.Models;
public class LookupViewModel
{
    public LookupViewModel()
    {
        Local = System.Globalization.CultureInfo.CurrentCulture.Name;
    }
    public int Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public string NameBN { get; set; }

    public int ParentId { get; set; } = 0;

    public string ParentsName { get; set; }

    public string Status { get; set; } = "true";

    public string Local { get; set; }

    public string SLNoBN { get; set; }
    //---------
    public string MenuName { get; set; }
    public string MenuNameBN { get; set; }
    public string MenuUrl { get; set; }
    public int MenuId { get; set; }
}

