namespace OnlineExamination.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusToExamModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exams", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exams", "Status");
        }
    }
}
