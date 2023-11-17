namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_mig_catogoryImg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryHeaderImgUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "CategoryHeaderImgUrl");
        }
    }
}
