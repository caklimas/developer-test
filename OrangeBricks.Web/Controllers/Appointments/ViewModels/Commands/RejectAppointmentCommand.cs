namespace OrangeBricks.Web.Controllers.Appointments.Commands
{
    public class RejectAppointmentCommand
    {
        public int PropertyId { get; set; }

        public int AppointmentId { get; set; }
    }
}