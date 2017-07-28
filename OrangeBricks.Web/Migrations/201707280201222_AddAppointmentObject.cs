namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAppointmentObject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BuyerUserId = c.String(nullable: false),
                        SellerId = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Property_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Properties", t => t.Property_Id)
                .Index(t => t.Property_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Property_Id", "dbo.Properties");
            DropIndex("dbo.Appointments", new[] { "Property_Id" });
            DropTable("dbo.Appointments");
        }
    }
}
