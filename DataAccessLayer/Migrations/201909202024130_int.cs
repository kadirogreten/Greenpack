namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _int : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Resims", "HizmetlerimizMenuId", "dbo.HizmetlerimizMenus");
            DropIndex("dbo.Resims", new[] { "HizmetlerimizMenuId" });
            DropPrimaryKey("dbo.HizmetlerimizMenus");
            DropPrimaryKey("dbo.KurumsalMenus");
            AlterColumn("dbo.HizmetlerimizMenus", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Resims", "HizmetlerimizMenuId", c => c.Int(nullable: false));
            AlterColumn("dbo.KurumsalMenus", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.HizmetlerimizMenus", "Id");
            AddPrimaryKey("dbo.KurumsalMenus", "Id");
            CreateIndex("dbo.Resims", "HizmetlerimizMenuId");
            AddForeignKey("dbo.Resims", "HizmetlerimizMenuId", "dbo.HizmetlerimizMenus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resims", "HizmetlerimizMenuId", "dbo.HizmetlerimizMenus");
            DropIndex("dbo.Resims", new[] { "HizmetlerimizMenuId" });
            DropPrimaryKey("dbo.KurumsalMenus");
            DropPrimaryKey("dbo.HizmetlerimizMenus");
            AlterColumn("dbo.KurumsalMenus", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Resims", "HizmetlerimizMenuId", c => c.Byte(nullable: false));
            AlterColumn("dbo.HizmetlerimizMenus", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.KurumsalMenus", "Id");
            AddPrimaryKey("dbo.HizmetlerimizMenus", "Id");
            CreateIndex("dbo.Resims", "HizmetlerimizMenuId");
            AddForeignKey("dbo.Resims", "HizmetlerimizMenuId", "dbo.HizmetlerimizMenus", "Id", cascadeDelete: true);
        }
    }
}
