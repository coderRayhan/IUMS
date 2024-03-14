using IUMS.Application.Constants;
using IUMS.Application.Features.Employees.Commands;
using IUMS.Application.Features.Employees.Queries;
using IUMS.Infrastructure.Extensions;
using IUMS.Web.Abstractions;
using IUMS.Web.Areas.Employees.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IUMS.Web.Areas.Employees.Controllers;
[Area("Employees")]
public class EmployeeController : BaseController<EmployeeController>
{
    public async Task<IActionResult> Index(int id)
    {
        EmployeeViewModel model = new();
        if (id != 0)
        {
            var response = await _mediator.Send(new EmployeeByIdQuery(id));
            if (response.Succeeded)
            {
                model = _mapper.Map<EmployeeViewModel>(response.Data);
            }
            else
            {
                _notify.Error(response.Message);
            }
        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> OnPostCreateOrEdit(int id, EmployeeViewModel model)
    {
        if (!ModelState.IsValid)
        {
            _notify.Error(ModelState.GetModelStateError());
            return View("Index", model);
        }
        if (id == 0)
        {
            var mappedEntity = _mapper.Map<CreateEmployeeCommand>(model);

            var response = await _mediator.Send(mappedEntity);

            if (!response.Succeeded)
            {
                _notify.Error(response.Message);
                return View("Index", model);
            }
            _notify.Success(_localizer[LocalizerConstant.SAVED]);
            return RedirectToAction("Index");
        }
        else
        {
            var mappedEntity = _mapper.Map<UpdateEmployeeCommand>(model);

            var response = await _mediator.Send(mappedEntity);

            if (!response.Succeeded)
            {
                _notify.Error(response.Message);
                return View("Index", model);
            }
            _notify.Success(_localizer[LocalizerConstant.UPDATE]);
            return RedirectToAction("Index");
        }
    }

    public IActionResult EmployeeList()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> LoadAll(
        int facultyId,
        int departmentId,
        int genderId)
    {
        var response = await _mediator.Send(new EmployeeListQuery(facultyId, departmentId, genderId));
        if (!response.Succeeded)
        {
            _notify.Error(response.Message);
            return null;
        }
        var list = _mapper.Map<List<EmployeeViewModel>>(response.Data);
        return PartialView("_ViewAll", list);
    }

    [HttpPost]
    public async Task<IActionResult> OnPostDelete(int id)
    {
        var response = await _mediator.Send(new DeleteEmployeeCommand(id));
        if (!response.Succeeded)
        {
            _notify.Error(response.Message);
            return new JsonResult(new { isValid = false });
        }
        _notify.Success(_localizer[LocalizerConstant.DELETE_MSG]);

        var result = await _mediator.Send(new EmployeeListQuery(0, 0, 0));
        if (!result.Succeeded)
        {
            _notify.Error(response.Message);
            return new JsonResult(new { isValid = false });
        }
        var list = _mapper.Map<List<EmployeeViewModel>>(result.Data);
        return new JsonResult(new { isValid = true, html = _viewRenderer.RenderViewToStringAsync("_ViewAll", list) });
    }

    [HttpPost]
    public async Task<IActionResult> UpdateStatus(int id)
    {
        var response = await _mediator.Send(new UpdateEmployeeStatusCommand(id));
        if (!response.Succeeded)
            _notify.Error(response.Message);
        else
            _notify.Information("Status updated");
        return RedirectToAction("EmployeeList");
    }
}
