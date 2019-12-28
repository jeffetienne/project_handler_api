namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReponse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reponses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valeur = c.String(),
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
            DropForeignKey("dbo.Reponses", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Reponses", new[] { "QuestionId" });
            DropTable("dbo.Reponses");
        }
    }
}
