namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GaleriFilters", "FilterName", c => c.String(nullable: false));
            AlterColumn("dbo.HizmetlerimizMenus", "HizmetAdi", c => c.String(nullable: false));
            AlterColumn("dbo.HizmetlerimizMenus", "HizmetAciklama", c => c.String(nullable: false));
            AlterColumn("dbo.Iletisims", "AdiSoyadi", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Iletisims", "Eposta", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Iletisims", "Mesaj", c => c.String(nullable: false, maxLength: 180));
            AlterColumn("dbo.KurumsalMenus", "MenuAdi", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.KurumsalMenus", "Baslik", c => c.String(nullable: false, maxLength: 75));
            AlterColumn("dbo.KurumsalMenus", "AltBaslik", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.KurumsalMenus", "Detay", c => c.String(nullable: false));
            AlterColumn("dbo.Sliders", "Aciklama1", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Sliders", "Aciklama2", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Sliders", "Aciklama3", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sliders", "Aciklama3", c => c.String());
            AlterColumn("dbo.Sliders", "Aciklama2", c => c.String());
            AlterColumn("dbo.Sliders", "Aciklama1", c => c.String());
            AlterColumn("dbo.KurumsalMenus", "Detay", c => c.String());
            AlterColumn("dbo.KurumsalMenus", "AltBaslik", c => c.String());
            AlterColumn("dbo.KurumsalMenus", "Baslik", c => c.String());
            AlterColumn("dbo.KurumsalMenus", "MenuAdi", c => c.String());
            AlterColumn("dbo.Iletisims", "Mesaj", c => c.String(maxLength: 180));
            AlterColumn("dbo.Iletisims", "Eposta", c => c.String());
            AlterColumn("dbo.Iletisims", "AdiSoyadi", c => c.String(maxLength: 50));
            AlterColumn("dbo.HizmetlerimizMenus", "HizmetAciklama", c => c.String());
            AlterColumn("dbo.HizmetlerimizMenus", "HizmetAdi", c => c.String());
            AlterColumn("dbo.GaleriFilters", "FilterName", c => c.String());
        }
    }
}
