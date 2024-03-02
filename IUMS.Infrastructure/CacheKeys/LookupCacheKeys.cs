using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUMS.Infrastructure.CacheKeys;
public static class LookupCacheKeys
{
    public static string ListKey => "LooupList";

    public static string SelectListKey => "LookupSelectList";

    public static string GetKey(int lookupId) => $"Lookup-{lookupId}";

    public static string GetDetailsKey(int lookupId) => $"LookupDetails-{lookupId}";
}
