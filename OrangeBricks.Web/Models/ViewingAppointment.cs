using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Models
{
    /// <summary>
    /// Represents a viewing appointment that the buyer has at a seller's property.
    /// </summary>
    public class ViewingAppointment
    {
        /// <summary>
        /// A unique id of the <see cref="ViewingAppointment"/> record.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The user id of the buyer making the appointment.
        /// </summary>
        [Required]
        public string BuyerUserId { get; set; }

        /// <summary>
        /// The user id of the seller of the property.
        /// </summary>
        [Required]
        public string SellerId { get; set; }

        /// <summary>
        /// The date that the appointment will take place.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The status of the appointment.
        /// </summary>
        public ViewingAppointmentStatus Status { get; set; }

        /// <summary>
        /// The property that the appointment is for.
        /// </summary>
        public virtual Property Property { get; set; }
    }
}