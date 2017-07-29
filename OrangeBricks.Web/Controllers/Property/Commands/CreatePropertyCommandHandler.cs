using OrangeBricks.Web.Controllers.Base;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class CreatePropertyCommandHandler : CommandHandler<CreatePropertyCommand>
    {
        public CreatePropertyCommandHandler(IOrangeBricksContext context) : base(context)
        { }

        public override void Handle(CreatePropertyCommand command)
        {
            var property = new Models.Property
            {
               PropertyType = command.PropertyType,
               StreetName = command.StreetName,
               Description = command.Description,
               NumberOfBedrooms = command.NumberOfBedrooms
            };

            property.SellerUserId = command.SellerUserId;

            this.context.Properties.Add(property);

            this.context.SaveChanges();
        }
    }
}