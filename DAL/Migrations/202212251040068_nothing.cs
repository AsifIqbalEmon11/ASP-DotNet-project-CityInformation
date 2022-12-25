namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nothing : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ManagerTokens", "ManagerId", "dbo.Managers");
            DropIndex("dbo.ManagerTokens", new[] { "ManagerId" });
            AlterColumn("dbo.ManagerTokens", "ManagerId", c => c.Int(nullable: false));
            CreateIndex("dbo.ManagerTokens", "ManagerId");
            AddForeignKey("dbo.ManagerTokens", "ManagerId", "dbo.Managers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ManagerTokens", "ManagerId", "dbo.Managers");
            DropIndex("dbo.ManagerTokens", new[] { "ManagerId" });
            AlterColumn("dbo.ManagerTokens", "ManagerId", c => c.Int());
            CreateIndex("dbo.ManagerTokens", "ManagerId");
            AddForeignKey("dbo.ManagerTokens", "ManagerId", "dbo.Managers", "Id");
        }
    }
}
