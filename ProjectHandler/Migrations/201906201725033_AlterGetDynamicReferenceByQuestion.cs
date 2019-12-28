namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterGetDynamicReferenceByQuestion : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER PROCEDURE dbo.GetDynamicReferenceByQuestion @questionId  int AS BEGIN SELECT Id, Code, Texte, QuestionId, CreePar, CreeLe FROM    dbo.DynamicReferences WHERE   QuestionId = @questionId END");
        }

        public override void Down()
        {
        }
    }
}
