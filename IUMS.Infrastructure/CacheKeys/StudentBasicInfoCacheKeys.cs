namespace IUMS.Infrastructure.CacheKeys
{
    public static class StudentBasicInfoCacheKeys
    {
        public static string ListKey => "StudentList";

        public static string SelectListKey => "StudentSelectList";

        public static string GetKey(int studentId) => $"Student-{studentId}";

        public static string GetDetailsKey(int studentId) => $"StudentDetails-{studentId}";
    }
}