namespace MVCReviewSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Category_CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryID)
                .Index(t => t.Category_CategoryID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        Score = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Category_CategoryID", "dbo.Categories");
            DropIndex("dbo.Reviews", new[] { "CategoryID" });
            DropIndex("dbo.Categories", new[] { "Category_CategoryID" });
            DropTable("dbo.Reviews");
            DropTable("dbo.Categories");
        }
    }
}
