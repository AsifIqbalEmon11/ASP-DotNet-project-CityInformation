namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TokenEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TKey = c.String(nullable: false, maxLength: 200),
                        CreationTime = c.DateTime(nullable: false),
                        ExpirationTime = c.DateTime(nullable: false),
                        AdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete: true)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.CustomerTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TKey = c.String(nullable: false, maxLength: 200),
                        CreationTime = c.DateTime(nullable: false),
                        ExpirationTime = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.ManagerTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TKey = c.String(nullable: false, maxLength: 200),
                        CreationTime = c.DateTime(nullable: false),
                        ExpirationTime = c.DateTime(nullable: false),
                        ManagerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Managers", t => t.ManagerId, cascadeDelete: true)
                .Index(t => t.ManagerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ManagerTokens", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.CustomerTokens", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.AdminTokens", "AdminId", "dbo.Admins");
            DropIndex("dbo.ManagerTokens", new[] { "ManagerId" });
            DropIndex("dbo.CustomerTokens", new[] { "CustomerId" });
            DropIndex("dbo.AdminTokens", new[] { "AdminId" });
            DropTable("dbo.ManagerTokens");
            DropTable("dbo.CustomerTokens");
            DropTable("dbo.AdminTokens");
        }
    }
}
