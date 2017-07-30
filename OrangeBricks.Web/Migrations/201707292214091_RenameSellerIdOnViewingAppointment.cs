namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameSellerIdOnViewingAppointment : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.ViewingAppointments", "SellerId", "SellerUserId");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.ViewingAppointments", "SellerUserId", "SellerId");
        }
    }
}
