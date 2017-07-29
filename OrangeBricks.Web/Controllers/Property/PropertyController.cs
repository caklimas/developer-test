using System.Collections;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.Property.Builders;
using OrangeBricks.Web.Controllers.Property.Commands;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Infrastructure;
using System;

namespace OrangeBricks.Web.Controllers.Property
{
    public class PropertyController : Controller
    {
        private readonly IOrangeBricksContext _context;

        public PropertyController(IOrangeBricksContext context)
        {
            _context = context;
        }

        [Authorize]
        public ActionResult Index(PropertiesQuery query)
        {
            var builder = new PropertiesViewModelBuilder(_context);
            var viewModel = builder.Build(query);

            return View(viewModel);
        }

        [OrangeBricksAuthorize(Roles = RoleConstants.Seller)]
        public ActionResult Create()
        {
            var viewModel = new CreatePropertyViewModel();

            viewModel.PossiblePropertyTypes = new string[] { "House", "Flat", "Bungalow" }
                .Select(x => new SelectListItem { Value = x, Text = x })
                .AsEnumerable();

            return View(viewModel);
        }

        [OrangeBricksAuthorize(Roles = RoleConstants.Seller)]
        [HttpPost]
        public ActionResult Create(CreatePropertyCommand command)
        {
            var handler = new CreatePropertyCommandHandler(_context);

            command.SellerUserId = User.Identity.GetUserId();

            handler.Handle(command);

            return RedirectToAction("MyProperties");
        }

        [OrangeBricksAuthorize(Roles = RoleConstants.Seller)]
        public ActionResult MyProperties()
        {
            var builder = new MyPropertiesViewModelBuilder(_context);
            var viewModel = builder.Build(User.Identity.GetUserId());

            return View(viewModel);
        }

        [HttpPost]
        [OrangeBricksAuthorize(Roles = RoleConstants.Seller)]
        public ActionResult ListForSale(ListPropertyCommand command)
        {
            var handler = new ListPropertyCommandHandler(_context);

            handler.Handle(command);

            return RedirectToAction("MyProperties");
        }

        [OrangeBricksAuthorize(Roles = RoleConstants.Buyer)]
        public ActionResult MakeOffer(int id)
        {
            var builder = new MakeOfferViewModelBuilder(_context);
            var viewModel = builder.Build(id);
            return View(viewModel);
        }

        [HttpPost]
        [OrangeBricksAuthorize(Roles = RoleConstants.Buyer)]
        public ActionResult MakeOffer(MakeOfferCommand command)
        {
            var handler = new MakeOfferCommandHandler(_context);

            //Assign the BuyerUserId to the UserId of the currently logged in buyer.
            command.BuyerUserId = User.Identity.GetUserId();

            handler.Handle(command);

            return RedirectToAction("Index");
        }

        [OrangeBricksAuthorize(Roles = RoleConstants.Buyer)]
        public ActionResult MakeAppointment(int id)
        {
            var builder = new MakeAppointmentViewModelBuilder(_context);
            var viewModel = builder.Build(id);
            return View(viewModel);
        }

        [HttpPost]
        [OrangeBricksAuthorize(Roles = RoleConstants.Buyer)]
        public ActionResult MakeAppointment(MakeAppointmentCommand command)
        {
            var handler = new MakeAppointmentCommandHandler(this._context);

            handler.Handle(command);

            return RedirectToAction("Index");
        }
    }
}