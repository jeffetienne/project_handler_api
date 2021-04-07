namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProcGetMaxGroupe : DbMigration
    {
        public override void Up()
        {
            Sql("CREATE PROCEDURE dbo.GetMaxGroupe @formId  int" +
                " AS " +
                "BEGIN " +
                "SELECT  Max(Groupe) AS MaxGroupe " +
                "FROM    dbo.Reponses r " +
                "inner join dbo.Questions q " +
                "on r.QuestionId = q.Id " +
                "WHERE   q.FormulaireId = @formId " +
                "END");
        }
        
        public override void Down()
        {
        }
    }
}
