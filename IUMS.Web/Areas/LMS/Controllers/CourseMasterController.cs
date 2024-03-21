using AspNetCoreHero.Boilerplate.Infrastructure.Identity.Models;
using IUMS.Application.Constants;
using IUMS.Application.Features.LMS.CourseChapters.Queries;
using IUMS.Application.Features.LMS.CourseMasters.Commands;
using IUMS.Application.Features.LMS.CourseMasters.Queries;
using IUMS.Infrastructure.Extensions;
using IUMS.Web.Abstractions;
using IUMS.Web.Areas.Academic.Models;
using IUMS.Web.Areas.LMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IUMS.Web.Areas.LMS.Controllers;
[Area("LMS")]
public class CourseMasterController : BaseController<CourseMasterController>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public CourseMasterController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    public IActionResult Index()
    {
        var user = User.Identity.Name;
        CourseMasterViewModel model = new()
        {
            TeacherId = (int)_userManager.FindByNameAsync(user).Result.EmpId
        };
        return View(model);
    }

    public async Task<IActionResult> LoadAll()
    {
        var uName = User.Identity.Name;
        var response = await _mediator.Send(new LMSCourseListByTeacherIdQuery((int)_userManager.FindByNameAsync(uName).Result.EmpId));
        if (response.Succeeded)
        {
            var viewModel = _mapper.Map<List<CourseMasterViewModel>>(response.Data);
            return PartialView("_LoadAll", viewModel);
        }
        return null;
    }

    public async Task<IActionResult> CreateOrEdit(int id = 0)
    {
        CourseMasterViewModel model = new();
        var uName = User.Identity.Name;
        model.TeacherId = (int)_userManager.FindByNameAsync(uName).Result.EmpId;
        if (id == 0)
        {
            model.CourseChapters = new List<CourseChapterViewModel>()
                {
                    new CourseChapterViewModel()
                };
            model.CourseOutcomes = new List<CourseOutcomeViewModel>()
                {
                    new CourseOutcomeViewModel()
                };
            model.CourseFAQs = new List<CourseFAQViewModel>()
                {
                    new CourseFAQViewModel()
                };
            await Task.Delay(0);
            return View(model);
        }
        else
        {
            var courseMasterData = await _mediator.Send(new CourseMasterByIdQuery(id));
            if (courseMasterData.Succeeded)
            {
                var courseData = await _mediator.Send(new CourseDetailsByIdQuery(courseMasterData.Data.CourseAssignId));
                model = _mapper.Map<CourseMasterViewModel>(courseMasterData.Data);
                model.CourseName = courseData.Data.CourseName;
                model.SessionName = courseData.Data.SessionName;
                model.SessionNameBN = courseData.Data.SessionNameBN;
                model.FacultyName = courseData.Data.FacultyName;
                model.FacultyNameBN = courseData.Data.FacultyNameBN;
                model.DepartmentName = courseData.Data.DepartmentName;
                model.DepartmentNameBN = courseData.Data.DepartmentNameBN;
                model.ProgramName = courseData.Data.ProgramName;
                model.ProgramNameBN = courseData.Data.ProgramNameBN;
                model.CourseCode = courseData.Data.CourseCode;
                model.CreditHour = courseData.Data.CreditHour;
                model.ConductHour = courseData.Data.ConductHour;
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_EditCourse", model) });
            }
            return null;
        }
    }

    [HttpPost]
    public async Task<IActionResult> OnPostCreateOrEdit(CourseMasterViewModel Model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (Model.Id == 0)
                {
                    var mapped = _mapper.Map<CreateCourseMasterCommand>(Model);
                    var response = await _mediator.Send(mapped);
                    if (response.Succeeded)
                    {
                        _notify.Success(_localizer[LocalizerConstant.SAVED]);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _notify.Error(_localizer[response.Message]);
                        return View("CreateOrEdit", Model);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(Model.VideoUrl) && Model.Video is not null)
                    {
                        Model.VideoUrl = await UtilityExtensions.SaveFileAsync(
                                                Model.Video,
                                                FolderPathConstant.LMS_DOCS,
                                                string.Concat("video_", Model.CourseCode),
                                                Model.VideoUrl) ?? Model.VideoUrl;

                        if (Model.Thumbnail is not null)
                            Model.ThumbnailUrl = await UtilityExtensions.SaveFileAsync(
                                                Model.Thumbnail,
                                                FolderPathConstant.LMS_DOCS,
                                                string.Concat("thumb_", Model.CourseCode),
                                                Model.ThumbnailUrl) ?? Model.ThumbnailUrl;



                    }
                    var updateData = _mapper.Map<UpdateCourseMasterCommand>(Model);
                    var response = await _mediator.Send(updateData);
                    if (response.Succeeded)
                    {
                        _notify.Success(_localizer[LocalizerConstant.UPDATE_MSG]);
                        var res = await _mediator.Send(new CourseChapterListByCourseAssignIdQuery(Model.CourseAssignId));
                        if (res.Succeeded)
                        {
                            var viewModel = _mapper.Map<List<ChapterClassViewModel>>(res.Data);
                            return RedirectToAction("Index");
                            //return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_LoadAll", viewModel) });
                        }
                        return new JsonResult(new { isValid = false });
                    }
                    else
                    {
                        _notify.Error(response.Message);
                        return new JsonResult(new { isValid = false });
                    }
                }
            }
            else
            {
                _notify.Error(ModelState.GetModelStateError());
                return View("CreateOrEdit", Model);
            }
        }
        catch (Exception ex)
        {
            _notify.Error(ex.Message);
            return View("CreateOrEdit", Model);
        }
    }

    // UPLOAD FILES

    public async Task<IActionResult> UploadFiles(int id = 0)
    {
        CourseMasterViewModel model = new();
        var uName = User.Identity.Name;
        model.TeacherId = (int)_userManager.FindByNameAsync(uName).Result.EmpId;

        var courseMasterData = await _mediator.Send(new CourseMasterByIdQuery(id));
        if (courseMasterData.Succeeded)
        {
            var courseData = await _mediator.Send(new CourseDetailsByIdQuery(courseMasterData.Data.CourseAssignId));
            model = _mapper.Map<CourseMasterViewModel>(courseMasterData.Data);
            model.CourseName = courseData.Data.CourseName;
            model.SessionName = courseData.Data.SessionName;
            model.SessionNameBN = courseData.Data.SessionNameBN;
            model.FacultyName = courseData.Data.FacultyName;
            model.FacultyNameBN = courseData.Data.FacultyNameBN;
            model.DepartmentName = courseData.Data.DepartmentName;
            model.DepartmentNameBN = courseData.Data.DepartmentNameBN;
            model.ProgramName = courseData.Data.ProgramName;
            model.ProgramNameBN = courseData.Data.ProgramNameBN;
            model.CourseCode = courseData.Data.CourseCode;
            model.CreditHour = courseData.Data.CreditHour;
            model.ConductHour = courseData.Data.ConductHour;
            model.ThumbnailUrl = courseMasterData.Data.ThumbnailUrl;
            model.VideoUrl = courseMasterData.Data.VideoUrl;
            return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_UploadFiles", model) });
        }
        return null;
    }

    [HttpPost]
    public async Task<IActionResult> PostUploadFiles(CourseMasterViewModel Model)
    {
        try
        {
            if (Model.Video is not null)
                Model.VideoUrl = await UtilityExtensions.SaveFileAsync(
                                        Model.Video,
                                        FolderPathConstant.LMS_DOCS,
                                        string.Concat("video_", Model.CourseCode),
                                        Model.VideoUrl) ?? Model.VideoUrl;

            if (Model.Thumbnail is not null)
                Model.ThumbnailUrl = await UtilityExtensions.SaveFileAsync(
                                    Model.Thumbnail,
                                    FolderPathConstant.LMS_DOCS,
                                    string.Concat("thumb_", Model.CourseCode),
                                    Model.ThumbnailUrl) ?? Model.ThumbnailUrl;

            var response = await _mediator.Send(
                                    new UpdateCourseMasterFileCommand
                                    {
                                        Id = Model.Id,
                                        ThumbnailUrl = Model.ThumbnailUrl,
                                        VideoUrl = Model.VideoUrl
                                    });
            if (response.Succeeded)
            {
                _notify.Success(_localizer[LocalizerConstant.UPDATE_MSG]);
                var res = await _mediator.Send(new CourseChapterListByCourseAssignIdQuery(Model.CourseAssignId));
                if (res.Succeeded)
                {
                    var viewModel = _mapper.Map<List<ChapterClassViewModel>>(res.Data);
                    return RedirectToAction("Index");
                }
                return new JsonResult(new { isValid = false });
            }
            else
            {
                _notify.Error(response.Message);
                return new JsonResult(new { isValid = false });
            }
        }
        catch (Exception ex)
        {
            _notify.Error(ex.Message);
            return new JsonResult(new { isValid = false });
        }
    }

    public async Task<CourseViewModel> GetCourseData(int id)
    {
        var response = await _mediator.Send(new CourseDetailsByIdQuery(id));
        if (response.Succeeded)
        {
            var courseData = _mapper.Map<CourseViewModel>(response.Data);
            return courseData;
        }
        return null;
    }

    public async Task<IActionResult> CourseDetail(int Id)
    {
        var response = await _mediator.Send(new CourseDetailsByIdQuery(Id));
        return View(response.Data);
    }
}
