using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Infrastructure;
using OrangeBricks.Web.Controllers.Appointments.Builders;
using System;
using OrangeBricks.Web.Controllers.Appointments.Commands;

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

        [HttpPost]
        [OrangeBricksAuthorize(Roles = RoleConstants.Seller)]
        public ActionResult Accept(AcceptAppointmentCommand command)
        {
            var handler = new AcceptAppointmentCommandHandler(context);

            handler.Handle(command);

            return RedirectToAction("OnProperty", new { id = command.PropertyId });
        }

        [HttpPost]
        [OrangeBricksAuthorize(Roles = RoleConstants.Seller)]
        public ActionResult Reject(RejectAppointmentCommand command)
        {
            var handler = new RejectAppointmentCommandHandler(context);

            handler.Handle(command);

            return RedirectToAction("OnProperty", new { id = command.PropertyId });
        }
        
        public ActionResult MyAppointments()
        {
            var builder = new MyAppointmentsViewModelBuilder(this.context);
            var viewModel = builder.Build(User.Identity.GetUserId(), User.IsInRole(RoleConstants.Buyer));

            return View(viewModel);
        }
    }
}