namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iletisims : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Iletisims", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Iletisims", "CreatedDate");
        }
    }
}
