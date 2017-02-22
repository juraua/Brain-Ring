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
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BrainRingContext context)
        {
            
            context.Teams.Add(new Team()
            {
                Name = "Команда А",
                Captain = "Вася",
                Description = "Васина команда",
                AllPoints = 20
            });
            context.Teams.Add(new Team()
            {
                Name = "Команда Б",
                Captain = "Петя",
                Description = "Петина команда",
                AllPoints = 100
            });
            context.Teams.Add(new Team()
            {
                Name = "Команда Х",
                Captain = "Эдуард",
                Description = "Эдика команда",
                AllPoints = 0
            });
            var theme1 = context.Themes.Add(new Theme()
            {
                Name = "Історичний конкурс",
                Description = "Запитанняя з всесвітньої історії",
            });
            var theme2 = context.Themes.Add(new Theme()
            {
                Name = "Математичний конкурс",
                Description = "Запитанняя з математики",
            });
            var theme3 = context.Themes.Add(new Theme()
            {
                Name = "Біблійний конкурс",
                Description = "Запитанняя по Біблії",
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
                Theme = theme1,
                Points = 1,
                Round = RoundType.Main,
                QuestionType = QuestionType.CheckBox,
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
                Theme = theme1,
                Points = 1,
                Round = RoundType.Main,
                QuestionType = QuestionType.CheckBox,
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
                Theme = theme1,
                Points = 1,
                Round = RoundType.Main,
                QuestionType = QuestionType.CheckBox,
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
                Theme = theme1,
                Points = 1,
                Round = RoundType.Main,
                QuestionType = QuestionType.CheckBox,
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
                Theme = theme1,
                Points = 1,
                Round = RoundType.Main,
                QuestionType = QuestionType.CheckBox,
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
                Theme = theme1,
                Points = 1,
                Round = RoundType.Main,
                QuestionType = QuestionType.CheckBox,
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
                Theme = theme1,
                Points = 1,
                Round = RoundType.Main,
                QuestionType = QuestionType.CheckBox,
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
                Theme = theme1,
                Points = 1,
                Round = RoundType.Main,
                QuestionType = QuestionType.CheckBox,
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
                Theme = theme1,
                Points = 1,
                Round = RoundType.Main,
                QuestionType = QuestionType.CheckBox,
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
                Theme = theme1,
                Points = 1,
                Round = RoundType.Main,
                QuestionType = QuestionType.CheckBox,
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
                Theme = theme1,
                Points = 1,
                Round = RoundType.Main,
                QuestionType = QuestionType.CheckBox,
            });

            //сохранение изменений
            //context.SaveChanges();
            base.Seed(context);
        }
    }
}

//Команды для миграции 
//Enable-Migrations –EnableAutomaticMigrations  //Включить автоматическую миграцию
//Add-Migration Name_Migrations //Создает файл миграции,вместо "Name_Migrations" указать имя миграции,напр.: FirstMigration
//Update-Database –Verbose //Обновить базу данных на основе последней миграции