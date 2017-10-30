namespace MVCReviewSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedMisunderstanding : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "DeviceType", c => c.String());
            AddColumn("dbo.Reviews", "ReleaseDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reviews", "Content");
            DropColumn("dbo.Reviews", "PublishDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "PublishDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reviews", "Content", c => c.String());
            DropColumn("dbo.Reviews", "ReleaseDate");
            DropColumn("dbo.Reviews", "DeviceType");
        }
    }
}
