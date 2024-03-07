using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using IUMS.Web.Abstractions;
using IUMS.Application.Features.Academic.Courses.Queries;
using IUMS.Web.Areas.Academic.Models;
using IUMS.Application.Features.Academic.Courses.Commands;
using IUMS.Application.Constants;

namespace UEMS.Web.Areas.Academic.Controllers;
[Area("Academic")]
public class CourseController : BaseController<CourseController>
{

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> LoadAll(int programId)
    {
        var response = await _mediator.Send(new CourseByFilterQuery(programId));
        if (response.Succeeded)
        {
            var viewModel = _mapper.Map<List<CourseViewModel>>(response.Data);
            return PartialView("_ViewAll", viewModel);
        }
        return null;
    }


    public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
    {
        if (id == 0)
        {
            var CourseViewModel = new CourseViewModel();
            return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", CourseViewModel) });
        }
        else
        {
            var response = await _mediator.Send(new CourseByIdQuery(id));
            if (response.Succeeded)
            {
                var CourseViewModel = _mapper.Map<CourseViewModel>(response.Data);
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", CourseViewModel) });
            }
            return new JsonResult(new { isValid = false });
        }
    }

    [HttpPost]
    public async Task<JsonResult> OnPostCreateOrEdit(int id, CourseViewModel course)
    {
        if (ModelState.IsValid)
        {
            if (id == 0)
            {
                var createcourseCommand = _mapper.Map<CreateCourseCommand>(course);
                var result = await _mediator.Send(createcourseCommand);
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
                var updateCourseCommand = _mapper.Map<UpdateCourseCommand>(course);
                var result = await _mediator.Send(updateCourseCommand);

                if (result.Succeeded)
                {
                    _notify.Information(_localizer[LocalizerConstant.UPDATE]);
                }
                else
                {
                    _notify.Error(_localizer[result.Message]);
                    return new JsonResult(new { isValid = false });
                }
            }
            var response = await _mediator.Send(new CourseByFilterQuery(0));
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<CourseViewModel>>(response.Data);
                var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                return new JsonResult(new { isValid = true, html });
            }
            else
            {
                _notify.Error(_localizer[response.Message]);
                return new JsonResult(new { isValid = false });
            }
        }
        else
        {


            var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", course);
            return new JsonResult(new { isValid = false, html });
        }
    }

    [HttpPost]
    public async Task<JsonResult> OnPostDelete(int id)
    {
        var deleteCommand = await _mediator.Send(new DeleteCourseCommand(id));
        if (deleteCommand.Succeeded)
        {

            var response = await _mediator.Send(new CourseByFilterQuery(0));
            if (response.Succeeded)
            {
                _notify.Information(_localizer[LocalizerConstant.DELETE]);
                var viewModel = _mapper.Map<List<CourseViewModel>>(response.Data);
                var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                return new JsonResult(new { isValid = true, html });
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
