namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(),
                        DomaineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Domaines", t => t.DomaineId, cascadeDelete: true)
                .Index(t => t.DomaineId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projets", "DomaineId", "dbo.Domaines");
            DropIndex("dbo.Projets", new[] { "DomaineId" });
            DropTable("dbo.Projets");
        }
    }
}
