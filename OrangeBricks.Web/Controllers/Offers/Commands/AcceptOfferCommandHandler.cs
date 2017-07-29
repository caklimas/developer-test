using System;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Controllers.Base;

namespace OrangeBricks.Web.Controllers.Offers.Commands
{
    public class AcceptOfferCommandHandler : CommandHandler<AcceptOfferCommand>
    {
        public AcceptOfferCommandHandler(IOrangeBricksContext context) : base(context)
        { }

        public override void Handle(AcceptOfferCommand command)
        {
            var offer = this.context.Offers.Find(command.OfferId);

            offer.UpdatedAt = DateTime.Now;
            offer.Status = OfferStatus.Accepted;

            this.context.SaveChanges();
        }
    }
}