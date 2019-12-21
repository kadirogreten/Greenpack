namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class galeri : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GaleriFilters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FilterName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Galeris", "GaleriFilterId", c => c.Int(nullable: true));
            CreateIndex("dbo.Galeris", "GaleriFilterId");
            AddForeignKey("dbo.Galeris", "GaleriFilterId", "dbo.GaleriFilters", "Id", cascadeDelete: true);
            DropColumn("dbo.Galeris", "ResimTip");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Galeris", "ResimTip", c => c.Int(nullable: false));
            DropForeignKey("dbo.Galeris", "GaleriFilterId", "dbo.GaleriFilters");
            DropIndex("dbo.Galeris", new[] { "GaleriFilterId" });
            DropColumn("dbo.Galeris", "GaleriFilterId");
            DropTable("dbo.GaleriFilters");
        }
    }
}
