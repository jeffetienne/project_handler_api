namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreeParCreeLe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projets", "CreePar", c => c.String());
            AddColumn("dbo.Projets", "CreeLe", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projets", "CreeLe");
            DropColumn("dbo.Projets", "CreePar");
        }
    }
}
