namespace DbBrainRing
{
    using DbBrainRing.Enums;
    using DbBrainRing.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class BrainRingContext : DbContext
    {
        public BrainRingContext()
            : base("name=BrainRingDb")
        {
            //Database.SetInitializer<BrainRingContext>(new Initializer());
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
            //modelBuilder.Entity<Question>().HasMany(x => x.Answers);
        //}

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Points> Points { get; set; }
        public DbSet<Category> Categories { get; set; }

        public void Seed()
        {
            //Добавить Вопросы


            /*
            //заполнение таблицы "Вопросы"
            List<Question> questions = new List<Question>
            {
                new Question {  },
                // ...
            };
            foreach (Question question in questions)
                context.Questions.Add(question);
            
            //заполнение таблицы "Ответы"
            List<Answer> answers = new List<Answer>
            {
                new Answer {  },
                // ...
            };
            foreach (Answer answer in answers)
                context.Answers.Add(answer);
                */


            //тест:
            /*
            this.Teams.Add(new Team()
            {
                Name = "Команда А",
                Captain = "Вася",
                Information = "Васина команда",
                Points = 20
            });
            this.Teams.Add(new Team()
            {
                Name = "Команда Б",
                Captain = "Петя",
                Information = "Петина команда",
                Points = 100
            });
            this.Teams.Add(new Team()
            {
                Name = "Команда Х",
                Captain = "Эдуард",
                Information = "Эдика команда",
                Points = 0
            });
            */
            var theme1 = this.Themes.Add(new Theme()
            {
                Name = "Общие",
                Description = "...",
            });

            this.Questions.Add(new Question()
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
            this.Questions.Add(new Question()
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
            this.Questions.Add(new Question()
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
            this.Questions.Add(new Question()
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
            this.Questions.Add(new Question()
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
            this.Questions.Add(new Question()
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
            this.Questions.Add(new Question()
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
            this.Questions.Add(new Question()
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
            this.Questions.Add(new Question()
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
            this.Questions.Add(new Question()
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
            this.Questions.Add(new Question()
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
            this.SaveChanges();
        }
    }
}