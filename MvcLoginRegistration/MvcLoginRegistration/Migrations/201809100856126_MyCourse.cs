namespace MvcLoginRegistration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyCourse : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserAccounts");
            AddColumn("dbo.UserAccounts", "Course", c => c.String());
            AlterColumn("dbo.UserAccounts", "UserId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.UserAccounts", "UserID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserAccounts");
            AlterColumn("dbo.UserAccounts", "UserId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.UserAccounts", "Course");
            AddPrimaryKey("dbo.UserAccounts", "UserID");
        }
    }
}
