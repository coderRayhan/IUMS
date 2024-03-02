namespace IUMS.Infrastructure.CacheKeys
{
    public static class ProgramCacheKeys
    {
        public static string ListKey => "ProgramList";

        public static string SelectListKey => "ProgramSelectList";

        public static string GetKey(int ProgramId) => $"Program-{ProgramId}";

        public static string GetDetailsKey(int ProgramId) => $"ProgramDetails-{ProgramId}";
    }
}
