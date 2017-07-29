using System;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Controllers.Base;

namespace OrangeBricks.Web.Controllers.Offers.Commands
{
    public class RejectOfferCommandHandler : CommandHandler<RejectOfferCommand>
    {
        public RejectOfferCommandHandler(IOrangeBricksContext context) : base(context)
        { }

        public override void Handle(RejectOfferCommand command)
        {
            var offer = this.context.Offers.Find(command.OfferId);

            offer.UpdatedAt = DateTime.Now;
            offer.Status = OfferStatus.Rejected;

            this.context.SaveChanges();
        }
    }
}