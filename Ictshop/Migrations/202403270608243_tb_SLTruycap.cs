namespace Ictshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tb_SLTruycap : DbMigration
    {
        public override void Up()
        {
          
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sanpham", "Mahdh", "dbo.Hedieuhanh");
            DropForeignKey("dbo.Sanpham", "Mahang", "dbo.Hangsanxuat");
            DropForeignKey("dbo.Chitietdonhang", "Masp", "dbo.Sanpham");
            DropForeignKey("dbo.Nguoidung", "IDQuyen", "dbo.PhanQuyen");
            DropForeignKey("dbo.Donhang", "MaNguoidung", "dbo.Nguoidung");
            DropForeignKey("dbo.Chitietdonhang", "Madon", "dbo.Donhang");
            DropIndex("dbo.Sanpham", new[] { "Mahdh" });
            DropIndex("dbo.Sanpham", new[] { "Mahang" });
            DropIndex("dbo.Nguoidung", new[] { "IDQuyen" });
            DropIndex("dbo.Donhang", new[] { "MaNguoidung" });
            DropIndex("dbo.Chitietdonhang", new[] { "Masp" });
            DropIndex("dbo.Chitietdonhang", new[] { "Madon" });
            DropTable("dbo.Hedieuhanh");
            DropTable("dbo.Hangsanxuat");
            DropTable("dbo.Sanpham");
            DropTable("dbo.PhanQuyen");
            DropTable("dbo.Nguoidung");
            DropTable("dbo.Donhang");
            DropTable("dbo.Chitietdonhang");
        }
    }
}
