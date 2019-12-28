namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProcedureGetReferenceByCode : DbMigration
    {
        public override void Up()
        {
            Sql("CREATE PROCEDURE dbo.GetDynamicReferenceByCode @questionId  int, @code nvarchar(50) " +
                "AS " +
                "BEGIN " +
                "SELECT  Code, " +
                "Texte, " +
                "QuestionId, " +
                "CreePar, " +
                "CreeLe " +
                "FROM    dbo.DynamicReferences " +
                "WHERE   QuestionId = @questionId and Code = @code END");
        }
        
        public override void Down()
        {
        }
    }
}
