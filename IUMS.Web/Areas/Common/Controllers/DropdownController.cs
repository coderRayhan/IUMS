using IUMS.Application.Constants;
using IUMS.Application.Features.Academic.Courses.Queries;
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
    
    public async Task<IEnumerable<CommonDropdownResponse>> FacultyListFromTeacherAssign(int teacherId, int sessionid)
    {
        object[] parameterList = new object[] { teacherId, sessionid };
        var list = await _mediator.Send(new CommonDropdownQuery(CommonDropdownConstants.GET_LMS_FACULTY_BY_TEACHER, parameterList));
        return list.Data;
    }
    
    public async Task<IEnumerable<CommonDropdownResponse>> DepartmentListFromTeacherAssign(int teacherId, int facultyId)
    {
        object[] parameterList = new object[] { teacherId, facultyId };
        var list = await _mediator.Send(new CommonDropdownQuery(CommonDropdownConstants.GET_LMS_DEPARTMENT_BY_TEACHER, parameterList));
        return list.Data;
    }
    
    public async Task<IEnumerable<CommonDropdownResponse>> ProgramListFromTeacherAssign(int teacherId, int facultyId, int departmentId)
    {
        object[] parameterList = new object[] { teacherId, facultyId, departmentId };
        var list = await _mediator.Send(new CommonDropdownQuery(CommonDropdownConstants.GET_LMS_PROGRAM_BY_TEACHER, parameterList));
        return list.Data;
    }
    
    public async Task<IEnumerable<CommonDropdownResponse>> BatchListFromTeacherAssign(int teacherId, int programId)
    {
        object[] parameterList = new object[] { teacherId, programId };
        var list = await _mediator.Send(new CommonDropdownQuery(CommonDropdownConstants.GET_LMS_BATCH_BY_TEACHER, parameterList));
        return list.Data;
    }
    
    public async Task<IEnumerable<CommonDropdownResponse>> CourseAssignListFromTeacherAssignByTeacher(int teacherId, int facultyId, int departmentId, int programId, int batchId, int academicSemesterId)
    {
        object[] parameterList = new object[] { teacherId, facultyId, departmentId, programId, batchId, academicSemesterId };
        var list = await _mediator.Send(new CommonDropdownQuery(CommonDropdownConstants.GET_LMS_COURSE_ASSIGN_BY_TEACHER, parameterList));
        return list.Data;
    }

    public async Task<IEnumerable<CourseByProgramResponse>> FilterCourseByProgram(int programId)
    {
        var res = await _mediator.Send(new CourseByProgramQuery(programId));
        if (res.Succeeded)
            return res.Data;
        else
            return null;
    }
}
