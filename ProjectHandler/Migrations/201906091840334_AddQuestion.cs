namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuestion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FormulaireId = c.Int(nullable: false),
                        Message = c.String(),
                        TypeDonneeId = c.Int(nullable: false),
                        ComponentId = c.Int(nullable: false),
                        Required = c.Boolean(nullable: false),
                        CreePar = c.String(),
                        CreeLe = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Components", t => t.ComponentId, cascadeDelete: true)
                .ForeignKey("dbo.Formulaires", t => t.FormulaireId, cascadeDelete: true)
                .ForeignKey("dbo.TypeDonnees", t => t.TypeDonneeId, cascadeDelete: true)
                .Index(t => t.FormulaireId)
                .Index(t => t.TypeDonneeId)
                .Index(t => t.ComponentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "TypeDonneeId", "dbo.TypeDonnees");
            DropForeignKey("dbo.Questions", "FormulaireId", "dbo.Formulaires");
            DropForeignKey("dbo.Questions", "ComponentId", "dbo.Components");
            DropIndex("dbo.Questions", new[] { "ComponentId" });
            DropIndex("dbo.Questions", new[] { "TypeDonneeId" });
            DropIndex("dbo.Questions", new[] { "FormulaireId" });
            DropTable("dbo.Questions");
        }
    }
}
