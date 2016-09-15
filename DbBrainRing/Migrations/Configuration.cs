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
                Name = "Команда А",
                Captain = "Вася",
                Information = "Васина команда",
                Points = 20
            });
            context.Teams.Add(new Team()
            {
                Name = "Команда Б",
                Captain = "Петя",
                Information = "Петина команда",
                Points = 100
            });
            context.Teams.Add(new Team()
            {
                Name = "Команда Х",
                Captain = "Эдуард",
                Information = "Эдика команда",
                Points = 0
            });
            var category1 = context.Categories.Add(new Category()
            {
                Name = "Общие",
                Description = "...",
            });

            context.Questions.Add(new Question()
            {
                Content = "Текст вопроса 1",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "ответ 1",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "ответ 2",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "ответ 3",
                        IsCorrect = true
                    },
                    new Answer()
                    {
                        Content = "ответ 4",
                        IsCorrect = false
                    }
                },
                Category = category1,
                Points = 1,
                Round = RoundType.Общее,
                QuestionType = QuestionType.Варианты,
            });
            context.Questions.Add(new Question()
            {
                Content = "Текст вопроса 2",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "ответ 1",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "ответ 2",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "ответ 3",
                        IsCorrect = true
                    },
                    new Answer()
                    {
                        Content = "ответ 4",
                        IsCorrect = false
                    }
                },
                Category = category1,
                Points = 1,
                Round = RoundType.Общее,
                QuestionType = QuestionType.Варианты,
            });
            context.Questions.Add(new Question()
            {
                Content = "Текст вопроса 3",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "ответ 1",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "ответ 2",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "ответ 3",
                        IsCorrect = true
                    },
                    new Answer()
                    {
                        Content = "ответ 4",
                        IsCorrect = false
                    }
                },
                Category = category1,
                Points = 1,
                Round = RoundType.Общее,
                QuestionType = QuestionType.Варианты,
            });
            context.Questions.Add(new Question()
            {
                Content = "Текст вопроса 4",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "ответ 1",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "ответ 2",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "ответ 3",
                        IsCorrect = true
                    },
                    new Answer()
                    {
                        Content = "ответ 4",
                        IsCorrect = false
                    }
                },
                Category = category1,
                Points = 1,
                Round = RoundType.Общее,
                QuestionType = QuestionType.Варианты,
            });
            context.Questions.Add(new Question()
            {
                Content = "Текст вопроса 5",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "ответ 1",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "ответ 2",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "ответ 3",
                        IsCorrect = true
                    },
                    new Answer()
                    {
                        Content = "ответ 4",
                        IsCorrect = false
                    }
                },
                Category = category1,
                Points = 1,
                Round = RoundType.Общее,
                QuestionType = QuestionType.Варианты,
            });
            context.Questions.Add(new Question()
            {
                Content = "Текст вопроса 6",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "ответ 1",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "ответ 2",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "ответ 3",
                        IsCorrect = true
                    },
                    new Answer()
                    {
                        Content = "ответ 4",
                        IsCorrect = false
                    }
                },
                Category = category1,
                Points = 1,
                Round = RoundType.Общее,
                QuestionType = QuestionType.Варианты,
            });
            context.Questions.Add(new Question()
            {
                Content = "Текст вопроса 7",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "ответ 1",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "ответ 2",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "ответ 3",
                        IsCorrect = true
                    },
                    new Answer()
                    {
                        Content = "ответ 4",
                        IsCorrect = false
                    }
                },
                Category = category1,
                Points = 1,
                Round = RoundType.Общее,
                QuestionType = QuestionType.Варианты,
            });
            context.Questions.Add(new Question()
            {
                Content = "Текст вопроса 8",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "ответ 1",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "ответ 2",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "ответ 3",
                        IsCorrect = true
                    },
                    new Answer()
                    {
                        Content = "ответ 4",
                        IsCorrect = false
                    }
                },
                Category = category1,
                Points = 1,
                Round = RoundType.Общее,
                QuestionType = QuestionType.Варианты,
            });
            context.Questions.Add(new Question()
            {
                Content = "Текст вопроса 9",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "ответ 1",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "ответ 2",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "ответ 3",
                        IsCorrect = true
                    },
                    new Answer()
                    {
                        Content = "ответ 4",
                        IsCorrect = false
                    }
                },
                Category = category1,
                Points = 1,
                Round = RoundType.Общее,
                QuestionType = QuestionType.Варианты,
            });
            context.Questions.Add(new Question()
            {
                Content = "Текст вопроса 10",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "ответ 1",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "ответ 2",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "ответ 3",
                        IsCorrect = true
                    },
                    new Answer()
                    {
                        Content = "ответ 4",
                        IsCorrect = false
                    }
                },
                Category = category1,
                Points = 1,
                Round = RoundType.Общее,
                QuestionType = QuestionType.Варианты,
            });
            context.Questions.Add(new Question()
            {
                Content = "Текст вопроса 11",
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Content = "ответ 1",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "ответ 2",
                        IsCorrect = false
                    },
                    new Answer()
                    {
                        Content = "ответ 3",
                        IsCorrect = true
                    },
                    new Answer()
                    {
                        Content = "ответ 4",
                        IsCorrect = false
                    }
                },
                Category = category1,
                Points = 1,
                Round = RoundType.Общее,
                QuestionType = QuestionType.Варианты,
            });

            //сохранение изменений
            //context.SaveChanges();
            base.Seed(context);
        }
    }
}
