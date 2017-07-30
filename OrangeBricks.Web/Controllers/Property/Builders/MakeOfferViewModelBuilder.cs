using OrangeBricks.Web.Controllers.Base;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class MakeOfferViewModelBuilder : ViewModelBuilder
    {
        public MakeOfferViewModelBuilder(IOrangeBricksContext context)
            : base(context)
        { }

        public MakeOfferViewModel Build(int id)
        {
            var property = context.Properties.Find(id);

            return new MakeOfferViewModel
            {
                PropertyId = property.Id,
                PropertyType = property.PropertyType,
                StreetName = property.StreetName,
                Offer = 100000 // TODO: property.SuggestedAskingPrice
            };
        }
    }
}