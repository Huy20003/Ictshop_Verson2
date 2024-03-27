namespace Ictshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sanpham", "ViewCout", c => c.Int(nullable: false));
            AlterColumn("dbo.Nguoidung", "Hoten", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Nguoidung", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Nguoidung", "Dienthoai", c => c.String(nullable: false, maxLength: 10, fixedLength: true));
            AlterColumn("dbo.Nguoidung", "Matkhau", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.Nguoidung", "Anhdaidien", c => c.String(maxLength: 128, fixedLength: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Nguoidung", "Anhdaidien", c => c.String(maxLength: 30, fixedLength: true));
            AlterColumn("dbo.Nguoidung", "Matkhau", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Nguoidung", "Dienthoai", c => c.String(maxLength: 10, fixedLength: true));
            AlterColumn("dbo.Nguoidung", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Nguoidung", "Hoten", c => c.String(maxLength: 50));
            DropColumn("dbo.Sanpham", "ViewCout");
        }
    }
}
