using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Base
{
    public abstract class CommandHandler<TCommand>
    {
        protected readonly IOrangeBricksContext context;

        public CommandHandler(IOrangeBricksContext context)
        {
            this.context = context;
        }

        public abstract void Handle(TCommand command);
    }
}