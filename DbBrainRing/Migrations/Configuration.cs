using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DbBrainRing.Enums;
using DbBrainRing.Models;

namespace DbBrainRing.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BrainRingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BrainRingContext context)
        {
            
            context.Teams.Add(new Team()
            {
                Name = "������� �",
                Captain = "����",
                Information = "������ �������",
                Points = 20
            });
            context.Teams.Add(new Team()
            {
                Name = "������� �",
                Captain = "����",
                Information = "������ �������",
                Points = 100
            });
            context.Teams.Add(new Team()
            {
                Name = "������� �",
                Captain = "������",
                Information = "����� �������",
                Points = 0
            });
            var category1 = context.Categories.Add(new Category()
            {
                Name = "�����",
                Description = "...",
            });

            context.Questions.Add(new Question()
            {
                Content = "����� ������� 1",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "����� 1",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "����� 2",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "����� 3",
                        IsCorrect = true
                    },
                    new Answer()
                    {
                        Content = "����� 4",
                        IsCorrect = false
                    }
                },
                Category = category1,
                Points = 1,
                Round = RoundType.�����,
                QuestionType = QuestionType.��������,
            });
            context.Questions.Add(new Question()
            {
                Content = "����� ������� 2",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "����� 1",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "����� 2",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "����� 3",
                        IsCorrect = true
                    },
                    new Answer()
                    {
                        Content = "����� 4",
                        IsCorrect = false
                    }
                },
                Category = category1,
                Points = 1,
                Round = RoundType.�����,
                QuestionType = QuestionType.��������,
            });
            context.Questions.Add(new Question()
            {
                Content = "����� ������� 3",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "����� 1",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "����� 2",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "����� 3",
                        IsCorrect = true
                    },
                    new Answer()
                    {
                        Content = "����� 4",
                        IsCorrect = false
                    }
                },
                Category = category1,
                Points = 1,
                Round = RoundType.�����,
                QuestionType = QuestionType.��������,
            });
            context.Questions.Add(new Question()
            {
                Content = "����� ������� 4",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "����� 1",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "����� 2",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "����� 3",
                        IsCorrect = true
                    },
                    new Answer()
                    {
                        Content = "����� 4",
                        IsCorrect = false
                    }
                },
                Category = category1,
                Points = 1,
                Round = RoundType.�����,
                QuestionType = QuestionType.��������,
            });
            context.Questions.Add(new Question()
            {
                Content = "����� ������� 5",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "����� 1",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "����� 2",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "����� 3",
                        IsCorrect = true
                    },
                    new Answer()
                    {
                        Content = "����� 4",
                        IsCorrect = false
                    }
                },
                Category = category1,
                Points = 1,
                Round = RoundType.�����,
                QuestionType = QuestionType.��������,
            });
            context.Questions.Add(new Question()
            {
                Content = "����� ������� 6",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "����� 1",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "����� 2",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "����� 3",
                        IsCorrect = true
                    },
                    new Answer()
                    {
                        Content = "����� 4",
                        IsCorrect = false
                    }
                },
                Category = category1,
                Points = 1,
                Round = RoundType.�����,
                QuestionType = QuestionType.��������,
            });
            context.Questions.Add(new Question()
            {
                Content = "����� ������� 7",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "����� 1",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "����� 2",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "����� 3",
                        IsCorrect = true
                    },
                    new Answer()
                    {
                        Content = "����� 4",
                        IsCorrect = false
                    }
                },
                Category = category1,
                Points = 1,
                Round = RoundType.�����,
                QuestionType = QuestionType.��������,
            });
            context.Questions.Add(new Question()
            {
                Content = "����� ������� 8",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "����� 1",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "����� 2",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "����� 3",
                        IsCorrect = true
                    },
                    new Answer()
                    {
                        Content = "����� 4",
                        IsCorrect = false
                    }
                },
                Category = category1,
                Points = 1,
                Round = RoundType.�����,
                QuestionType = QuestionType.��������,
            });
            context.Questions.Add(new Question()
            {
                Content = "����� ������� 9",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "����� 1",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "����� 2",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "����� 3",
                        IsCorrect = true
                    },
                    new Answer()
                    {
                        Content = "����� 4",
                        IsCorrect = false
                    }
                },
                Category = category1,
                Points = 1,
                Round = RoundType.�����,
                QuestionType = QuestionType.��������,
            });
            context.Questions.Add(new Question()
            {
                Content = "����� ������� 10",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "����� 1",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "����� 2",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "����� 3",
                        IsCorrect = true
                    },
                    new Answer()
                    {
                        Content = "����� 4",
                        IsCorrect = false
                    }
                },
                Category = category1,
                Points = 1,
                Round = RoundType.�����,
                QuestionType = QuestionType.��������,
            });
            context.Questions.Add(new Question()
            {
                Content = "����� ������� 11",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "����� 1",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "����� 2",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "����� 3",
                        IsCorrect = true
                    },
                    new Answer()
                    {
                        Content = "����� 4",
                        IsCorrect = false
                    }
                },
                Category = category1,
                Points = 1,
                Round = RoundType.�����,
                QuestionType = QuestionType.��������,
            });

            //���������� ���������
            //context.SaveChanges();
            base.Seed(context);
        }
    }
}
