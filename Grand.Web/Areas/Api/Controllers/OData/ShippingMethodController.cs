using Grand.Api.DTOs.Shipping;
using Grand.Api.Queries.Models.Common;
using Grand.Services.Security;
using MediatR;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Grand.Web.Areas.Api.Controllers.OData
{
    public partial class ShippingMethodController : BaseODataController
    {
        private readonly IMediator _mediator;
        private readonly IPermissionService _permissionService;

        public ShippingMethodController(IMediator mediator, IPermissionService permissionService)
        {
            _mediator = mediator;
            _permissionService = permissionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string key)
        {
            if (!await _permissionService.Authorize(PermissionSystemName.ShippingSettings))
                return Forbid();

            var shipping = await _mediator.Send(new GetQuery<ShippingMethodDto>() { Id = key });
            if (!shipping.Any())
                return NotFound();

            return Ok(shipping.FirstOrDefault());
        }

        [HttpGet]
        [EnableQuery(HandleNullPropagation = HandleNullPropagationOption.False)]
        public async Task<IActionResult> Get()
        {
            if (!await _permissionService.Authorize(PermissionSystemName.ShippingSettings))
                return Forbid();

            return Ok(await _mediator.Send(new GetQuery<ShippingMethodDto>()));
        }
    }
}
