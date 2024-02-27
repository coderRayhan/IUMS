using IUMS.Application.Constants;
using IUMS.Application.Features.Academic;
using IUMS.Web.Abstractions;
using IUMS.Web.Areas.Academic.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IUMS.Web.Areas.Academic.Controllers
{
    [Area("Academic")]
    public class SessionController : BaseController<SessionController>
    {
        ////[Authorize(Policy = Permissions.Sessions.View)]
        public IActionResult Index(int id)
        {
            //var user = User.Identity.Name;
            //var response = await _mediator.Send(new GetPageTileUrlQuery() { UserId = user, Id = id });
            //if (response.Succeeded && response.Data is not null)
            //{
            //    GetTitleResponse menuResponse = new() { MenuId = response.Data.MenuId, MenuName = response.Data.MenuName, MenuNameBN = response.Data.MenuNameBN, MenuUrl = response.Data.MenuUrl };
            //    HttpContext.Session.SetString("Menu", JsonConvert.SerializeObject(menuResponse));
            //    SessionViewModel viewModel = new();
            //    return View(viewModel);
            //}
            //else
            //{
            //    return LocalRedirect("~/Identity/Account/AccessDenied");
            //}
            return View();
        }

        //  //[Authorize(Policy = Permissions.Sessions.View)]
        public async Task<IActionResult> LoadAll()
        {
            var response = await _mediator.Send(new GetAllSessionQuery());
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<SessionViewModel>>(response.Data);
                return PartialView("_ViewAll", viewModel);
            }
            return null;
        }

        ////[Authorize(Policy = Permissions.Sessions.View)]
        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                var sessionViewModel = new SessionViewModel();
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", sessionViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetSessionByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var sessionViewModel = _mapper.Map<SessionViewModel>(response.Data);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", sessionViewModel) });
                }
                return new JsonResult(new { isValid = false });
            }
        }

        //[Authorize(Policy = Permissions.Sessions.View)]
        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, SessionViewModel session)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    session.StartDate = Convert.ToDateTime(session.SessionStartDate);
                    session.EndDate = Convert.ToDateTime(session.SessionEndDate);
                    if (session.StartDate > session.EndDate)
                    {
                        _notify.Error("End date must be greater than start date!");
                        return new JsonResult(new { isValid = false });
                    }

                    if (id == 0)
                    {

                        var createSessionCommand = _mapper.Map<CreateSessionCommand>(session);
                        var result = await _mediator.Send(createSessionCommand);
                        if (result.Succeeded)
                        {
                            id = result.Data;
                            _notify.Success(_localizer[LocalizerConstant.SAVED]);
                            //return new JsonResult(new { isValid = true });
                        }
                        else { 
                            _notify.Error(_localizer[result.Message]);
                            return new JsonResult(new { isValid = false });
                        }
                    }
                    else
                    {
                        var updateSessionCommand = _mapper.Map<UpdateSessionCommand>(session);
                        var result = await _mediator.Send(updateSessionCommand);
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
                    var response = await _mediator.Send(new GetAllSessionQuery());
                    if (response.Succeeded)
                    {
                        var viewModel = _mapper.Map<List<SessionViewModel>>(response.Data);
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
                    var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", session);
                    return new JsonResult(new { isValid = false, html = html });
                }
            }
            catch (Exception ex)
            {
                _notify.Error(_localizer[ex.Message]);
                var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", session);
                return new JsonResult(new { isValid = false, html = html });
            }
            
        }

        //[Authorize(Policy = Permissions.Sessions.Delete)]
        [HttpPost]
        public async Task<JsonResult> OnPostDelete(int id)
        {
            var deleteCommand = await _mediator.Send(new DeleteSessionCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Success(_localizer[deleteCommand.Message]);
                var response = await _mediator.Send(new GetAllSessionQuery());
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<SessionViewModel>>(response.Data);
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
        [HttpPost]
        public async Task<JsonResult> OnPostSessionStatus(int id)
        {
            try
            {
                var deleteCommand = await _mediator.Send(new SessionStatusUpdateCommand { Id = id });
                if (deleteCommand.Succeeded)
                {
                    _notify.Success(_localizer[deleteCommand.Message]);
                    var response = await _mediator.Send(new GetAllSessionQuery());
                    if (response.Succeeded)
                    {
                        var viewModel = _mapper.Map<List<SessionViewModel>>(response.Data);
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
            catch (Exception ex)
            {

                _notify.Error(ex.Message);
                return new JsonResult(new { isValid = false });
            }
        }
    }
}
