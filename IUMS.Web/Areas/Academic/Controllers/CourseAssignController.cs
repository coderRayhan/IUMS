using IUMS.Application.Features.Academic.CourseAssigns.Queries;
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

        var courseAssignViewModelList = _mapper.Map<List<CourseAssignViewModel>>(response.Data);

        return PartialView("_ViewAll", courseAssignViewModelList);
    }

    public async Task<IActionResult> OnGetCreateOrEdit(int id)
    {
        if(id == 0)
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

            var viewModel = _mapper.Map<CourseAssignResponse>(response.Data);

            return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", viewModel) });
        }
    }
}
