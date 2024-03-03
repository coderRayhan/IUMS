using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUMS.Infrastructure.CacheKeys;
public static class LookupDetailCacheKeys
{
    public static string ListKey => "LooupDetailList";

    public static string SelectListKey => "LookupDetailSelectList";

    public static string GetKey(int lookupDetailId) => $"Lookup-{lookupDetailId}";

    public static string GetDetailsKey(int lookupDetailId) => $"LookupDetails-{lookupDetailId}";
}
