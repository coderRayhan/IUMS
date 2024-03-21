using IUMS.Application.Constants;
using IUMS.Application.Features.LMS.CourseMasters.Queries;
using IUMS.Application.Features.LMS.CourseQuestions.Commands;
using IUMS.Application.Features.LMS.CourseQuestions.Queries;
using IUMS.Infrastructure.Extensions;
using IUMS.Web.Abstractions;
using IUMS.Web.Areas.LMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IUMS.Web.Areas.LMS.Controllers;
[Area("LMS")]
public class CourseQuestionController : BaseController<CourseQuestionController>
{
	public async Task<IActionResult> Index(int courseMasterId)
	{
		var response = await _mediator.Send(new CourseDetailsByCourseMasterIdQuery(courseMasterId));
		var model = _mapper.Map<CourseQuestionViewModel>(response.Data);
		return View(model);
	}

	public async Task<IActionResult> LoadAll(int courseMasterId)
	{
		var response = await _mediator.Send(new QuestionsByCourseMasterIdQuery(courseMasterId));
		if (response.Succeeded)
		{
			var model = _mapper.Map<List<CourseQuestionViewModel>>(response.Data);
			return PartialView("_ViewAll", model);
		}
		return null;
	}

	public async Task<IActionResult> OnGetCreateOrEdit(int id = 0, int courseMasterId = 0)
	{
		if (id == 0)
		{
			var response = await _mediator.Send(new CourseDetailsByCourseMasterIdQuery(courseMasterId));
			if (response.Succeeded)
			{
				var model = _mapper.Map<CourseQuestionViewModel>(response.Data);
				return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", model) });
			}
			else
			{
				var model = new CourseQuestionViewModel();
				return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", model) });
			}
		}
		else
		{
			var res = await _mediator.Send(new CourseQuestionByIdQuery(id));
			var mappedData = _mapper.Map<CourseQuestionViewModel>(res.Data);
			var data = await _mediator.Send(new CourseDetailsByCourseMasterIdQuery(res.Data.CourseMasterId));
			mappedData.SessionName = data.Data.SessionName;
			mappedData.SessionNameBN = data.Data.SessionNameBN;
			mappedData.FacultyName = data.Data.FacultyName;
			mappedData.FacultyNameBN = data.Data.FacultyNameBN;
			mappedData.DepartmentName = data.Data.DepartmentName;
			mappedData.DepartmentNameBN = data.Data.DepartmentNameBN;
			mappedData.ProgramName = data.Data.ProgramName;
			mappedData.ProgramNameBN = data.Data.ProgramNameBN;
			mappedData.BatchName = data.Data.BatchName;
			mappedData.BatchNameBN = data.Data.BatchNameBN;
			mappedData.SemesterName = data.Data.SemesterName;
			mappedData.SemesterNameBN = data.Data.SemesterNameBN;
			mappedData.CourseName = data.Data.CourseName;
			mappedData.CourseCode = data.Data.CourseCode;
			mappedData.ConductHour = data.Data.ConductHour;
			mappedData.CreditHour = data.Data.CreditHour;
			mappedData.PartName = data.Data.PartName;
			return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", mappedData) });
		}
	}

