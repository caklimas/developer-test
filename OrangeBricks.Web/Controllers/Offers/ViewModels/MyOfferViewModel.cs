using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Offers.ViewModels
{
    /// <summary>
    /// Represents an offer that was placed by a buyer.
    /// </summary>
    public class MyOfferViewModel
    {
        /// <summary>
        /// The property that the offer was placed on.
        /// </summary>
        public Models.Property Property { get; set; }

        /// <summary>
        /// The money amount that was offered.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// The status of the offer.
        /// </summary>
        public OfferStatus Status { get; set; }

        /// <summary>
        /// The date that the offer was created on.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The date that this offer was updated on.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}