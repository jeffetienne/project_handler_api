namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDomain : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Domaines(Name) VALUES('Santé')");
            Sql("INSERT INTO Domaines(Name) VALUES('Education')");
            Sql("INSERT INTO Domaines(Name) VALUES('Environement')");
            Sql("INSERT INTO Domaines(Name) VALUES('Sport')");
        }
        
        public override void Down()
        {
        }
    }
}
