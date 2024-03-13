namespace IUMS.Infrastructure.CacheKeys;
public static class EmployeeCacheKeys
{
    public static string ListKey => "EmployeeList";

    public static string SelectListKey => "EmployeeSelectList";

    public static string GetKey(int employeeId) => $"Employee-{employeeId}";

    public static string GetDetailsKey(int employeeId) => $"EmployeeDetails-{employeeId}";
}
