namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDynamicRefToReponse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reponses", "DynamicReferenceId", c => c.Int());
            CreateIndex("dbo.Reponses", "DynamicReferenceId");
            AddForeignKey("dbo.Reponses", "DynamicReferenceId", "dbo.DynamicReferences", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reponses", "DynamicReferenceId", "dbo.DynamicReferences");
            DropIndex("dbo.Reponses", new[] { "DynamicReferenceId" });
            DropColumn("dbo.Reponses", "DynamicReferenceId");
        }
    }
}
