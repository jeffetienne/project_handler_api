namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterProcedureGetReponsesByFormulaireAddRef : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER PROCEDURE dbo.GetReponsesByFormulaire @formId  int" +
                " AS " +
                "BEGIN " +
                "SELECT  r.id, " +
                "Valeur, " +
                "QuestionId, " +
                "DynamicReferenceId, " +
                "r.CreePar, " +
                "r.CreeLe " +
                "FROM    dbo.Reponses r " +
                "inner join dbo.Questions q " +
                "on r.QuestionId = q.Id " +
                "WHERE   q.FormulaireId = @formId " +
                "order by creeLe END");
        }
        
        public override void Down()
        {
        }
    }
}
