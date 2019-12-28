namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProcedureGetReponseByQuestion : DbMigration
    {
        public override void Up()
        {
            Sql("CREATE PROCEDURE dbo.GetReponseByQuestion @questionId  int AS BEGIN SELECT  id, Valeur, QuestionId, CreePar, CreeLe FROM    dbo.Reponses WHERE   QuestionId = @questionId END");
        }
        
        public override void Down()
        {
        }
    }
}
