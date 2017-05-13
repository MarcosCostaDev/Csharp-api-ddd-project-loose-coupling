namespace api_baixo_acoplamento.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Application = c.String(),
                        MessageType = c.String(),
                        message = c.String(),
                        CurrentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LogMessages");
        }
    }
}
