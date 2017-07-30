using OrangeBricks.Web.Controllers.Base;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    /// <summary>
    /// Provides functionality to construct a <see cref="MakeAppointmentViewModel"/>
    /// </summary>
    public class MakeAppointmentViewModelBuilder : ViewModelBuilder
    {
        public MakeAppointmentViewModelBuilder(IOrangeBricksContext context) : base(context)
        { }

        /// <summary>
        /// Constructs a <see cref="MakeAppointmentViewModel"/>
        /// </summary>
        /// <param name="id">The id of the property.</param>
        /// <returns>A new instantiation of <see cref="MakeAppointmentViewModel"/></returns>
        public MakeAppointmentViewModel Build(int id)
        {
            var property = context.Properties.Find(id);

            return new MakeAppointmentViewModel
            {
                Property = property
            };
        }
    }
}