namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_courseVideoTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseLinks", "CourseVideoTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseLinks", "CourseVideoTitle");
        }
    }
}
