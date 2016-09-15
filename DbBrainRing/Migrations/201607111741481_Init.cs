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
                        AnswerId = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        IsCorrect = c.Boolean(nullable: false),
                        Question_QuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.Questions", t => t.Question_QuestionId)
                .Index(t => t.Question_QuestionId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TeamId1 = c.Int(nullable: false),
                        TeamId2 = c.Int(nullable: false),
                        TeamId3 = c.Int(),
                        TeamId4 = c.Int(),
                        Team1_TeamId = c.Int(),
                        Team2_TeamId = c.Int(),
                        Team3_TeamId = c.Int(),
                        Team4_TeamId = c.Int(),
                    })
                .PrimaryKey(t => t.GameId)
                .ForeignKey("dbo.Teams", t => t.Team1_TeamId)
                .ForeignKey("dbo.Teams", t => t.Team2_TeamId)
                .ForeignKey("dbo.Teams", t => t.Team3_TeamId)
                .ForeignKey("dbo.Teams", t => t.Team4_TeamId)
                .Index(t => t.Team1_TeamId)
                .Index(t => t.Team2_TeamId)
                .Index(t => t.Team3_TeamId)
                .Index(t => t.Team4_TeamId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Captain = c.String(nullable: false),
                        Information = c.String(nullable: false),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeamId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        AnswerId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                        Round = c.Int(nullable: false),
                        QuestionType = c.Int(nullable: false),
                        Subcategory = c.String(),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Answers", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Games", "Team4_TeamId", "dbo.Teams");
            DropForeignKey("dbo.Games", "Team3_TeamId", "dbo.Teams");
            DropForeignKey("dbo.Games", "Team2_TeamId", "dbo.Teams");
            DropForeignKey("dbo.Games", "Team1_TeamId", "dbo.Teams");
            DropIndex("dbo.Questions", new[] { "CategoryId" });
            DropIndex("dbo.Games", new[] { "Team4_TeamId" });
            DropIndex("dbo.Games", new[] { "Team3_TeamId" });
            DropIndex("dbo.Games", new[] { "Team2_TeamId" });
            DropIndex("dbo.Games", new[] { "Team1_TeamId" });
            DropIndex("dbo.Answers", new[] { "Question_QuestionId" });
            DropTable("dbo.Questions");
            DropTable("dbo.Teams");
            DropTable("dbo.Games");
            DropTable("dbo.Categories");
            DropTable("dbo.Answers");
        }
    }
}
