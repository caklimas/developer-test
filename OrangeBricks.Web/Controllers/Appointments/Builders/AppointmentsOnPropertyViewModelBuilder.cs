using OrangeBricks.Web.Controllers.Appointments.ViewModels;
using OrangeBricks.Web.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Appointments.Builders
{
    public class AppointmentsOnPropertyViewModelBuilder : ViewModelBuilder
    {
        public AppointmentsOnPropertyViewModelBuilder(IOrangeBricksContext context)
            : base(context)
        { }

        public AppointmentsOnPropertyViewModel Build(int id)
        {
            var property = this.context.Properties
                .Where(p => p.Id == id)
                .Include(x => x.Appointments)
                .SingleOrDefault();

            var appointments = property.Appointments ?? new List<ViewingAppointment>();

            return new AppointmentsOnPropertyViewModel
            {
                Property = property,
                HasAppointments = appointments.Any(),
                Appointments = appointments.Select(a => new AppointmentViewModel
                {
                    Id = a.Id,
                    AppointmentDate = a.Date,
                    IsPending = a.Status == ViewingAppointmentStatus.Pending,
                    Status = a.Status.ToString()
                }),
            };
        }
    }
}