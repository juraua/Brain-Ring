namespace DbBrainRing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeamsAddToSeedTest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "Team1_TeamId", "dbo.Teams");
            DropForeignKey("dbo.Games", "Team2_TeamId", "dbo.Teams");
            DropForeignKey("dbo.Games", "Team3_TeamId", "dbo.Teams");
            DropForeignKey("dbo.Games", "Team4_TeamId", "dbo.Teams");
            DropForeignKey("dbo.Questions", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Answers", "Question_QuestionId", "dbo.Questions");
            DropIndex("dbo.Games", new[] { "Team1_TeamId" });
            DropIndex("dbo.Games", new[] { "Team2_TeamId" });
            DropIndex("dbo.Games", new[] { "Team3_TeamId" });
            DropIndex("dbo.Games", new[] { "Team4_TeamId" });
            RenameColumn(table: "dbo.Answers", name: "Question_QuestionId", newName: "Question_Id");
            RenameColumn(table: "dbo.Questions", name: "CategoryId", newName: "Category_Id");
            RenameIndex(table: "dbo.Answers", name: "IX_Question_QuestionId", newName: "IX_Question_Id");
            RenameIndex(table: "dbo.Questions", name: "IX_CategoryId", newName: "IX_Category_Id");
            //DropPrimaryKey("dbo.Answers");
            //DropPrimaryKey("dbo.Categories");
            //DropPrimaryKey("dbo.Games");
            //DropPrimaryKey("dbo.Teams");
            //DropPrimaryKey("dbo.Questions");
            CreateTable(
                "dbo.Points",
                c => new
                    {
                        GameId = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GameId, t.TeamId });
            
            //AddColumn("dbo.Answers", "Id", c => c.Int(nullable: false, identity: true));
            //AddColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: true));
            //AddColumn("dbo.Games", "Id", c => c.Int(nullable: false, identity: true));
            //AddColumn("dbo.Teams", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Teams", "Game_Id", c => c.Int());
            //AddColumn("dbo.Questions", "Id", c => c.Int(nullable: false, identity: true));
            //AddPrimaryKey("dbo.Answers", "Id");
            //AddPrimaryKey("dbo.Categories", "Id");
            //AddPrimaryKey("dbo.Games", "Id");
            //AddPrimaryKey("dbo.Teams", "Id");
            //AddPrimaryKey("dbo.Questions", "Id");
            CreateIndex("dbo.Teams", "Game_Id");
            AddForeignKey("dbo.Teams", "Game_Id", "dbo.Games", "Id");
            AddForeignKey("dbo.Questions", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Answers", "Question_Id", "dbo.Questions", "Id");
            DropColumn("dbo.Answers", "AnswerId");
            DropColumn("dbo.Categories", "CategoryId");
            DropColumn("dbo.Games", "GameId");
            DropColumn("dbo.Games", "TeamId1");
            DropColumn("dbo.Games", "TeamId2");
            DropColumn("dbo.Games", "TeamId3");
            DropColumn("dbo.Games", "TeamId4");
            DropColumn("dbo.Games", "Team1_TeamId");
            DropColumn("dbo.Games", "Team2_TeamId");
            DropColumn("dbo.Games", "Team3_TeamId");
            DropColumn("dbo.Games", "Team4_TeamId");
            DropColumn("dbo.Teams", "TeamId");
            DropColumn("dbo.Questions", "QuestionId");
            DropColumn("dbo.Questions", "AnswerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "AnswerId", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "QuestionId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Teams", "TeamId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Games", "Team4_TeamId", c => c.Int());
            AddColumn("dbo.Games", "Team3_TeamId", c => c.Int());
            AddColumn("dbo.Games", "Team2_TeamId", c => c.Int());
            AddColumn("dbo.Games", "Team1_TeamId", c => c.Int());
            AddColumn("dbo.Games", "TeamId4", c => c.Int());
            AddColumn("dbo.Games", "TeamId3", c => c.Int());
            AddColumn("dbo.Games", "TeamId2", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "TeamId1", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "GameId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Categories", "CategoryId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Answers", "AnswerId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Teams", "Game_Id", "dbo.Games");
            DropIndex("dbo.Teams", new[] { "Game_Id" });
            DropPrimaryKey("dbo.Questions");
            DropPrimaryKey("dbo.Teams");
            DropPrimaryKey("dbo.Games");
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.Answers");
            DropColumn("dbo.Questions", "Id");
            DropColumn("dbo.Teams", "Game_Id");
            DropColumn("dbo.Teams", "Id");
            DropColumn("dbo.Games", "Id");
            DropColumn("dbo.Categories", "Id");
            DropColumn("dbo.Answers", "Id");
            DropTable("dbo.Points");
            AddPrimaryKey("dbo.Questions", "QuestionId");
            AddPrimaryKey("dbo.Teams", "TeamId");
            AddPrimaryKey("dbo.Games", "GameId");
            AddPrimaryKey("dbo.Categories", "CategoryId");
            AddPrimaryKey("dbo.Answers", "AnswerId");
            RenameIndex(table: "dbo.Questions", name: "IX_Category_Id", newName: "IX_CategoryId");
            RenameIndex(table: "dbo.Answers", name: "IX_Question_Id", newName: "IX_Question_QuestionId");
            RenameColumn(table: "dbo.Questions", name: "Category_Id", newName: "CategoryId");
            RenameColumn(table: "dbo.Answers", name: "Question_Id", newName: "Question_QuestionId");
            CreateIndex("dbo.Games", "Team4_TeamId");
            CreateIndex("dbo.Games", "Team3_TeamId");
            CreateIndex("dbo.Games", "Team2_TeamId");
            CreateIndex("dbo.Games", "Team1_TeamId");
            AddForeignKey("dbo.Answers", "Question_QuestionId", "dbo.Questions", "QuestionId");
            AddForeignKey("dbo.Questions", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            AddForeignKey("dbo.Games", "Team4_TeamId", "dbo.Teams", "TeamId");
            AddForeignKey("dbo.Games", "Team3_TeamId", "dbo.Teams", "TeamId");
            AddForeignKey("dbo.Games", "Team2_TeamId", "dbo.Teams", "TeamId");
            AddForeignKey("dbo.Games", "Team1_TeamId", "dbo.Teams", "TeamId");
        }
    }
}
