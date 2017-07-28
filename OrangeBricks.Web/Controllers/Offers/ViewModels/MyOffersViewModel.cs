using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrangeBricks.Web.Controllers.Offers.ViewModels
{
    /// <summary>
    /// Represents a list of offers that a buyer made.
    /// </summary>
    public class MyOffersViewModel
    {
        /// <summary>
        /// The list of offers that a buyer made.
        /// </summary>
        public List<MyOfferViewModel> Offers { get; set; }
    }
}