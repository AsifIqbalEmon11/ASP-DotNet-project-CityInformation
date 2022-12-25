namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDataAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdminTokens", "AdminId", "dbo.Admins");
            DropForeignKey("dbo.Customers", "AdminId", "dbo.Admins");
            DropForeignKey("dbo.Managers", "AdminId", "dbo.Admins");
            DropForeignKey("dbo.CustomerTokens", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.ManagerTokens", "ManagerId", "dbo.Managers");
            DropIndex("dbo.AdminTokens", new[] { "AdminId" });
            DropIndex("dbo.Customers", new[] { "AdminId" });
            DropIndex("dbo.CustomerTokens", new[] { "CustomerId" });
            DropIndex("dbo.Managers", new[] { "AdminId" });
            DropIndex("dbo.ManagerTokens", new[] { "ManagerId" });
            CreateTable(
                "dbo.HotelBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 50),
                        CheckIn = c.String(nullable: false),
                        Checkout = c.String(),
                        RoomId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId)
                .Index(t => t.RoomId);
            
            AddColumn("dbo.Admins", "Username", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Admins", "Password", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Customers", "Username", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Customers", "Password", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Managers", "Username", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Managers", "Password", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.AdminTokens", "AdminId", c => c.Int());
            AlterColumn("dbo.Customers", "AdminId", c => c.Int());
            AlterColumn("dbo.CustomerTokens", "CustomerId", c => c.Int());
            AlterColumn("dbo.Managers", "AdminId", c => c.Int());
            AlterColumn("dbo.ManagerTokens", "ManagerId", c => c.Int());
            CreateIndex("dbo.AdminTokens", "AdminId");
            CreateIndex("dbo.Customers", "AdminId");
            CreateIndex("dbo.CustomerTokens", "CustomerId");
            CreateIndex("dbo.Managers", "AdminId");
            CreateIndex("dbo.ManagerTokens", "ManagerId");
            AddForeignKey("dbo.AdminTokens", "AdminId", "dbo.Admins", "Id");
            AddForeignKey("dbo.Customers", "AdminId", "dbo.Admins", "Id");
            AddForeignKey("dbo.Managers", "AdminId", "dbo.Admins", "Id");
            AddForeignKey("dbo.CustomerTokens", "CustomerId", "dbo.Customers", "Id");
            AddForeignKey("dbo.ManagerTokens", "ManagerId", "dbo.Managers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ManagerTokens", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.CustomerTokens", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Managers", "AdminId", "dbo.Admins");
            DropForeignKey("dbo.Customers", "AdminId", "dbo.Admins");
            DropForeignKey("dbo.AdminTokens", "AdminId", "dbo.Admins");
            DropForeignKey("dbo.HotelBooks", "RoomId", "dbo.Rooms");
            DropIndex("dbo.HotelBooks", new[] { "RoomId" });
            DropIndex("dbo.ManagerTokens", new[] { "ManagerId" });
            DropIndex("dbo.Managers", new[] { "AdminId" });
            DropIndex("dbo.CustomerTokens", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "AdminId" });
            DropIndex("dbo.AdminTokens", new[] { "AdminId" });
            AlterColumn("dbo.ManagerTokens", "ManagerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Managers", "AdminId", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerTokens", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "AdminId", c => c.Int(nullable: false));
            AlterColumn("dbo.AdminTokens", "AdminId", c => c.Int(nullable: false));
            DropColumn("dbo.Managers", "Password");
            DropColumn("dbo.Managers", "Username");
            DropColumn("dbo.Customers", "Password");
            DropColumn("dbo.Customers", "Username");
            DropColumn("dbo.Admins", "Password");
            DropColumn("dbo.Admins", "Username");
            DropTable("dbo.HotelBooks");
            CreateIndex("dbo.ManagerTokens", "ManagerId");
            CreateIndex("dbo.Managers", "AdminId");
            CreateIndex("dbo.CustomerTokens", "CustomerId");
            CreateIndex("dbo.Customers", "AdminId");
            CreateIndex("dbo.AdminTokens", "AdminId");
            AddForeignKey("dbo.ManagerTokens", "ManagerId", "dbo.Managers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CustomerTokens", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Managers", "AdminId", "dbo.Admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "AdminId", "dbo.Admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AdminTokens", "AdminId", "dbo.Admins", "Id", cascadeDelete: true);
        }
    }
}
