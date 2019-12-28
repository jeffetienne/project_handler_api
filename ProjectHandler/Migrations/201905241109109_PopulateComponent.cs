namespace ProjectHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateComponent : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Components(Name) VALUES('TextBox')");
            Sql("INSERT INTO Components(Name) VALUES('ComboBox')");
            Sql("INSERT INTO Components(Name) VALUES('RadioButton')");
            Sql("INSERT INTO Components(Name) VALUES('CheckBox')");
            Sql("INSERT INTO Components(Name) VALUES('TextArea')");
            Sql("INSERT INTO Components(Name) VALUES('DateTimePicker')");
            Sql("INSERT INTO Components(Name) VALUES('GPS')");
        }
        
        public override void Down()
        {
        }
    }
}
