namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFormulaire : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Formulaires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        TypeFormId = c.Int(nullable: false),
                        ProjetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projets", t => t.ProjetId, cascadeDelete: true)
                .ForeignKey("dbo.TypeForms", t => t.TypeFormId, cascadeDelete: true)
                .Index(t => t.TypeFormId)
                .Index(t => t.ProjetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Formulaires", "TypeFormId", "dbo.TypeForms");
            DropForeignKey("dbo.Formulaires", "ProjetId", "dbo.Projets");
            DropIndex("dbo.Formulaires", new[] { "ProjetId" });
            DropIndex("dbo.Formulaires", new[] { "TypeFormId" });
            DropTable("dbo.Formulaires");
        }
    }
}
