using OrangeBricks.Web.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class MakeAppointmentCommandHandler : CommandHandler<MakeAppointmentCommand>
    {
        public MakeAppointmentCommandHandler(IOrangeBricksContext context) : base(context)
        { }

        public override void Handle(MakeAppointmentCommand command)
        {
        }
    }
}