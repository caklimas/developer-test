using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Appointments.ViewModels
{
    public class AppointmentViewModel
    {
        public int Id;
        public DateTime AppointmentDate { get; set; }
        public bool IsPending { get; set; }
        public string Status { get; set; }
    }
}