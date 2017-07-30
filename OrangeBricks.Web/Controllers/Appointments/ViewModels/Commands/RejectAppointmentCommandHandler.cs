using System;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Controllers.Base;

namespace OrangeBricks.Web.Controllers.Appointments.Commands
{
    public class RejectAppointmentCommandHandler : CommandHandler<RejectAppointmentCommand>
    {
        public RejectAppointmentCommandHandler(IOrangeBricksContext context) : base(context)
        { }

        public override void Handle(RejectAppointmentCommand command)
        {
            var appointment = this.context.ViewingAppointments.Find(command.AppointmentId);
            appointment.Status = ViewingAppointmentStatus.Rejected;

            this.context.SaveChanges();
        }
    }
}