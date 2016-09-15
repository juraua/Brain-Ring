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

            //сохранение изменений
            //context.SaveChanges();
            base.Seed(context);
        }

        public void TestData()
        {
            using (var context = new BrainRingContext())
            {
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
                context.SaveChanges();
            }
        }
    }
}
