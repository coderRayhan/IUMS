namespace IUMS.Infrastructure.CacheKeys;
public static class CourseAssignCacheKeys
{
    public static string ListKey => "CourseAssignList";
    public static string SelectListKey => "CourseAssignSelectList";
    public static string GetKey(int courseAssignId) => $"CourseAssign-{courseAssignId}";
    public static string GetDetailsKey(int courseAssignId) => $"CourseAssignDetails-{courseAssignId}";
}
