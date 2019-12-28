namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRange : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Questions", "Minimum");
            DropColumn("dbo.Questions", "Maximum");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "Maximum", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "Minimum", c => c.Int(nullable: false));
        }
    }
}
