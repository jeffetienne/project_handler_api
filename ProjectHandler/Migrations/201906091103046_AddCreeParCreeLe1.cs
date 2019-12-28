namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreeParCreeLe1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Formulaires", "CreePar", c => c.String());
            AddColumn("dbo.Formulaires", "CreeLe", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Formulaires", "CreeLe");
            DropColumn("dbo.Formulaires", "CreePar");
        }
    }
}
