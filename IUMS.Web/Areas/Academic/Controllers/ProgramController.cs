using IUMS.Application.Constants;
using IUMS.Application.Features;
using IUMS.Application.Features.Academic.Program.Queries;
using IUMS.Application.Features.Academic.Program.Queries.GetAll;
using IUMS.Application.Features.Common.Queries;
using IUMS.Infrastructure.Extensions;
using IUMS.Web.Abstractions;
using IUMS.Web.Areas.Academic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IUMS.Web.Areas.Academic.Controllers
{
    [Area("Academic")]
    public class ProgramController : BaseController<ProgramController>
    {

        public async Task<IActionResult> Index(int id)
        {
            return View();
        }
        
        public async Task<IActionResult> LoadAll()
        {
            var response = await _mediator.Send(new GetAllProgramQuery());
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<ProgramViewModel>>(response.Data);
                return PartialView("_ViewAll", viewModel);
            }
            return null;
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                var programViewModel = new ProgramViewModel();
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", programViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetProgramByIdQuery(id) );
                if (response.Succeeded)
                {
                    var programViewModel = _mapper.Map<ProgramViewModel>(response.Data);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", programViewModel) });
                }
                return null;
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, ProgramViewModel program)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    var createProgramCommand = _mapper.Map<CreateProgramCommand>(program);
                    var result = await _mediator.Send(createProgramCommand);
                    if (result.Succeeded)
                    {
                        id = result.Data;
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
                    var updateProgramCommand = _mapper.Map<UpdateProgramCommand>(program);
                    var result = await _mediator.Send(updateProgramCommand);
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
                var response = await _mediator.Send(new GetAllProgramQuery());
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<ProgramViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                {
                    _notify.Error(response.Message);
                    return new JsonResult(new { isValid = false });
                }
            }
            else
            {
                _notify.Error(ModelState.GetModelStateError());
                var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", program);
                return new JsonResult(new { isValid = false, html = html });
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostDelete(int id)
        {
            var deleteCommand = await _mediator.Send(new DeleteProgramCommand(id));
            if (deleteCommand.Succeeded)
            {
                _notify.Information(_localizer[LocalizerConstant.DELETE]);
                var response = await _mediator.Send(new GetAllProgramQuery());
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<ProgramViewModel>>(response.Data);
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

        public async Task<List<ProgramViewModel>> FilterProgtByDept(int departmentId)
        {
            var response = await _mediator.Send(new FilterProgtByDeptQuery(departmentId));

            if (response.Succeeded)
            {
                var List = _mapper.Map<List<ProgramViewModel>>(response.Data);
                return List;
            }
            _notify.Error(_localizer[LocalizerConstant.NO_DATA_FOUND]);
            return null;
        }

        //public async Task<List<ProgramViewModel>> FilterProgramByRef(int referenceId)
        //{
        //    var response = await _mediator.Send(new GetAllProgramByRefQuery() { admissionId = referenceId });

        //    if (response.Succeeded)
        //    {
        //        var List = _mapper.Map<List<ProgramViewModel>>(response.Data);
        //        return List;
        //    }
        //    _notify.Error(_localizer[LocalizerConstant.NO_DATA_FOUND]);
        //    return null;
        //}
        //public async Task<List<GetProgramFromScriptAllocationByEmpIdResponse>> FilterProgtByDeptWithEmpId(int DepartmentId, int EmpId)
        //{
        //    var response = await _mediator.Send(new GetProgramFromTeacherRoleAssignByEmpIdQuery(DepartmentId, EmpId));

        //    if (response.Succeeded)
        //    {
        //        var List = _mapper.Map<List<GetProgramFromScriptAllocationByEmpIdResponse>>(response.Data);
        //        return List;
        //    }
        //    _notify.Error(_localizer[LocalizerConstant.NO_DATA_FOUND]);
        //    return null;
        //}

        public async Task<IEnumerable<CommonDropdownResponse>> GetDepartmentsByFaculty(int facultyId)
        {
            object[] parameterList = new object[] { facultyId };
            var list = await _mediator.Send(new CommonDropdownQuery(CommonDropdownConstants.GET_ALL_DEPARTMENTS, parameterList));
            return list.Data;
        }
    }
}
