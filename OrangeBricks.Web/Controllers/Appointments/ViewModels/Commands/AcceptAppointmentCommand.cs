namespace OrangeBricks.Web.Controllers.Appointments.Commands
{
    public class AcceptAppointmentCommand
    {
        public int PropertyId { get; set; }

        public int AppointmentId { get; set; }
    }
}