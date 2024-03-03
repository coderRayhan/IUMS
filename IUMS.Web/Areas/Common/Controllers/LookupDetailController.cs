using IUMS.Application.Constants;
using IUMS.Application.Features.Academic.Department.Queries.GetFilteredDeptByFaculty;
using IUMS.Application.Features.Academic.LookupDetail.Commands;
using IUMS.Application.Features.Academic.LookupDetail.Queries;
using IUMS.Application.Features.Common;
using IUMS.Web.Abstractions;
using IUMS.Web.Areas.Academic.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IUMS.Web.Areas.Academic.Controllers;
[Area("Common")]
public class LookupDetailController : BaseController<LookupDetailController>
{
    public IActionResult Index(int id)
    {
        return View();
    }
    ////[Authorize(Policy = Permissions.CommonLookups.View)]
    public async Task<IActionResult> LoadAll()
    {
        var response = await _mediator.Send(new GetAllLookupDetailQuery());
        if (response.Succeeded)
        {
            var viewModel = _mapper.Map<List<LookupDetailViewModel>>(response.Data);
            return PartialView("_ViewAll", viewModel);
        }
        return null;
    }

    ////[Authorize(Policy = Permissions.CommonLookups.View)]
    public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
    {
        if (id == 0)
        {
            var lookupDetailViewModel = new LookupDetailViewModel();
            return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", lookupDetailViewModel) });
        }
        else
        {
            var response = await _mediator.Send(new GetLookupDetailByIdQuery(id));
            if (response.Succeeded)
            {
                var lookupDetailViewModel = _mapper.Map<LookupDetailViewModel>(response.Data);
                lookupDetailViewModel.Status = lookupDetailViewModel.Status == "A" ? "true" : "false";
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", lookupDetailViewModel) });
            }
            return new JsonResult(new { isValid = false });
        }
    }

    ////[Authorize(Policy = Permissions.CommonLookups.View)]
    [HttpPost]
    public async Task<JsonResult> OnPostCreateOrEdit(int id, LookupDetailViewModel lookupDetails)
    {
        try
        {
            if (lookupDetails.Name != null && lookupDetails.NameBN != null && lookupDetails.LookupId > 0)
            {

                if (id == 0)
                {

                    var createLookupDetailCommand = _mapper.Map<CreateLookupDetailCommand>(lookupDetails);
                    var result = await _mediator.Send(createLookupDetailCommand);
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
                    var updateLookupDetailCommand = _mapper.Map<UpdateLookupDetailCommand>(lookupDetails);
                    var result = await _mediator.Send(updateLookupDetailCommand);
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
                var response = await _mediator.Send(new GetAllLookupDetailQuery());
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<LookupDetailViewModel>>(response.Data);
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
                //_notify.Error(ModelState.GetModelStateError());
                var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", lookupDetails);
                return new JsonResult(new { isValid = false, html = html });
            }
        }
        catch (Exception ex)
        {
            _notify.Error(_localizer[ex.Message]);
            var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", lookupDetails);
            return new JsonResult(new { isValid = false, html = html });
        }

    }

    // //[Authorize(Policy = Permissions.CommonLookups.Delete)]
    [HttpPost]
    public async Task<JsonResult> OnPostDelete(int id)
    {
        var deleteCommand = await _mediator.Send(new DeleteLookupDetailCommand(id));
        if (deleteCommand.Succeeded)
        {
            _notify.Success(_localizer[deleteCommand.Message]);
            var response = await _mediator.Send(new GetAllLookupDetailQuery());
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<LookupDetailViewModel>>(response.Data);
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

    public async Task<List<LookupDetailViewModel>> GetParentByCommonLookup(int lookupId)
    {
        var response = await _mediator.Send(new GetDetailParentByLookupIdQuery(lookupId));

        if (response.Succeeded)
        {
            var getDetailParentByLookupIdQuery = _mapper.Map<List<LookupDetailViewModel>>(response.Data);
            return getDetailParentByLookupIdQuery;
        }
        _notify.Error(_localizer[LocalizerConstant.NO_DATA_FOUND]);
        return null;
    }

    [HttpPost]
    public async Task<JsonResult> OnPostCommonDetailsStatus(int id, LookupDetailViewModel masterDetails)
    {
        try
        {
            if (id > 0)
            {
                var result = await _mediator.Send(new LookupDetailStatusUpdateCommand(id));
                if (result.Succeeded)
                {
                    _notify.Information(_localizer[LocalizerConstant.UPDATE]);
                }
                else
                {
                    _notify.Error(_localizer[result.Message]);
                    return new JsonResult(new { isValid = false });
                }
                var response = await _mediator.Send(new GetAllLookupDetailQuery());
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<LookupDetailViewModel>>(response.Data);
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
                var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", masterDetails);
                return new JsonResult(new { isValid = false, html = html });
            }
        }
        catch (Exception ex)
        {
            _notify.Error(_localizer[ex.Message]);
            var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", masterDetails);
            return new JsonResult(new { isValid = false, html = html });
        }
    }


    public async Task<List<DepartmentViewModel>> FilterDeptByFaculty(int FacultyId)
    {
        var response = await _mediator.Send(new GetDeptByFacultyQuery(FacultyId));

        if (response.Succeeded)
        {
            var deptList = _mapper.Map<List<DepartmentViewModel>>(response.Data);
            return deptList;
        }
        _notify.Error(_localizer[LocalizerConstant.NO_DATA_FOUND]);
        return null;
    }

}