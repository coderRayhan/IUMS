using IUMS.Application.Constants;
using IUMS.Application.Features.Academic.Department.Queries.GetFilteredDeptByFaculty;
using IUMS.Application.Features.Common.Queries;
using IUMS.Web.Abstractions;
using IUMS.Web.Areas.Academic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IUMS.Web.Areas.Common.Controllers;
[Area("Common")]
public class DropdownController : BaseController<DropdownController>
{
    public async Task<List<DepartmentViewModel>> DepartmentsByFaculty(int facultyId)
    {
        var response = await _mediator.Send(new GetDeptByFacultyForDropdownQuery(facultyId));
        if (response.Succeeded)
        {
            var departments = _mapper.Map<List<DepartmentViewModel>>(response.Data);
            return departments;
        }
        return null;
    }

    public async Task<IEnumerable<CommonDropdownResponse>> ProgramsByFaculty(int departmentId)
    {
        object[] parameterList = new object[] { departmentId };
        var list = await _mediator.Send(new CommonDropdownQuery(CommonDropdownConstants.GET_ALL_PROGRAMS, parameterList));
        return list.Data;
    }
}
