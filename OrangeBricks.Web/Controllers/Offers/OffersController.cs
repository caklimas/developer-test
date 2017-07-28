using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.Offers.Builders;
using OrangeBricks.Web.Controllers.Offers.Commands;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Controllers.Property.Builders;
using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.Infrastructure;

namespace OrangeBricks.Web.Controllers.Offers
{
    public class OffersController : Controller
    {
        private readonly IOrangeBricksContext _context;

        public OffersController(IOrangeBricksContext context)
        {
            _context = context;
        }
        
        [OrangeBricksAuthorize(Roles = RoleConstants.Seller)]
        public ActionResult OnProperty(int id)
        {
            var builder = new OffersOnPropertyViewModelBuilder(_context);
            var viewModel = builder.Build(id);

            return View(viewModel);
        }

        [OrangeBricksAuthorize(Roles = RoleConstants.Buyer)]
        public ActionResult MyOffers()
        {
            var builder = new MyOffersViewModelBuilder(_context);
            var viewModel = builder.Build(User.Identity.GetUserId());

            return View(viewModel);
        }

        [HttpPost]
        [OrangeBricksAuthorize(Roles = RoleConstants.Seller)]
        public ActionResult Accept(AcceptOfferCommand command)
        {
            var handler = new AcceptOfferCommandHandler(_context);

            handler.Handle(command);

            return RedirectToAction("OnProperty", new { id = command.PropertyId });
        }

        [HttpPost]
        [OrangeBricksAuthorize(Roles = RoleConstants.Seller)]
        public ActionResult Reject(RejectOfferCommand command)
        {
            var handler = new RejectOfferCommandHandler(_context);

            handler.Handle(command);

            return RedirectToAction("OnProperty", new { id = command.PropertyId });
        }
    }
}