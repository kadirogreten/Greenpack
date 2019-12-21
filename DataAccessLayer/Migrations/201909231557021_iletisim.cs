namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iletisim : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Iletisims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdiSoyadi = c.String(maxLength: 50),
                        Eposta = c.String(),
                        Mesaj = c.String(maxLength: 180),
                        OkunduMu = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Iletisims");
        }
    }
}
