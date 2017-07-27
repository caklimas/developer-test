using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Property.Commands;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeBricks.Web.Tests.Controllers.Property.Commands
{
    [TestFixture]
    public class MakeOfferCommandHandlerTest
    {
        private MakeOfferCommandHandler handler;
        private IOrangeBricksContext context;
        private IDbSet<Offer> offers;

        [SetUp]
        public void SetUp()
        {
            this.context = Substitute.For<IOrangeBricksContext>();
            this.offers = Substitute.For<IDbSet<Offer>>();
            this.context.Offers.Returns(this.offers);
            this.handler = new MakeOfferCommandHandler(this.context);
        }

        [Test]
        public void HandlerShouldAddOfferToProperty()
        {
            var buyerUserId = "1";
            var command = new MakeOfferCommand
            {
                BuyerUserId = buyerUserId,
                Offer = 10,
                PropertyId = 1
            };

            var property = new Models.Property
            {
                Description = "Test Property",
                Offers = null
            };

            this.context.Properties.Find(1).Returns(property);

            this.handler.Handle(command);

            this.context.Properties.Received(1).Find(1);
            this.context.Received(1).SaveChanges();

            Assert.True(property.Offers.Count == 1);
            Assert.True(property.Offers.ElementAt(0).BuyerUserId == buyerUserId);
        }
    }
}
