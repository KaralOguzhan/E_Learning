namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_mig_contact_1_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Subject", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "Subject");
        }
    }
}
