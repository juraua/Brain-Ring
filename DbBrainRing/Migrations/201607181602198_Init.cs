namespace DbBrainRing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        IsCorrect = c.Boolean(nullable: false),
                        Question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Captain = c.String(nullable: false),
                        Information = c.String(nullable: false),
                        Points = c.Int(nullable: false),
                        Game_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.Game_Id)
                .Index(t => t.Game_Id);
            
            CreateTable(
                "dbo.Points",
                c => new
                    {
                        GameId = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GameId, t.TeamId });
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        Points = c.Int(nullable: false),
                        Round = c.Int(nullable: false),
                        QuestionType = c.Int(nullable: false),
                        Subcategory = c.String(),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.Teams", "Game_Id", "dbo.Games");
            DropIndex("dbo.Questions", new[] { "Category_Id" });
            DropIndex("dbo.Teams", new[] { "Game_Id" });
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            DropTable("dbo.Questions");
            DropTable("dbo.Points");
            DropTable("dbo.Teams");
            DropTable("dbo.Games");
            DropTable("dbo.Categories");
            DropTable("dbo.Answers");
        }
    }
}
