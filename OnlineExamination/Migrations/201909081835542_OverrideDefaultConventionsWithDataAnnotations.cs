namespace OnlineExamination.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideDefaultConventionsWithDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Choices", "Text", c => c.String(nullable: false));
            AlterColumn("dbo.Questions", "Text", c => c.String(nullable: false));
            AlterColumn("dbo.Exams", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Questions", "AnswerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "AnswerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Exams", "Name", c => c.String());
            AlterColumn("dbo.Questions", "Text", c => c.String());
            AlterColumn("dbo.Choices", "Text", c => c.String());
        }
    }
}
