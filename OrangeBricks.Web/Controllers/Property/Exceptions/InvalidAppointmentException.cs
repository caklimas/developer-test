using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Property.Exceptions
{
    /// <summary>
    /// Occurs when and appointment is scheduled within an hour of an already accepted appointment.
    /// </summary>
    public class InvalidAppointmentException : Exception
    {
        public InvalidAppointmentException()
        { }
    }
}