using Grand.Core.Domain.Customers;
using Grand.Core.Domain.Vendors;
using MediatR;

namespace Grand.Web.Commands.Models.Vendors
{
    public class SetVendorReviewHelpfulnessCommand : IRequest<VendorReview>
    {
        public Customer Customer { get; set; }
        public Vendor Vendor { get; set; }
        public VendorReview Review { get; set; }
        public bool Washelpful { get; set; }
    }
}
