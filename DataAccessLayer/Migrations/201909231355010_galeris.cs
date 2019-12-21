namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class galeris : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Galeris", "GaleriFilterId", "dbo.GaleriFilters");
            DropIndex("dbo.Galeris", new[] { "GaleriFilterId" });
            AlterColumn("dbo.Galeris", "GaleriFilterId", c => c.Int());
            CreateIndex("dbo.Galeris", "GaleriFilterId");
            AddForeignKey("dbo.Galeris", "GaleriFilterId", "dbo.GaleriFilters", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Galeris", "GaleriFilterId", "dbo.GaleriFilters");
            DropIndex("dbo.Galeris", new[] { "GaleriFilterId" });
            AlterColumn("dbo.Galeris", "GaleriFilterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Galeris", "GaleriFilterId");
            AddForeignKey("dbo.Galeris", "GaleriFilterId", "dbo.GaleriFilters", "Id", cascadeDelete: true);
        }
    }
}
