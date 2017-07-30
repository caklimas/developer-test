using OrangeBricks.Web.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrangeBricks.Web.Controllers.Offers.ViewModels;
using System.Web.Mvc;
using OrangeBricks.Web.Controllers.Base;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    /// <summary>
    /// Provides functionality to build an instance of <see cref="MyOffersViewModel"/>
    /// </summary>
    public class MyOffersViewModelBuilder : ViewModelBuilder
    {
        public MyOffersViewModelBuilder(IOrangeBricksContext context)
            : base(context)
        { }

        /// <summary>
        /// Builds an instance of <see cref="MyOffersViewModel"/>
        /// </summary>
        /// <param name="buyerId">The user id of the buyer making the offer.</param>
        /// <returns>An instance of <see cref="MyOffersViewModel"/></returns>
        public MyOffersViewModel Build(string buyerId)
        {
            return new MyOffersViewModel
            {
                Offers = this.context.Offers
                    .Where(o => o.BuyerUserId == buyerId)
                    .Include(o => o.Property)
                    .Select(o => new MyOfferViewModel
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