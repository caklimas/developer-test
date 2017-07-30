using OrangeBricks.Web.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrangeBricks.Web.Controllers.Offers.ViewModels;
using System.Web.Mvc;
using OrangeBricks.Web.Controllers.Base;
using OrangeBricks.Web.Controllers.Appointments.ViewModels;

namespace OrangeBricks.Web.Controllers.Appointments.Builders
{
    /// <summary>
    /// Provides functionality to build an instance of <see cref="MyAppointmentsViewModel"/>
    /// </summary>
    public class MyAppointmentsViewModelBuilder : ViewModelBuilder
    {
        public MyAppointmentsViewModelBuilder(IOrangeBricksContext context)
            : base(context)
        { }

        /// <summary>
        /// Builds an instance of <see cref="MyAppointmentsViewModel"/>
        /// </summary>
        /// <param name="userId">The user id of the user's appointments.</param>
        /// <param name="isBuyer">True if the user is a buyer, false otherwise.</param>
        /// <returns>An instance of <see cref="MyOffersViewModel"/></returns>
        /// <remarks>The <paramref name="isBuyer"/> is necessary since each type of user would see their respective appointments.</remarks>
        public MyAppointmentsViewModel Build(string userId, bool isBuyer)
        {
            var appointments = isBuyer ?
                this.context.ViewingAppointments.Where(a => a.BuyerUserId == userId) :
                this.context.ViewingAppointments.Where(a => a.SellerUserId == userId);

            return new MyAppointmentsViewModel
            {
                Appointments = appointments
                .Where(a => a.Date >= DateTime.Now)
                    .Include(a => a.Property)
                    .Select(a => new MyAppointmentViewModel
                    {
                        Property = a.Property,
                        AppointmentDate = a.Date,
                        Status = a.Status
                    })
                    .ToList()
            };
        }
    }
}