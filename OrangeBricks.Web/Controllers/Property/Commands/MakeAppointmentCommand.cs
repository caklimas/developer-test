using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class MakeAppointmentCommand
    {
        /// <summary>
        /// The id of the property that the appointment is for.
        /// </summary>
        public int PropertyId { get; set; }

        /// <summary>
        /// The user id of the buyer making the appointment.
        /// </summary>
        public string BuyerUserId { get; set; }

        /// <summary>
        /// The date of the appointment
        /// </summary>
        public DateTime AppointmentDate { get; set; }
    }
}