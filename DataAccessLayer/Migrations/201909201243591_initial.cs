namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Galeris",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Path = c.String(),
                    Sira = c.Short(nullable: false),
                    ResimTip = c.Int(nullable: false),
                    Aciklama = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.HizmetlerimizMenus",
                c => new
                {
                    Id = c.Byte(nullable: false, identity: true),
                    HizmetAdi = c.String(),
                    HizmetAciklama = c.String(),
                    Sira = c.Byte(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Resims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Path = c.String(),
                    Sira = c.Short(nullable: false),
                    IsSelected = c.Boolean(nullable: false),
                    Deleted = c.Boolean(nullable: false),
                    HizmetlerimizMenuId = c.Byte(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HizmetlerimizMenus", t => t.HizmetlerimizMenuId, cascadeDelete: true)
                .Index(t => t.HizmetlerimizMenuId);

            CreateTable(
                "dbo.KurumsalMenus",
                c => new
                {
                    Id = c.Byte(nullable: false, identity: true),
                    MenuAdi = c.String(),
                    Baslik = c.String(),
                    AltBaslik = c.String(),
                    Detay = c.String(),
                    Sira = c.Byte(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Resims", "HizmetlerimizMenuId", "dbo.HizmetlerimizMenus");
            DropIndex("dbo.Resims", new[] { "HizmetlerimizMenuId" });
            DropTable("dbo.KurumsalMenus");
            DropTable("dbo.Resims");
            DropTable("dbo.HizmetlerimizMenus");
            DropTable("dbo.Galeris");
        }
    }
}
