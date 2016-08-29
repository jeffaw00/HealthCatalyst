namespace HealthCatalystPeopleSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class backtobyte : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Photo", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Photo");
        }
    }
}
