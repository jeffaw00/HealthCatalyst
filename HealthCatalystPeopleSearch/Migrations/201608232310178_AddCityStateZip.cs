namespace HealthCatalystPeopleSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCityStateZip : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "City", c => c.String());
            AddColumn("dbo.People", "State", c => c.String());
            AddColumn("dbo.People", "Zip", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Zip");
            DropColumn("dbo.People", "State");
            DropColumn("dbo.People", "City");
        }
    }
}
