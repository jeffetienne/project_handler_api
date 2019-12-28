namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Text;

    public partial class AddGetQuestionByFormulaireProcedure : DbMigration
    {
        public override void Up()
        {
            Sql("CREATE PROCEDURE dbo.GetQuestionsByFormulaire @formulaireId  int AS BEGIN SELECT  id, Name, Message, FormulaireId, TypeDonneeId, ComponentId, Required, CreePar, CreeLe FROM    dbo.Questions WHERE   FormulaireId = @formulaireId END");
        }
        
        public override void Down()
        {
            this.Sql("DROP PROCEDURE dbo.GetQuestionsByFormulaire ");
        }
    }
}
