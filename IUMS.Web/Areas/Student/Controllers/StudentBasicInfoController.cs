using AspNetCoreHero.Boilerplate.Infrastructure.Identity.Models;
using IUMS.Application.Constants;
using IUMS.Application.Features;
using IUMS.Application.Features.Student.StudentBasicInfos.Commands;
using IUMS.Application.Features.Student.StudentBasicInfos.Queries;
using IUMS.Domain.Entities.Academic;
using IUMS.Infrastructure.Extensions;
using IUMS.Web.Abstractions;
using IUMS.Web.Areas.Student.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IUMS.Web.Areas.Student.Controllers;
[Area("Student")]
public class StudentBasicInfoController : BaseController<StudentBasicInfoController>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public StudentBasicInfoController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> Index(int id = 0)
    {
        if (id == 0)
        {
            var model = new StudentBasicInfoViewModel();

            model.StudentEducationalInfos.Add(new StudentEducationalInfoViewModel());
            model.DateOfAdmission = DateTime.Now;
            model.DateOfBirth = new DateTime();
            return View(model);
        }
        else
        {
            var response = await _mediator.Send(new StudentByIdQuery(id));
            if (!response.Succeeded)
            {
                _notify.Error(response.Message);
                return null;
            }
            var vModel = _mapper.Map<StudentBasicInfoViewModel>(response.Data);
            return View(vModel);
        }
    }

    [HttpPost]
    public async Task<IActionResult> OnPostCreateOrEdit([FromForm] StudentBasicInfoViewModel model)
    {
        if (ModelState.IsValid)
        {

            if (model.Id == 0)
            {
                //UploadFormFile(model);
                var mappedData = _mapper.Map<CreateStudentBasicInfoCommand>(model);
                var result = await _mediator.Send(mappedData);
                if (result.Succeeded)
                {
                    model.Id = result.Data;

                    ApplicationUser user = new();
                    if (result.Data > 0)
                    {
                        user.UserName = model.ClassRollNo;
                        user.Email = model.Email;
                        user.FullName = model.StudentName;
                        user.EmailConfirmed = true;
                        user.EmployeeType = Domain.Enums.EmployeeType.Student;
                        user.StudentId = model.Id;
                        user.IsActive = true;
                    }
                    string password = UtilityExtensions.GenerateRandomPassword(8);
                    await _userManager.CreateAsync(user, $"123Pa$$word!{password}");
                    await _userManager.AddToRoleAsync(user, "Student");

                    //await _emailGridSender.SendEmailAsync(model.Email, "Student login credential", $"Your username : {model.ClassRollNo} and Password : 123Pa$$word!{password}");
                    _notify.Success(_localizer[LocalizerConstant.SAVED]);
                    //return RedirectToAction("StudentList");
                    return RedirectToAction("Index");
                }
                else
                {
                    _notify.Error(_localizer[result.Message]);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                //UploadFormFile(model);
                var mappedData = _mapper.Map<UpdateStudentBasicInfoCommand>(model);
                var result = await _mediator.Send(mappedData);
                if (result.Succeeded)
                {

                    _notify.Information(_localizer[LocalizerConstant.UPDATE_MSG]);
                    return RedirectToAction("StudentList");
                }
                else
                {
                    _notify.Error(_localizer[result.Message]);
                    return View("Index", model);
                }
            }
        }
        else
        {
            _notify.Error(ModelState.GetModelStateError());
            return View("Index", model);
        }
    }

    [HttpGet]
    public IActionResult StudentList()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> LoadAll(
        int sessionId,
        int batchId,
        int semesterId)
    {
        var response = await _mediator.Send(new StudentListQuery(sessionId, batchId, semesterId));

        if (!response.Succeeded)
        {
            _notify.Error(response.Message);
            return null;
        }

        var studentList = _mapper.Map<List<StudentBasicInfoViewModel>>(response.Data);
        return PartialView("_ViewAll", studentList);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateStatus(int id)
    {
        var response = await _mediator.Send(new UpdateStudenStatusCommand(id));
        if (!response.Succeeded)
            _notify.Error(response.Message);
        else
            _notify.Information("Status updated");
        return RedirectToAction("StudentList");
    }
}
