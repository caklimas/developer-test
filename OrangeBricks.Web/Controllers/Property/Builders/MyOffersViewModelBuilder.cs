using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class MyOffersViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public MyOffersViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public MyOffersViewModel Build(string buyerId)
        {
            return new MyOffersViewModel
            {
                Offers = this._context.Offers
                    .Where(o => o.BuyerUserId == buyerId)
                    .Include(o => o.Property)
                    .Select(o => new OfferViewModel
                    {
                        Property = o.Property,
                        Amount = o.Amount,
                        Status = o.Status,
                        CreatedAt = o.CreatedAt,
                        UpdatedAt = o.UpdatedAt
                    })
                    .ToList()
            };
        }
    }
}