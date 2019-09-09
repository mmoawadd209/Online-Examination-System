namespace OnlineExamination.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingQuestionModelAnottaions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "Text", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "Text", c => c.String(nullable: false));
        }
    }
}
