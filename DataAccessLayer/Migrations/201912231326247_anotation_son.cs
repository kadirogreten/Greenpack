namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotation_son : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Galeris", "Aciklama", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.HizmetlerimizMenus", "HizmetAdi", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HizmetlerimizMenus", "HizmetAdi", c => c.String(nullable: false));
            AlterColumn("dbo.Galeris", "Aciklama", c => c.String());
        }
    }
}
