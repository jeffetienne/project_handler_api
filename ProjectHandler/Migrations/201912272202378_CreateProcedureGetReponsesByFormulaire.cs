namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProcedureGetReponsesByFormulaire : DbMigration
    {
        public override void Up()
        {
            Sql("CREATE PROCEDURE dbo.GetReponsesByFormulaire @formId  int" +
                " AS " +
                "BEGIN " +
                "SELECT  r.id, " +
                "Valeur, " +
                "QuestionId, " +
                "r.CreePar, " +
                "r.CreeLe " +
                "FROM    dbo.Reponses r " +
                "inner join dbo.Questions q " +
                "on r.QuestionId = q.Id " +
                "WHERE   q.FormulaireId = @formId END");
        }

        public override void Down()
        {
        }
    }
}
