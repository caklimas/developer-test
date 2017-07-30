using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Property.Commands;
using OrangeBricks.Web.Controllers.Property.Exceptions;
using OrangeBricks.Web.Tests.Controllers.Property.Builders;
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
    public class MakeAppointmentCommandHandlerTest
    {
        private MakeAppointmentCommandHandler handler;
        private IOrangeBricksContext context;
        private IDbSet<ViewingAppointment> appointments;

        [SetUp]
        public void SetUp()
        {
            this.context = Substitute.For<IOrangeBricksContext>();
            this.appointments = Substitute.For<IDbSet<ViewingAppointment>>();
            this.context.ViewingAppointments.Returns(this.appointments);
            this.handler = new MakeAppointmentCommandHandler(this.context);
        }

        [Test]
        public void HandlerShouldAddAppointmentToProperties()
        {
            var buyerUserId = "1";
            var command = new MakeAppointmentCommand
            {
                BuyerUserId = buyerUserId,
                PropertyId = 1
            };

            var property = new Models.Property
            {
                Description = "Test Property",
                Appointments = null,
            };

            var appointments = new List<ViewingAppointment>
                {
                    new ViewingAppointment
                    {
                        Id = 1,
                        Date = new DateTime(2017, 1, 1, 0, 0, 0),
                        Property = property
                    }
                };

            var mockSet = Substitute.For<IDbSet<Models.ViewingAppointment>>()
                .Initialize(appointments.AsQueryable());

            this.context.ViewingAppointments.Returns(mockSet);

            this.context.Properties.Find(1).Returns(property);

            this.handler.Handle(command);

            this.context.Properties.Received(1).Find(1);
            this.context.Received(1).SaveChanges();

            Assert.True(property.Appointments.Count == 1);
            Assert.True(property.Appointments.ElementAt(0).BuyerUserId == buyerUserId);
        }
    }
}
