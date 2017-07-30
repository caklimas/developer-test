using System;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Controllers.Base;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class PropertiesViewModelBuilder : ViewModelBuilder
    {
        public PropertiesViewModelBuilder(IOrangeBricksContext context) 
            : base(context)
        { }

        public PropertiesViewModel Build(PropertiesQuery query)
        {
            // The list of properties shown should NOT include properties that have an offer that was already accepted.
            var properties = context.Properties
                .Include(p => p.Offers)
                .Where(p => p.IsListedForSale)
                .Where(p => !p.Offers.Any(o => o.Status == OfferStatus.Accepted));

            if (!string.IsNullOrWhiteSpace(query.Search))
            {
                properties = properties.Where(x => x.StreetName.Contains(query.Search) 
                    || x.Description.Contains(query.Search));
            }
            
            return new PropertiesViewModel
            {
                Properties = properties
                    .ToList()
                    .Select(MapViewModel)
                    .ToList(),
                Search = query.Search
            };
        }

        private static PropertyViewModel MapViewModel(Models.Property property)
        {
            return new PropertyViewModel
            {
                Id = property.Id,
                StreetName = property.StreetName,
                Description = property.Description,
                NumberOfBedrooms = property.NumberOfBedrooms,
                PropertyType = property.PropertyType
            };
        }
    }
}