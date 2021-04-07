namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterProcGetReponsesByFormulaireAddReferenceRemoveLeftJoin : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER PROCEDURE dbo.GetReponsesByFormulaire @formId  int" +
                " AS " +
                "BEGIN " +
                "SELECT  r.id, " +
                "Valeur, " +
                "r.QuestionId, " +
                "ReferenceId = (select id from dbo.DynamicReferences where r.Valeur = Code), " +
                "Code = (select Code from dbo.DynamicReferences where r.Valeur = Code), " +
                "Texte = (select Texte from dbo.DynamicReferences where r.Valeur = Code), " +
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
