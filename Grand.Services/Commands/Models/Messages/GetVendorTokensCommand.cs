using Grand.Core.Domain.Localization;
using Grand.Core.Domain.Vendors;
using Grand.Services.Messages.DotLiquidDrops;
using MediatR;

namespace Grand.Services.Commands.Models.Messages
{
    public class GetVendorTokensCommand : IRequest<LiquidVendor>
    {
        public Vendor Vendor { get; set; }
        public Language Language { get; set; }
    }
}
