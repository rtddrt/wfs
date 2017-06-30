namespace Wfs.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApiActionUsingLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApiActionUsingLogs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ActionId = c.Guid(nullable: false),
                        Ip = c.String(nullable: false, maxLength: 50),
                        BrowserInfo = c.String(maxLength: 512),
                        UsingResult = c.String(maxLength: 256),
                        CreationTime = c.DateTime(nullable: false),
                        UpdationTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ApiActionUsingLogs");
        }
    }
}
