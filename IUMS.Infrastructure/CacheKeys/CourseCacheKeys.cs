namespace IUMS.Infrastructure.CacheKeys;
public static class CourseCacheKeys
{
    public static string ListKey => "CourseList";

    public static string SelectListKey => "CourseSelectList";

    public static string GetKey(int courseId) => $"Course-{courseId}";

    public static string GetDetailsKey(int courseId) => $"CourseDetails-{courseId}";
}
