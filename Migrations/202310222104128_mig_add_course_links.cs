namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_course_links : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseLinks",
                c => new
                    {
                        CourseLinkID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        CourseUrl = c.String(),
                    })
                .PrimaryKey(t => t.CourseLinkID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseLinks", "CourseID", "dbo.Courses");
            DropIndex("dbo.CourseLinks", new[] { "CourseID" });
            DropTable("dbo.CourseLinks");
        }
    }
}
