namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterProcGetQuestionsByFormulaireAddOrderByCreeLe : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER PROCEDURE dbo.GetQuestionsByFormulaire @formulaireId  int " +
                "AS " +
                "BEGIN " +
                "SELECT  id, " +
                "Name, " +
                "Message, " +
                "FormulaireId, " +
                "TypeDonneeId, " +
                "Minimum, " +
                "Maximum, " +
                "ComponentId, " +
                "Required, " +
                "CreePar, " +
                "CreeLe " +
                "FROM    dbo.Questions " +
                "WHERE   FormulaireId = @formulaireId " +
                "ORDER BY CreeLe " +
                "END");
        }

        public override void Down()
        {
        }
    }
}
