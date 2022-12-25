namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Valid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ManagerTokens", "ExpirationTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ManagerTokens", "ExpirationTime", c => c.DateTime(nullable: false));
        }
    }
}
