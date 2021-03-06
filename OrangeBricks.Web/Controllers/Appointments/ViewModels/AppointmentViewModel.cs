﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Appointments.ViewModels
{
    /// <summary>
    /// Represents an appointment that a buyer made.
    /// </summary>
    public class AppointmentViewModel
    {
        /// <summary>
        /// The unique id of the appointment.
        /// </summary>
        public int Id;

        /// <summary>
        /// The scheduled date of the appointment.
        /// </summary>
        public DateTime AppointmentDate { get; set; }

        /// <summary>
        /// True if the status is pending, false otherwise.
        /// </summary>
        public bool IsPending { get; set; }

        /// <summary>
        /// The status of the appointment.
        /// </summary>
        public string Status { get; set; }
    }
}