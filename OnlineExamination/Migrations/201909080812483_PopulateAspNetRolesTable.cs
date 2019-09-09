namespace OnlineExamination.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAspNetRolesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AspNetRoles (Id,Name) VALUES (1,'Admin')");
            Sql("INSERT INTO AspNetRoles (Id,Name) VALUES (2,'Student')");
        }
        
        public override void Down()
        {
        }
    }
}
