namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterProcGetReponsesByFormulaireAddReference : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER PROCEDURE dbo.GetReponsesByFormulaire @formId  int" +
                " AS " +
                "BEGIN " +
                "SELECT  r.id, " +
                "Valeur, " +
                "r.QuestionId, " +
                "d.Id, " +
                "d.Code, " +
                "d.Texte, " +
                "r.CreePar, " +
                "r.CreeLe " +
                "FROM    dbo.Reponses r " +
                "inner join dbo.Questions q " +
                "on r.QuestionId = q.Id " +
                "left join dbo.DynamicReferences d " +
                "on d.QuestionId = q.Id " +
                "WHERE   q.FormulaireId = @formId " +
                "order by creeLe END");
        }
        
        public override void Down()
        {
        }
    }
}
