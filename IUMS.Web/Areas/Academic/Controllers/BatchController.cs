using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using IUMS.Web.Abstractions;
using IUMS.Application.Features;
using IUMS.Web.Areas.Academic.Models;
using IUMS.Application.Constants;
using IUMS.Application.Features.Academic.Batch.Queries;

namespace IUMS.Web.Areas.Academic.Controllers
{
    [Area("Academic")]
    public class BatchController : BaseController<BatchController>
    {
        public IActionResult Index(int id)
        {
            return View();
        }
        public async Task<IActionResult> LoadAll(int FacultyId, int DepartmentId, int ProgramId)
        {
            var response = await _mediator.Send(new GetAllBatchQuery(FacultyId, DepartmentId, ProgramId));
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<BatchViewModel>>(response.Data);
                return PartialView("_ViewAll", viewModel);
            }
            return null;
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {

            if (id == 0)
            {
                var BatchViewModel = new BatchViewModel();
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", BatchViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetBatchByIdQuery(id));
                if (response.Succeeded)
                {
                    var BatchViewModel = _mapper.Map<BatchViewModel>(response.Data);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", BatchViewModel) });
                }
                return new JsonResult(new { isValid = false });
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int Id, BatchViewModel batch)
        {
            if (ModelState.IsValid)
            {
                if (Id == 0)
                {
                    var createbatchCommand = _mapper.Map<CreateBatchCommand>(batch);
                    var result = await _mediator.Send(createbatchCommand);
                    if (result.Succeeded)
                    {
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
                    var updateBatchCommand = _mapper.Map<UpdateBatchCommand>(batch);
                    var result = await _mediator.Send(updateBatchCommand);
                    if (result.Succeeded) _notify.Information(_localizer[LocalizerConstant.UPDATE]);
                    else
                    {
                        _notify.Error(_localizer[result.Message]);
                        return new JsonResult(new { isValid = false });
                    }
                }
                var response = await _mediator.Send(new GetAllBatchQuery(0, 0, 0));
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<BatchViewModel>>(response.Data);
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


                var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", batch);
                return new JsonResult(new { isValid = false, html = html });
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostDelete(int id)
        {
            var deleteCommand = await _mediator.Send(new DeleteBatchCommand(id));
            if (deleteCommand.Succeeded)
            {

                var response = await _mediator.Send(new GetAllBatchQuery(0, 0, 0));
                if (response.Succeeded)
                {
                    _notify.Information(_localizer[LocalizerConstant.DELETE]);
                    var viewModel = _mapper.Map<List<BatchViewModel>>(response.Data);
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


        public async Task<List<BatchViewModel>> GetOnlyBatchName()
        {
            var response = await _mediator.Send(new GetAllBatchQuery(0, 0, 0));
            if (response.Succeeded)
            {
                var batchtList = _mapper.Map<List<BatchViewModel>>(response.Data);
                return batchtList;
            }
            _notify.Error(_localizer[LocalizerConstant.NO_DATA_FOUND]);
            return null;
        }

        public async Task<IEnumerable<GetBatchByProgramResponse>> FilterBatchByProgramId(int sessionId, int programId)
        {
            var response = await _mediator.Send(new GetBatchByProgramQuery(sessionId, programId));
            if (response.Succeeded)
            {
                return response.Data;
            }
            _notify.Error(response.Message);
            return null;
        }
    }
}
