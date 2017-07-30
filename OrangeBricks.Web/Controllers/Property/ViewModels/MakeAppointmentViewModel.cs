using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
    public class MakeAppointmentViewModel
    {
        /// <summary>
        /// The property that the appointment is being made for.
        /// </summary>
        public Models.Property Property { get; set; }

        /// <summary>
        /// The scheduled date of the appointment.
        /// </summary>
        public DateTime AppointmentDate { get; set; }
    }
}