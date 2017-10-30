namespace MVCReviewSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringNameChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "DeviceReview", c => c.String());
            DropColumn("dbo.Reviews", "DeviceType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "DeviceType", c => c.String());
            DropColumn("dbo.Reviews", "DeviceReview");
        }
    }
}
