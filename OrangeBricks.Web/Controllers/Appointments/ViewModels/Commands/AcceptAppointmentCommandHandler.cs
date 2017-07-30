using System;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Controllers.Base;

namespace OrangeBricks.Web.Controllers.Appointments.Commands
{
    public class AcceptAppointmentCommandHandler : CommandHandler<AcceptAppointmentCommand>
    {
        public AcceptAppointmentCommandHandler(IOrangeBricksContext context) : base(context)
        { }

        public override void Handle(AcceptAppointmentCommand command)
        {
            var appointment = this.context.ViewingAppointments.Find(command.AppointmentId);
            appointment.Status = ViewingAppointmentStatus.Accepted;

            this.context.SaveChanges();
        }
    }
}