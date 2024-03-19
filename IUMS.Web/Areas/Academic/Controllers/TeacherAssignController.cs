using IUMS.Application.Constants;
using IUMS.Application.Features;
using IUMS.Application.Features.Academic.TeacherAssigns.Commands;
using IUMS.Application.Features.Academic.TeacherAssigns.Queries;
using IUMS.Web.Abstractions;
using IUMS.Web.Areas.Academic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IUMS.Web.Areas.Academic.Controllers;
[Area("Academic")]
public class TeacherAssignController : BaseController<TeacherAssignController>
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> LoadAll()
    {
        var response = await _mediator.Send(new TeacherAssignListQuery());
        if (response.Succeeded)
        {
            var viewModel = _mapper.Map<List<TeacherAssignViewModel>>(response.Data);
            return PartialView("_ViewAll", viewModel);
        }
        return null;
    }

    public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
    {

        if (id == 0)
        {
            var vm = new TeacherAssignViewModel();
            return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", vm) });
        }
        else
        {
            var response = await _mediator.Send(new TeacherAssignByIdQuery(id));
            if (response.Succeeded)
            {
                var vm = _mapper.Map<TeacherAssignViewModel>(response.Data);
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", vm) });
            }
            return new JsonResult(new { isValid = false });
        }
    }

    [HttpPost]
    public async Task<JsonResult> OnPostCreateOrEdit(int Id, TeacherAssignViewModel vModel)
    {
        if (ModelState.IsValid)
        {
            if (Id == 0)
            {
                var createCommand = _mapper.Map<CreateTeacherAssignCommand>(vModel);
                var result = await _mediator.Send(createCommand);
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
                var updateCommand = _mapper.Map<UpdateTeacherAssignCommand>(vModel);
                var result = await _mediator.Send(updateCommand);
                if (result.Succeeded) _notify.Information(_localizer[LocalizerConstant.UPDATE]);
                else
                {
                    _notify.Error(_localizer[result.Message]);
                    return new JsonResult(new { isValid = false });
                }
            }
            var response = await _mediator.Send(new TeacherAssignListQuery());
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<TeacherAssignResponse>>(response.Data);
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


            var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", vModel);
            return new JsonResult(new { isValid = false, html = html });
        }
    }

    [HttpPost]
    public async Task<JsonResult> OnPostDelete(int id)
    {
        var deleteCommand = await _mediator.Send(new DeleteTeacherAssignCommand(id));
        if (deleteCommand.Succeeded)
        {

            var response = await _mediator.Send(new TeacherAssignListQuery());
            if (response.Succeeded)
            {
                _notify.Information(_localizer[LocalizerConstant.DELETE]);
                var viewModel = _mapper.Map<List<TeacherAssignViewModel>>(response.Data);
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
