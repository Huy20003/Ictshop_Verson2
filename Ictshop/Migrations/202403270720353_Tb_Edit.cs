namespace Ictshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tb_Edit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReviewSanPham",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SanPhamID = c.Int(nullable: false),
                        UserName = c.String(),
                        FullName = c.String(),
                        Email = c.String(),
                        Content = c.String(),
                        Rate = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Avatar = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sanpham", t => t.SanPhamID, cascadeDelete: true)
                .Index(t => t.SanPhamID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReviewSanPham", "SanPhamID", "dbo.Sanpham");
            DropIndex("dbo.ReviewSanPham", new[] { "SanPhamID" });
            DropTable("dbo.ReviewSanPham");
        }
    }
}
