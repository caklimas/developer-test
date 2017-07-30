using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Base
{
    public abstract class ViewModelBuilder
    {
        protected readonly IOrangeBricksContext context;

        public ViewModelBuilder(IOrangeBricksContext context)
        {
            this.context = context;
        }
    }
}