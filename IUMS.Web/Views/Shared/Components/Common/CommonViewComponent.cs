using AutoMapper;
using IUMS.Application.Features.Common.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUMS.Web.Views.Shared.Components.Common
{
    public class CommonViewComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CommonViewComponent(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync(string name, string id, int entityId, string query, object[] parameters = null, string classList = "", string labelText = "", string labelClass = "", string method = "false", bool isRequired = false, bool isLabelRequired = false)
        {
            ViewBag.Name = name;
            ViewBag.Id = id;
            ViewBag.EntityId = entityId;
            ViewBag.ClassList = classList;
            ViewBag.LabelText = labelText;
            ViewBag.LabelClass = labelClass;
            ViewBag.Method = method;
            ViewBag.IsRequired = isRequired;
            ViewBag.IsLabelRequired = isLabelRequired;
            return View(await GetList(query, parameters));
        }
        private async Task<IEnumerable<CommonDropdownResponse>>GetList(string query, object[] parameters)
        {
            var response = await _mediator.Send(new CommonDropdownQuery(query, parameters));
            if (response.Succeeded)
                return response.Data;
            return Enumerable.Empty<CommonDropdownResponse>().ToList();
        }
    }
}
