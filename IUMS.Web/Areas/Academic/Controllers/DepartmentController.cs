using IUMS.Application.Constants;
using IUMS.Application.Features;
using IUMS.Web.Abstractions;
using IUMS.Web.Areas.Academic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UEMS.Application.Features.Academic.Department.Queries;
using UEMS.Application.Features.Academic.Department.Queries.GetAll;

namespace UEMS.Web.Areas.Academic.Controllers
{
    [Area("Academic")]
    public class DepartmentController : BaseController<DepartmentController>
    {
        //[Authorize(Policy = Permissions.Departments.View)]
        public IActionResult Index(int id)
        {
            return View();
        }   
        //[Authorize(Policy = Permissions.Departments.View)]
        public async Task<IActionResult> LoadAll()
        {
            var response = await _mediator.Send(new GetAllDepartmentQuery());
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<DepartmentViewModel>>(response.Data);
                return PartialView("_ViewAll", viewModel);
            }
            return null;
        }

        //[Authorize(Policy = Permissions.Departments.View)]
        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                var departmentViewModel = new DepartmentViewModel();
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", departmentViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetDepartmentByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var departmentViewModel = _mapper.Map<DepartmentViewModel>(response.Data);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", departmentViewModel) });
                }
                return new JsonResult(new { isValid = false });
            }
        }
        //[Authorize(Policy = Permissions.Departments.View)]
        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, DepartmentViewModel department)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    var createDepartmentCommand = _mapper.Map<CreateDepartmentCommand>(department);
                    var result = await _mediator.Send(createDepartmentCommand);
                    if (result.Succeeded)
                    {
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
                    var updateDepartmentCommand = _mapper.Map<UpdateDepartmentCommand>(department);
                    var result = await _mediator.Send(updateDepartmentCommand);
                    if (result.Succeeded) _notify.Information(_localizer[LocalizerConstant.UPDATE_MSG]);
                    else 
                    {
                        _notify.Error(_localizer[result.Message]);
                        return new JsonResult(new { isValid = false });
                    }
                    
                }
                var response = await _mediator.Send(new GetAllDepartmentQuery());
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<DepartmentViewModel>>(response.Data);
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


                var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", department);
                return new JsonResult(new { isValid = false, html = html });
            }
        }

        //[Authorize(Policy = Permissions.Departments.Delete)]
        [HttpPost]
        public async Task<JsonResult> OnPostDelete(int id)
        {
            var deleteCommand = await _mediator.Send(new DeleteDepartmentCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
               
                var response = await _mediator.Send(new GetAllDepartmentQuery());
                if (response.Succeeded)
                {
                    _notify.Information(_localizer[LocalizerConstant.DELETE]);
                    var viewModel = _mapper.Map<List<DepartmentViewModel>>(response.Data);
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

        //public async Task<List<DepartmentViewModel>> FilterDeptByFaculty(int FacultyId)
        //{
        //    var response = await _mediator.Send(new GetDeptByFacultyQuery(FacultyId));

        //    if (response.Succeeded)
        //    {
        //        var deptList = _mapper.Map<List<DepartmentViewModel>>(response.Data);
        //        return deptList;
        //    }
        //    _notify.Error(_localizer[LocalizerConstant.NO_DATA_FOUND]);
        //    return null;
        //}

    }
}
