namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTypeForm : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TypeForms(Name) VALUES('Web Application')");
            Sql("INSERT INTO TypeForms(Name) VALUES('Mobile Application')");
        }
        
        public override void Down()
        {
        }
    }
}
