using System.Linq;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Controllers.Base;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class MyPropertiesViewModelBuilder : ViewModelBuilder
    {
        public MyPropertiesViewModelBuilder(IOrangeBricksContext context)
            : base(context)
        { }

        public MyPropertiesViewModel Build(string sellerId)
        {
            return new MyPropertiesViewModel
            {
                Properties = context.Properties
                    .Where(p => p.SellerUserId == sellerId)
                    .Select(p => new PropertyViewModel
                    {
                        Id = p.Id,
                        StreetName = p.StreetName,
                        Description = p.Description,
                        NumberOfBedrooms = p.NumberOfBedrooms,
                        PropertyType = p.PropertyType,
                        IsListedForSale = p.IsListedForSale
                    })
                    .ToList()
            };
        }
    }
}