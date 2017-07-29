using OrangeBricks.Web.Controllers.Base;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class ListPropertyCommandHandler : CommandHandler<ListPropertyCommand>
    {
        public ListPropertyCommandHandler(IOrangeBricksContext context) : base(context)
        { }

        public override void Handle(ListPropertyCommand command)
        {
            var property = this.context.Properties.Find(command.PropertyId);
            property.IsListedForSale = true;
            this.context.SaveChanges();
        }
    }
}