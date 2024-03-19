using IUMS.Domain.Entities.Academic;

namespace IUMS.Infrastructure.CacheKeys
{
    public static class TeacherAssignCacheKeys
    {
        public static string ListKey => "TeacherAssign";

        public static string SelectListKey => "TeacherAssignSelectList";

        public static string GetKey(int teacherAssignId) => $"TeacherAssign-{teacherAssignId}";

        public static string GetDetailsKey(int teacherAssignId) => $"TeacherAssignDetails-{teacherAssignId}";
    }
}
