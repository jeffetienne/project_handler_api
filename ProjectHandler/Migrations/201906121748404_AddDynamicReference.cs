namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDynamicReference : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DynamicReferences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Texte = c.String(),
                        QuestionId = c.Int(nullable: false),
                        CreePar = c.String(),
                        CreeLe = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DynamicReferences", "QuestionId", "dbo.Questions");
            DropIndex("dbo.DynamicReferences", new[] { "QuestionId" });
            DropTable("dbo.DynamicReferences");
        }
    }
}
