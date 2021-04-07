namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRefFromReponse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reponses", "DynamicReferenceId", "dbo.DynamicReferences");
            DropIndex("dbo.Reponses", new[] { "DynamicReferenceId" });
            DropColumn("dbo.Reponses", "DynamicReferenceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reponses", "DynamicReferenceId", c => c.Int());
            CreateIndex("dbo.Reponses", "DynamicReferenceId");
            AddForeignKey("dbo.Reponses", "DynamicReferenceId", "dbo.DynamicReferences", "Id");
        }
    }
}
