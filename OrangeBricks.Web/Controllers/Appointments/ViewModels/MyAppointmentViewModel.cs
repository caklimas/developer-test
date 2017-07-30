using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Appointments.ViewModels
{
    /// <summary>
    /// Represents an appointment that was scheduled by a buyer.
    /// </summary>
    public class MyAppointmentViewModel
    {
        /// <summary>
        /// The property that the appointment was scheduled for.
        /// </summary>
        public Models.Property Property { get; set; }

        /// <summary>
        /// The date the appointment was scheduled on.
        /// </summary>
        public DateTime AppointmentDate { get; set; }

        /// <summary>
        /// The status of the appointment.
        /// </summary>
        public ViewingAppointmentStatus Status { get; set; }
    }
}