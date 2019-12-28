namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRangeToQuestion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Minimum", c => c.Int(nullable: true));
            AddColumn("dbo.Questions", "Maximum", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "Maximum");
            DropColumn("dbo.Questions", "Minimum");
        }
    }
}
