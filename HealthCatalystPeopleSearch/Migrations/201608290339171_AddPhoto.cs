namespace HealthCatalystPeopleSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Photo", c => c.Binary());
            DropColumn("dbo.People", "PicName");
            DropColumn("dbo.People", "PicLocation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "PicLocation", c => c.String());
            AddColumn("dbo.People", "PicName", c => c.String());
            DropColumn("dbo.People", "Photo");
        }
    }
}
