using DbBrainRing.Models;
using System.Collections.Generic;
using System.Data.Entity;
using DbBrainRing.Enums;

namespace DbBrainRing
{
    public class Initializer : CreateDatabaseIfNotExists<BrainRingContext>
    {
        //Заполнение таблиц базы данных по умолчанию
        protected override void Seed(BrainRingContext context)
        {
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

            //сохранение изменений
            //context.SaveChanges();
            base.Seed(context);
        }

        public void TestData()
        {
            using (var context = new BrainRingContext())
            {
                var theme1 = context.Themes.Add(new Theme()
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
                        IsCorrect = true
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
                context.SaveChanges();
            }
        }
    }
}
