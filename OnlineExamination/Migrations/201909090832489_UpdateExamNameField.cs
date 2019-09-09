namespace OnlineExamination.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateExamNameField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Exams", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exams", "Name", c => c.String(nullable: false));
        }
    }
}
