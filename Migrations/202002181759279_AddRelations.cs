namespace Sahab_Desktop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctrineRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskId = c.Int(),
                        DoctrineId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctrines", t => t.DoctrineId)
                .ForeignKey("dbo.Tasks", t => t.TaskId)
                .Index(t => t.TaskId)
                .Index(t => t.DoctrineId);
            
            CreateTable(
                "dbo.FrameRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskId = c.Int(),
                        FrameId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Frames", t => t.FrameId)
                .ForeignKey("dbo.Tasks", t => t.TaskId)
                .Index(t => t.TaskId)
                .Index(t => t.FrameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FrameRelations", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.FrameRelations", "FrameId", "dbo.Frames");
            DropForeignKey("dbo.DoctrineRelations", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.DoctrineRelations", "DoctrineId", "dbo.Doctrines");
            DropIndex("dbo.FrameRelations", new[] { "FrameId" });
            DropIndex("dbo.FrameRelations", new[] { "TaskId" });
            DropIndex("dbo.DoctrineRelations", new[] { "DoctrineId" });
            DropIndex("dbo.DoctrineRelations", new[] { "TaskId" });
            DropTable("dbo.FrameRelations");
            DropTable("dbo.DoctrineRelations");
        }
    }
}
