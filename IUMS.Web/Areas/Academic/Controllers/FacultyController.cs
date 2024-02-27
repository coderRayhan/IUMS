using IUMS.Application.Constants;
using IUMS.Application.Features;
using IUMS.Web.Abstractions;
using IUMS.Web.Areas.Academic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using UEMS.Application.Features;
using UEMS.Application.Features.Academic.Faculty.Queries;
using UEMS.Application.Features.Academic.Faculty.Queries.GetAll;


namespace UEMS.Web.Areas.Academic.Controllers
{
    [Area("Academic")]
    public class FacultyController : BaseController<FacultyController>
    {
        public async Task<IActionResult> Index(int id)
        {
            return View();
        }

        public async Task<IActionResult> LoadAll()
        {
            var response = await _mediator.Send(new GetAllFacultyQuery());
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<FacultyViewModel>>(response.Data);
                return PartialView("_ViewAll", viewModel);
            }
            return null;
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                FacultyViewModel facultyViewModel = new();    
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", facultyViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetFacultyByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var FacultyViewModel = _mapper.Map<FacultyViewModel>(response.Data);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", FacultyViewModel)});
                }
                return null;
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, FacultyViewModel Faculty)
        {
            if (!Faculty.HasAffiliatedInstitute)
            {
                Faculty.AffiliatedInstituteId = 0;
            }
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    var createFacultyCommand = _mapper.Map<CreateFacultyCommand>(Faculty);
                    var result = await _mediator.Send(createFacultyCommand);
                    if (result.Succeeded)
                    {
                        _notify.Success(_localizer[LocalizerConstant.SAVED]);
                    }
                    else 
                    {
                        _notify.Error(_localizer[result.Message]);
                        return new JsonResult(new { isValid = false });
                    };
                }
                else
                {
                    var updateFacultyCommand = _mapper.Map<UpdateFacultyCommand>(Faculty);
                    var result = await _mediator.Send(updateFacultyCommand);
                    if (result.Succeeded)
                    {
                        _notify.Information(_localizer[LocalizerConstant.UPDATE_MSG]);
                    }
                    else
                    {
                        _notify.Error(_localizer[result.Message]);
                        return new JsonResult(new { isValid = false });
                    }
                }
                var response = await _mediator.Send(new GetAllFacultyQuery());
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<FacultyViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true,html });
                }
                else
                {
                    _notify.Error(_localizer[response.Message]);
                    return new JsonResult(new { isValid = false });
                }
            }
            else
            {
                var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", Faculty);
                return new JsonResult(new { isValid = false,  html });
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostDelete(int id)
        {
            var deleteCommand = await _mediator.Send(new DeleteFacultyCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information(_localizer[LocalizerConstant.DELETE]);
                var response = await _mediator.Send(new GetAllFacultyQuery());
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<FacultyViewModel>>(response.Data);
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
}
