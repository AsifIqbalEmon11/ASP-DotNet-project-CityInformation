namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class valueAddeddd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AdminTokens", "ExpirationTime", c => c.DateTime());
            AlterColumn("dbo.CustomerTokens", "ExpirationTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerTokens", "ExpirationTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AdminTokens", "ExpirationTime", c => c.DateTime(nullable: false));
        }
    }
}
