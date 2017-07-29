using System;
using System.Collections.Generic;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Controllers.Base;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class MakeOfferCommandHandler : CommandHandler<MakeOfferCommand>
    {
        public MakeOfferCommandHandler(IOrangeBricksContext context) : base(context)
        { }

        public override void Handle(MakeOfferCommand command)
        {
            var offer = new Offer
            {
                BuyerUserId = command.BuyerUserId,
                Amount = command.Offer,
                Status = OfferStatus.Pending,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var property = this.context.Properties.Find(command.PropertyId);
            if (property.Offers == null)
            {
                property.Offers = new List<Offer>();
            }
                
            property.Offers.Add(offer);
            
            this.context.SaveChanges();
        }
    }
}