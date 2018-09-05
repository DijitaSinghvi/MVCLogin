namespace MvcLoginRegistration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAccounts", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAccounts", "Role");
        }
    }
}
