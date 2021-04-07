namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroupeToReponse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reponses", "Groupe", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reponses", "Groupe");
        }
    }
}
