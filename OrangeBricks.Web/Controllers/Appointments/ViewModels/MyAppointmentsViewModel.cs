using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrangeBricks.Web.Controllers.Appointments.ViewModels
{
    /// <summary>
    /// Represents a list of appointments that a buyer schedules.
    /// </summary>
    public class MyAppointmentsViewModel
    {
        /// <summary>
        /// The list of appointments that a buyer scheduled.
        /// </summary>
        public List<MyAppointmentViewModel> Appointments { get; set; }
    }
}