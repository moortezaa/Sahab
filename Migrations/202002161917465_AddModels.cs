namespace Sahab_Desktop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctrines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Frames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Location = c.String(),
                        Peoples = c.String(),
                        Description = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        RepeatMethod = c.Int(nullable: false),
                        ContinuousTimes = c.Int(nullable: false),
                        DiscreteTimes = c.Int(nullable: false),
                        TaskPriority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tasks");
            DropTable("dbo.Frames");
            DropTable("dbo.Doctrines");
        }
    }
}
