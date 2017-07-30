using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Appointments.ViewModels
{
    public class AppointmentsOnPropertyViewModel
    {
        public Models.Property Property { get; set; }

        public IEnumerable<AppointmentViewModel> Appointments { get; set; }

        public bool HasAppointments { get; set; }
    }
}