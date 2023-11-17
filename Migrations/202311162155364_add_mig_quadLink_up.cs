namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_mig_quadLink_up : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuadLinks", "Ikon", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuadLinks", "Ikon");
        }
    }
}
