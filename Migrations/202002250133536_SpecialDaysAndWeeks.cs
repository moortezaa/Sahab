namespace Sahab_Desktop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpecialDaysAndWeeks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "SpecialDates", c => c.String());
            AddColumn("dbo.Tasks", "DaysOfWeek", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "DaysOfWeek");
            DropColumn("dbo.Tasks", "SpecialDates");
        }
    }
}
