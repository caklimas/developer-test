using OrangeBricks.Web.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class MakeAppointmentCommandHandler : CommandHandler<MakeAppointmentCommand>
    {
        public MakeAppointmentCommandHandler(IOrangeBricksContext context) : base(context)
        { }

        public override void Handle(MakeAppointmentCommand command)
        {
            var viewingAppointment = new ViewingAppointment
            {
                BuyerUserId = command.BuyerUserId,
                Date = command.AppointmentDate,
                Status = ViewingAppointmentStatus.Pending
            };

            var property = this.context.Properties.Find(command.PropertyId);
            if (property.Appointments == null)
                property.Appointments = new List<ViewingAppointment>();

            viewingAppointment.SellerUserId = property.SellerUserId;

            property.Appointments.Add(viewingAppointment);
            
            this.context.SaveChanges();
        }
    }
}