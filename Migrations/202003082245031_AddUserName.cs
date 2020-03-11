namespace Sahab_Desktop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserName");
        }
    }
}
