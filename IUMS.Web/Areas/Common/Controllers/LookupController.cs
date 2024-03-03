using IUMS.Application.Constants;
using IUMS.Application.Features.Academic.Lookup.Commands;
using IUMS.Application.Features.Academic.Lookup.Queries;
using IUMS.Application.Features.Common;
using IUMS.Web.Abstractions;
using IUMS.Web.Areas.Academic.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUMS.Web.Areas.Academic.Controllers;
[Area("Common")]
public class LookupController : BaseController<LookupController>
{
    ////[Authorize(Policy = Permissions.CommonLookups.View)]
    public IActionResult Index(int id)
    {
        return View();
    }

    ////[Authorize(Policy = Permissions.CommonLookups.View)]     
    public async Task<IActionResult> LoadAll()
    {
        var response = await _mediator.Send(new GetAllLookupQuery());
        if (response.Succeeded)
        {
            var viewModel = _mapper.Map<List<LookupViewModel>>(response.Data);
            return PartialView("_ViewAll", viewModel);
        }
        return null;
    }

    ////[Authorize(Policy = Permissions.CommonLookups.View)]
    public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
    {
        if (id == 0)
        {
            var lookupViewModel = new LookupViewModel();
            return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", lookupViewModel) });
        }
        else
        {
            var response = await _mediator.Send(new GetLookupByIdQuery(id));
            if (response.Succeeded)
            {
                var lookupViewModel = _mapper.Map<LookupViewModel>(response.Data);
                lookupViewModel.Status = lookupViewModel.Status == "A" ? "true" : "false";
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", lookupViewModel) });
            }
            return new JsonResult(new { isValid = false });
        }
    }

    ////[Authorize(Policy = Permissions.CommonLookups.View)]
    [HttpPost]
    public async Task<JsonResult> OnPostCreateOrEdit(int id, LookupViewModel lookup)
    {
        try
        {
            if (lookup.Name != null)
            {

                if (id == 0)
                {

                    var createLookupCommand = _mapper.Map<CreateLookupCommand>(lookup);
                    var result = await _mediator.Send(createLookupCommand);
                    if (result.Succeeded)
                    {
                        id = result.Data;
                        _notify.Success(_localizer[LocalizerConstant.SAVED]);
                        //return new JsonResult(new { isValid = true });
                    }
                    else
                    {
                        _notify.Error(_localizer[result.Message]);
                        return new JsonResult(new { isValid = false });
                    }
                }
                else
                {
                    var updateLookupCommand = _mapper.Map<UpdateLookupCommand>(lookup);
                    var result = await _mediator.Send(updateLookupCommand);
                    if (result.Succeeded)
                    {
                        //_notify.Information(_localizer[result.Message]);
                        _notify.Information(_localizer[LocalizerConstant.UPDATE]);
                        //return new JsonResult(new { isValid = true });
                    }
                    else
                    {
                        _notify.Error(_localizer[result.Message]);
                        return new JsonResult(new { isValid = false });
                    }
                }
                var response = await _mediator.Send(new GetAllLookupQuery());
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<LookupViewModel>>(response.Data);
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
                // _notify.Error(ModelState.GetModelStateError());
                var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", lookup);
                return new JsonResult(new { isValid = false, html = html });
            }
        }
        catch (Exception ex)
        {
            _notify.Error(_localizer[ex.Message]);
            var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", lookup);
            return new JsonResult(new { isValid = false, html = html });
        }

    }

    // //[Authorize(Policy = Permissions.CommonLookups.Delete)]
    [HttpPost]
    public async Task<JsonResult> OnPostDelete(int id)
    {
        var deleteCommand = await _mediator.Send(new DeleteLookupCommand(id));
        if (deleteCommand.Succeeded)
        {
            _notify.Success(_localizer[deleteCommand.Message]);
            var response = await _mediator.Send(new GetAllLookupQuery());
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<LookupViewModel>>(response.Data);
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
    [HttpPost]
    public async Task<JsonResult> OnPostCommonLookupStatus(int id, LookupViewModel lookup)
    {
        try
        {
            if (id > 1)
            {
                var result = await _mediator.Send(new LookupStatusUpdateCommand(id));
                if (result.Succeeded)
                {
                    _notify.Information(_localizer[LocalizerConstant.UPDATE]);
                }
                else
                {
                    _notify.Error(_localizer[result.Message]);
                    return new JsonResult(new { isValid = false });
                }
                var response = await _mediator.Send(new GetAllLookupQuery());
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<LookupViewModel>>(response.Data);
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
                // _notify.Error(ModelState.GetModelStateError());
                var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", lookup);
                return new JsonResult(new { isValid = false, html = html });
            }
        }
        catch (Exception ex)
        {
            _notify.Error(_localizer[ex.Message]);
            var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", lookup);
            return new JsonResult(new { isValid = false, html = html });
        }
    }

    public async Task<List<LookupResponse>> GetAllLookUps()
    {
        List<LookupResponse> lookupList = new();
        var response = await _mediator.Send(new GetAllLookupQuery());
        if (response.Succeeded)
        {
            lookupList = _mapper.Map<List<LookupResponse>>(response.Data);
            var data = lookupList.Where(l => l.Status == "A").ToList().OrderBy(l => l.Name).ToList();
            return data;
        }
        return null;
    }
}
