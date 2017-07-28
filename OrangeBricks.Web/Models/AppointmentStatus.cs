using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Models
{
    /// <summary>
    /// Represents the current status of an appointment that a buyer makes with a seller of a property.
    /// </summary>
    public enum AppointmentStatus
    {
        /// <summary>
        /// The appointment is still pending an answer from the seller.
        /// </summary>
        Pending,

        /// <summary>
        /// The appointment has been accepted by the seller.
        /// </summary>
        Accepted,

        /// <summary>
        /// The appointment has been rejected by the seller.
        /// </summary>
        Rejected
    }
}