namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGetDynamicReferenceByQuestion : DbMigration
    {
        public override void Up()
        {
            Sql("CREATE PROCEDURE dbo.GetDynamicReferenceByQuestion @questionId  int AS BEGIN SELECT  Code, Texte, QuestionId, CreePar, CreeLe FROM    dbo.DynamicReferences WHERE   QuestionId = @questionId END");
        }

        public override void Down()
        {
            this.Sql("DROP PROCEDURE dbo.GetDynamicReferenceByQuestion ");
        }
    }
}