	[HttpPost]
	public async Task<IActionResult> OnPostCreateOrEdit(CourseQuestionViewModel Model)
	{
		try
		{
			if (ModelState.IsValid)
			{
				if (Model.Id == 0)
				{
					var mappedModel = _mapper.Map<CreateCourseQuestionCommand>(Model);
					var response = await _mediator.Send(mappedModel);
					if (response.Succeeded)
					{
						_notify.Success(_localizer[LocalizerConstant.SAVED]);
						var res = await _mediator.Send(new QuestionsByCourseMasterIdQuery(Model.CourseMasterId));
						if (res.Succeeded)
						{
							var model = _mapper.Map<List<CourseQuestionViewModel>>(res.Data);
							//return PartialView("_ViewAll", model);
							return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", model) });
						}
						return new JsonResult(new { isValid = true });
					}
					else
					{
						return new JsonResult(new { isValid = false });
					}
				}
				else
				{
					var mappedModel = _mapper.Map<UpdateCourseQuestionCommand>(Model);
					var response = await _mediator.Send(mappedModel);
					if (response.Succeeded)
					{
						_notify.Success(_localizer[LocalizerConstant.UPDATE_MSG]);
						return new JsonResult(new { isValid = true });
					}
					else
					{
						return new JsonResult(new { isValid = false });
					}
				}
			}
			else
			{
				_notify.Error(ModelState.GetModelStateError());
				return new JsonResult(new { isValid = false });
			}
		}
		catch (System.Exception)
		{

			throw;
		}
	}

	public List<CourseFromLMSCourseMasterResponse> GetCourseListFromCourseMaster(int admissionYearId, int facultyId, int departmentId, int programId, int semesterId)
	{
		try
		{
			var response = _mediator.Send(new FilteredCourseFromLMSCourseMasterQuery(admissionYearId, facultyId, departmentId, programId, semesterId));
			return response.Result.Data;
		}
		catch (System.Exception)
		{

			throw;
		}
	}

	public async Task<IActionResult> RenderQuestion(int questionType, int id = 0)
	{
		if (id == 0)
		{
			var model = new CourseQuestionViewModel();
			await Task.Delay(0);
			if (questionType == 1)
			{
				model.QuestionOptions = new List<QuestionOptionViewModel>() { new QuestionOptionViewModel() };
				return PartialView("_McqPart", model);
			}
			else if (questionType == 2)
			{
				return PartialView("_ShortQuestionPart", model);
			}
			else if (questionType == 3)
			{
				return PartialView("_FillInTheBlanks", model);
			}
			else if (questionType == 4)
			{
				model.QuestionOptions = new List<QuestionOptionViewModel>() { new QuestionOptionViewModel() { Option = "True" }, new QuestionOptionViewModel() { Option = "False" } };
				return PartialView("_TrueFalse", model);
			}
			else
			{

				return null;
			}
		}
		else
		{
			var res = await _mediator.Send(new CourseQuestionByIdQuery(id));
			var model = _mapper.Map<CourseQuestionViewModel>(res.Data);
			if (questionType == 1)
			{
				if (model.QuestionOptions.Count is 0)
					model.QuestionOptions = new List<QuestionOptionViewModel>() { new QuestionOptionViewModel() };
				return PartialView("_McqPart", model);
			}
			else if (questionType == 2)
			{
				return PartialView("_ShortQuestionPart", model);
			}
			else if (questionType == 3)
			{
				return PartialView("_FillInTheBlanks", model);
			}
			else if (questionType == 4)
			{
				if (model.QuestionOptions.Count is 0)
					model.QuestionOptions = new List<QuestionOptionViewModel>() { new QuestionOptionViewModel() { Option = "True" }, new QuestionOptionViewModel() { Option = "False" } };
				return PartialView("_TrueFalse", model);
			}
			else
			{

				return null;
			}
		}
	}
	public async Task<IActionResult> DeleteQuestionOption(int id)
	{
		var response = await _mediator.Send(new DeleteQuestionOptionCommand(id));
		if (response.Succeeded)
		{
			_notify.Success(_localizer[LocalizerConstant.DELETE_MSG]);
			return new JsonResult(new { isValid = true });
		}
		return new JsonResult(new { isValid = false });
	}

	public async Task<IActionResult> DeleteQuestion(int id)
	{
		var response = await _mediator.Send(new DeleteCourseQuestionCommand(id));
		if (response.Succeeded)
		{
			_notify.Success(_localizer[LocalizerConstant.DELETE_MSG]);
			return new JsonResult(new { isValid = true });
		}
		return new JsonResult(new { isValid = false });
	}
}
