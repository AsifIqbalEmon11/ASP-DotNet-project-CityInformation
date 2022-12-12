namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "RentId", "dbo.RentCars");
            DropForeignKey("dbo.RentCars", "CId", "dbo.Cities");
            DropForeignKey("dbo.Hotels", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Rooms", "HotelId", "dbo.Hotels");
            DropIndex("dbo.Cars", new[] { "RentId" });
            DropIndex("dbo.RentCars", new[] { "CId" });
            DropIndex("dbo.Hotels", new[] { "CityId" });
            DropIndex("dbo.Rooms", new[] { "HotelId" });
            RenameColumn(table: "dbo.Cities", name: "Division_Id", newName: "DId");
            RenameIndex(table: "dbo.Cities", name: "IX_Division_Id", newName: "IX_DId");
            AlterColumn("dbo.Cars", "RentId", c => c.Int());
            AlterColumn("dbo.RentCars", "CId", c => c.Int());
            AlterColumn("dbo.Hotels", "CityId", c => c.Int());
            AlterColumn("dbo.Rooms", "HotelId", c => c.Int());
            CreateIndex("dbo.Cars", "RentId");
            CreateIndex("dbo.RentCars", "CId");
            CreateIndex("dbo.Hotels", "CityId");
            CreateIndex("dbo.Rooms", "HotelId");
            AddForeignKey("dbo.Cars", "RentId", "dbo.RentCars", "Id");
            AddForeignKey("dbo.RentCars", "CId", "dbo.Cities", "Id");
            AddForeignKey("dbo.Hotels", "CityId", "dbo.Cities", "Id");
            AddForeignKey("dbo.Rooms", "HotelId", "dbo.Hotels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "HotelId", "dbo.Hotels");
            DropForeignKey("dbo.Hotels", "CityId", "dbo.Cities");
            DropForeignKey("dbo.RentCars", "CId", "dbo.Cities");
            DropForeignKey("dbo.Cars", "RentId", "dbo.RentCars");
            DropIndex("dbo.Rooms", new[] { "HotelId" });
            DropIndex("dbo.Hotels", new[] { "CityId" });
            DropIndex("dbo.RentCars", new[] { "CId" });
            DropIndex("dbo.Cars", new[] { "RentId" });
            AlterColumn("dbo.Rooms", "HotelId", c => c.Int(nullable: false));
            AlterColumn("dbo.Hotels", "CityId", c => c.Int(nullable: false));
            AlterColumn("dbo.RentCars", "CId", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "RentId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Cities", name: "IX_DId", newName: "IX_Division_Id");
            RenameColumn(table: "dbo.Cities", name: "DId", newName: "Division_Id");
            CreateIndex("dbo.Rooms", "HotelId");
            CreateIndex("dbo.Hotels", "CityId");
            CreateIndex("dbo.RentCars", "CId");
            CreateIndex("dbo.Cars", "RentId");
            AddForeignKey("dbo.Rooms", "HotelId", "dbo.Hotels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Hotels", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RentCars", "CId", "dbo.Cities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cars", "RentId", "dbo.RentCars", "Id", cascadeDelete: true);
        }
    }
}

