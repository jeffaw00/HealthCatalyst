namespace HealthCatalystPeopleSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class backtobyteforreal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "Photo", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Photo", c => c.Byte(nullable: false));
        }
    }
}
