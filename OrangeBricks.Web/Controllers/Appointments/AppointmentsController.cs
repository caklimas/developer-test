using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.Offers.Builders;
using OrangeBricks.Web.Controllers.Offers.Commands;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Controllers.Property.Builders;
using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.Infrastructure;
using OrangeBricks.Web.Controllers.Appointments.ViewModels;
using OrangeBricks.Web.Controllers.Appointments.Builders;
using System;

namespace OrangeBricks.Web.Controllers.Offers
{
    public class AppointmentsController : Controller
    {
        private readonly IOrangeBricksContext context;

        public AppointmentsController(IOrangeBricksContext context)
        {
            this.context = context;
        }
        
        [OrangeBricksAuthorize(Roles = RoleConstants.Seller)]
        public ActionResult OnProperty(int id)
        {
            var builder = new AppointmentsOnPropertyViewModelBuilder(context);
            var viewModel = builder.Build(id);

            return View(viewModel);
        }
    }
}