using IUMS.Application.Constants;
using IUMS.Application.Features;
using IUMS.Application.Features.Academic.CourseAssigns.Commands;
using IUMS.Application.Features.Academic.CourseAssigns.Queries;
using IUMS.Domain.Entities.Academic;
using IUMS.Web.Abstractions;
using IUMS.Web.Areas.Academic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IUMS.Web.Areas.Academic.Controllers;
[Area("Academic")]
public class CourseAssignController : BaseController<CourseAssignController>
{
    public IActionResult Index()
    {
        var model = new CourseAssignViewModel();
        return View(model);
    }

    public async Task<IActionResult> LoadAll(
        int sessionId,
        int facultyId,
        int departmentId,
        int programId,
        int batchId,
        int academicSemesterId)
    {
        var response = await _mediator.Send(new CourseAssignListQuery(
            sessionId,
            facultyId,
            departmentId,
            programId,
            batchId,
            academicSemesterId));

        if (!response.Succeeded)
        {
            _notify.Error(response.Message);
            return null;
        }

        var courseAssignViewModelList = _mapper.Map<IEnumerable<CourseAssignViewModel>>(response.Data);

        return PartialView("_ViewAll", courseAssignViewModelList);
    }

    public async Task<IActionResult> OnGetCreateOrEdit(int id)
    {
        if (id == 0)
        {
            var viewModel = new CourseAssignViewModel();
            return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", viewModel) });
        }
        else
        {
            var response = await _mediator.Send(new CourseAssignByIdQuery(id));

            if (!response.Succeeded)
            {
                _notify.Error(response.Message);
                return new JsonResult(new { isValid = false });
            }

            var viewModel = _mapper.Map<CourseAssignViewModel>(response.Data);

            return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", viewModel) });
        }
    }

    [HttpPost]
    public async Task<JsonResult> OnPostCreateOrEdit(int Id, CourseAssignViewModel courseAssign)
    {
        if (ModelState.IsValid)
        {
            if (Id == 0)
            {
                var createCourseAssign = _mapper.Map<CreateCourseAssignCommand>(courseAssign);
                var result = await _mediator.Send(createCourseAssign);
                if (result.Succeeded)
                {
                    _notify.Success(_localizer[LocalizerConstant.SAVED]);
                }
                else
                {
                    _notify.Error(_localizer[result.Message]);
                    return new JsonResult(new { isValid = false });
                }
            }
            else
            {
                var updateCourseAssign = _mapper.Map<UpdateCourseAssignCommand>(courseAssign);
                var result = await _mediator.Send(updateCourseAssign);
                if (result.Succeeded) _notify.Information(_localizer[LocalizerConstant.UPDATE]);
                else
                {
                    _notify.Error(_localizer[result.Message]);
                    return new JsonResult(new { isValid = false });
                }
            }
            var response = await _mediator.Send(new CourseAssignListQuery(
                courseAssign.SessionId,
                courseAssign.FacultyId,
                courseAssign.DepartmentId,
                courseAssign.ProgramId,
                courseAssign.BatchId,
                courseAssign.AcademicSemesterId));
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<IEnumerable<CourseAssignViewModel>>(response.Data);
                var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                return new JsonResult(new { isValid = true, html = html });
            }
            else
            {
                _notify.Error(_localizer[response.Message]);
                return new JsonResult(new { isValid = false });
            }
        }
        else
        {


            var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", courseAssign);
            return new JsonResult(new { isValid = false, html = html });
        }
    }

    [HttpPost]
    public async Task<JsonResult> OnPostDelete(int id)
    {
        var deleteCommand = await _mediator.Send(new DeleteCourseAssignCommand(id));
        if (deleteCommand.Succeeded)
        {

            var response = await _mediator.Send(new CourseAssignListQuery(0, 0, 0, 0, 0, 0));
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<IEnumerable<CourseAssignViewModel>>(response.Data);
                var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                return new JsonResult(new { isValid = true, html = html });
            }
            else
            {
                _notify.Error(_localizer[response.Message]);
                return new JsonResult(new { isValid = false });
            }
        }
        else
        {
            _notify.Error(_localizer[deleteCommand.Message]);
            return new JsonResult(new { isValid = false });
        }
    }
}
