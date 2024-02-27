namespace IUMS.Infrastructure.CacheKeys
{
    public static class SessionCacheKeys
	{
        public static string ListKey => "SessionList";

        public static string SelectListKey => "SessionSelectList";

        public static string GetKey(int sessionId) => $"Session-{sessionId}";

        public static string GetDetailsKey(int sessionId) => $"SessionDetails-{sessionId}";
    }
}