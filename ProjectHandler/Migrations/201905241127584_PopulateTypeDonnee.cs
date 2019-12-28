namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTypeDonnee : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TypeDonnees(Name) VALUES('Entier')");
            Sql("INSERT INTO TypeDonnees(Name) VALUES('Decimal')");
            Sql("INSERT INTO TypeDonnees(Name) VALUES('gps')");
            Sql("INSERT INTO TypeDonnees(Name) VALUES('Date')");
            Sql("INSERT INTO TypeDonnees(Name) VALUES('Datetime')");
            Sql("INSERT INTO TypeDonnees(Name) VALUES('Time')");
            Sql("INSERT INTO TypeDonnees(Name) VALUES('Textes')");
        }
        
        public override void Down()
        {
        }
    }
}
