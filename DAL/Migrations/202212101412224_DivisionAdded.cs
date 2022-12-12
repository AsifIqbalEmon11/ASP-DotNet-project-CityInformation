namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DivisionAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Divisions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cities", "Division_Id", c => c.Int());
            AlterColumn("dbo.Cities", "Name", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Cities", "Division_Id");
            AddForeignKey("dbo.Cities", "Division_Id", "dbo.Divisions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "Division_Id", "dbo.Divisions");
            DropIndex("dbo.Cities", new[] { "Division_Id" });
            AlterColumn("dbo.Cities", "Name", c => c.String());
            DropColumn("dbo.Cities", "Division_Id");
            DropTable("dbo.Divisions");
        }
    }
}
