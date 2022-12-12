namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewEntityAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Gender = c.String(nullable: false, maxLength: 200),
                        DOB = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Gender = c.String(nullable: false, maxLength: 200),
                        DOB = c.String(nullable: false, maxLength: 200),
                        AdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete: true)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Gender = c.String(nullable: false, maxLength: 200),
                        DOB = c.String(nullable: false, maxLength: 200),
                        AdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete: true)
                .Index(t => t.AdminId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Managers", "AdminId", "dbo.Admins");
            DropForeignKey("dbo.Customers", "AdminId", "dbo.Admins");
            DropIndex("dbo.Managers", new[] { "AdminId" });
            DropIndex("dbo.Customers", new[] { "AdminId" });
            DropTable("dbo.Managers");
            DropTable("dbo.Customers");
            DropTable("dbo.Admins");
        }
    }
}
