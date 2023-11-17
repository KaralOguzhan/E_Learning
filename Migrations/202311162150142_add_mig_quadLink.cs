namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_mig_quadLink : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuadLinks",
                c => new
                    {
                        quadLinkID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.quadLinkID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.QuadLinks");
        }
    }
}
