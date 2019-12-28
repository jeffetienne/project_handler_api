namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Minimum", c => c.Int());
            AddColumn("dbo.Questions", "Maximum", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "Maximum");
            DropColumn("dbo.Questions", "Minimum");
        }
    }
}
