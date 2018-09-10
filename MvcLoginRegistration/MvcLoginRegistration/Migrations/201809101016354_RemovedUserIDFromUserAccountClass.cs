namespace MvcLoginRegistration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedUserIDFromUserAccountClass : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserAccounts");
            AlterColumn("dbo.UserAccounts", "UserID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserAccounts", "UserID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserAccounts");
            AlterColumn("dbo.UserAccounts", "UserID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.UserAccounts", "UserID");
        }
    }
}
