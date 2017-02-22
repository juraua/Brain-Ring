namespace DbBrainRing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Questions", new[] { "Category_Id" });
            DropPrimaryKey("dbo.Points");
            CreateTable(
                "dbo.Themes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Games", "AllPoints", c => c.Int(nullable: false));
            AddColumn("dbo.Teams", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Teams", "AllPoints", c => c.Int(nullable: false));
            AddColumn("dbo.Teams", "GamesCount", c => c.Int(nullable: false));
            AddColumn("dbo.Points", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Points", "ValueCurrent", c => c.Int(nullable: false));
            AddColumn("dbo.Points", "Game_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Points", "Team_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "Theme_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "Description", c => c.String());
            AlterColumn("dbo.Questions", "Category_Id", c => c.Int());
            AddPrimaryKey("dbo.Points", "Id");
            CreateIndex("dbo.Points", "Game_Id");
            CreateIndex("dbo.Points", "Team_Id");
            CreateIndex("dbo.Questions", "Category_Id");
            CreateIndex("dbo.Questions", "Theme_Id");
            AddForeignKey("dbo.Points", "Game_Id", "dbo.Games", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Points", "Team_Id", "dbo.Teams", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "Theme_Id", "dbo.Themes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "Category_Id", "dbo.Categories", "Id");
            DropColumn("dbo.Teams", "Information");
            DropColumn("dbo.Teams", "Points");
            DropColumn("dbo.Points", "GameId");
            DropColumn("dbo.Points", "TeamId");
            DropColumn("dbo.Points", "Value");
            DropColumn("dbo.Questions", "Subcategory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "Subcategory", c => c.String());
            AddColumn("dbo.Points", "Value", c => c.Int(nullable: false));
            AddColumn("dbo.Points", "TeamId", c => c.Int(nullable: false));
            AddColumn("dbo.Points", "GameId", c => c.Int(nullable: false));
            AddColumn("dbo.Teams", "Points", c => c.Int(nullable: false));
            AddColumn("dbo.Teams", "Information", c => c.String(nullable: false));
            DropForeignKey("dbo.Questions", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Questions", "Theme_Id", "dbo.Themes");
            DropForeignKey("dbo.Points", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Points", "Game_Id", "dbo.Games");
            DropIndex("dbo.Questions", new[] { "Theme_Id" });
            DropIndex("dbo.Questions", new[] { "Category_Id" });
            DropIndex("dbo.Points", new[] { "Team_Id" });
            DropIndex("dbo.Points", new[] { "Game_Id" });
            DropPrimaryKey("dbo.Points");
            AlterColumn("dbo.Questions", "Category_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Questions", "Theme_Id");
            DropColumn("dbo.Points", "Team_Id");
            DropColumn("dbo.Points", "Game_Id");
            DropColumn("dbo.Points", "ValueCurrent");
            DropColumn("dbo.Points", "Id");
            DropColumn("dbo.Teams", "GamesCount");
            DropColumn("dbo.Teams", "AllPoints");
            DropColumn("dbo.Teams", "Description");
            DropColumn("dbo.Games", "AllPoints");
            DropTable("dbo.Themes");
            AddPrimaryKey("dbo.Points", new[] { "GameId", "TeamId" });
            CreateIndex("dbo.Questions", "Category_Id");
            AddForeignKey("dbo.Questions", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
