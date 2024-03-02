namespace IUMS.Infrastructure.CacheKeys
{
    public static class BatchCacheKeys
    {
        public static string ListKey => "BatchList";

        public static string SelectListKey => "BatchSelectList";

        public static string GetKey(int BatchId) => $"Batch-{BatchId}";

        public static string GetDetailsKey(int BatchId) => $"BatchDetails-{BatchId}";
    }
}
