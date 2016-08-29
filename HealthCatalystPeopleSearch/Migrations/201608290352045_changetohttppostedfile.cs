namespace HealthCatalystPeopleSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetohttppostedfile : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Photo", c => c.Binary());
        }
    }
}
