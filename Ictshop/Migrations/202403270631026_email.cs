namespace Ictshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class email : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donhang", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Donhang", "Email");
        }
    }
}
