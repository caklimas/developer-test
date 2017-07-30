using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Appointments.Commands;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeBricks.Web.Tests.Controllers.Appointments.Commands
{
    [TestFixture]
    public class AcceptAppointmentCommandHandlerTest
    {
        public AcceptAppointmentCommandHandler handler;
        private IOrangeBricksContext context;
        private IDbSet<Models.ViewingAppointment> appointments;

        [SetUp]
        public void SetUp()
        {
            this.context = Substitute.For<IOrangeBricksContext>();
            this.appointments = Substitute.For<IDbSet<Models.ViewingAppointment>>();
            this.context.ViewingAppointments.Returns(this.appointments);
            this.handler = new AcceptAppointmentCommandHandler(context);
        }

        [Test]
        public void HandleShouldAcceptAppointment()
        {
            var command = new AcceptAppointmentCommand()
            {
                AppointmentId = 1
            };

            var appointment = new Models.ViewingAppointment
            {
                Status = ViewingAppointmentStatus.Pending
            };

            this.appointments.Find(1).Returns(appointment);

            this.handler.Handle(command);

            this.context.ViewingAppointments.Received(1).Find(1);
            this.context.Received(1).SaveChanges();
            Assert.True(appointment.Status == ViewingAppointmentStatus.Accepted);
        }
    }
}
