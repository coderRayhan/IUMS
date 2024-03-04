using AspNetCoreHero.Boilerplate.Infrastructure.Identity.Models;
using IUMS.Application.Constants;
using IUMS.Application.Features;
using IUMS.Application.Features.Student.StudentBasicInfos.Commands;
using IUMS.Infrastructure.Extensions;
using IUMS.Web.Abstractions;
using IUMS.Web.Areas.Student.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
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

    public IActionResult Index()
    {
        var model = new StudentBasicInfoViewModel();

        model.StudentEducationalInfos.Add(new StudentEducationalInfoViewModel());
        model.DateOfAdmission = DateTime.Now;
        model.DateOfBirth = new DateTime();
        return View(model);
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
}
