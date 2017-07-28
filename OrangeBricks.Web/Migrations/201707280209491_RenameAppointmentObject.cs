namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameAppointmentObject : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Appointments", newName: "ViewingAppointments");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ViewingAppointments", newName: "Appointments");
        }
    }
}
