using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.school
{
    public class shkolacomputertest : BaseScene
    {
        public override void GetView()
        {
            AddDescription(@"Кабинет Информатики");
            if (Get("computer_status") == 0)
            {
                AddDirection(game.location.shkolamain, new { Name = "Выйти из класса" });

                AddDynamicAction(new
                {
                    Name = "Сесть за парту",
                    c = (Action)(() =>
                     {
                         Set("computer_status", 1);
                     })
                });
            }
            else
            {
                if (Get("start_test_computer") == 0)
                {
                    AddDynamicAction(new
                    {
                        Name = "Встать из-за парты",
                        c = (Action)(() =>
                         {
                             Set("computer_status", 0);
                         })
                    });
                    AddDescription(@"Вы сидите за партой");
                    AddDescription(@"Учитель информатики раздает тестовые задания");

                    AddDynamicAction(new
                    {
                        Name = "Начать тест",
                        c = (Action)(() =>
                         {
                             Set("start_test_computer", 1);
                         })
                    });
                }
                else
                {
                    switch ((int)Get("coputer_test_question"))
                    {
                        case 0:
                            Set("correct_questions", 0);
                            AddDescription(@"
				<br><br><br><br>
				Вопрос первый: Как включить компьютер?");
                            AddDynamicAction(new
                            {
                                Name = "Нажать на кнопку",
                                c = (Action)(() =>
                                 {
                                     int t = (int)Get("correct_questions");
                                     Set("correct_questions", ++t);
                                     Set("coputer_test_question", 1);
                                 })
                            });
                            AddDynamicAction(new
                            {
                                Name = "Сказать заклинание",
                                c = (Action)(() =>
                                 {
                                     Set("coputer_test_question", 1);
                                 })
                            });
                            break;
                        case 1:
                            AddDescription(@"
				<br><br><br><br>
				Вопрос второй: Что такое Интернет?");
                            AddDynamicAction(new
                            {
                                Name = "Всемирная информационная компьютерная сеть",
                                c = (Action)(() =>
                                 {
                                     int t = (int)Get("correct_questions");
                                     Set("correct_questions", ++t);
                                     Set("coputer_test_question", 2);
                                 })
                            });
                            AddDynamicAction(new
                            {
                                Name = "Текстовой процессор",
                                c = (Action)(() =>
                                 {
                                     Set("coputer_test_question", 2);
                                 })
                            });
                            break;
                        case 2:

                            AddDescription(@"
				<br><br><br><br>
				Вопрос третий: Что такое C#?");
                            AddDynamicAction(new
                            {
                                Name = "Автомобиль",
                                c = (Action)(() =>
                                 {
                                     Set("coputer_test_question", 3);
                                 })
                            });
                            AddDynamicAction(new
                            {
                                Name = "Древний бог",
                                c = (Action)(() =>
                                 {
                                     Set("coputer_test_question", 3);
                                 })
                            });
                            AddDynamicAction(new
                            {
                                Name = "Язык программирования",
                                c = (Action)(() =>
                                 {
                                     int t = (int)Get("correct_questions");
                                     Set("correct_questions", ++t);
                                     Set("coputer_test_question", 3);
                                 })
                            });
                            AddDynamicAction(new
                            {
                                Name = "Язык интервейса",
                                c = (Action)(() =>
                                 {
                                     Set("coputer_test_question", 3);
                                 })
                            });
                            break;
                        case 3:
                            AddDescription(@"
				<br><br><br><br>
				Что такое Оперативная память?");
                            AddDynamicAction(new
                            {
                                Name = "Устройство ввода вывода",
                                c = (Action)(() =>
                                 {
                                     Set("coputer_test_question", 4);
                                 })
                            });
                            AddDynamicAction(new
                            {
                                Name = "Устройство входа выхода",
                                c = (Action)(() =>
                                 {
                                     Set("coputer_test_question", 4);
                                 })
                            });
                            AddDynamicAction(new
                            {
                                Name = "Системная шина",
                                c = (Action)(() =>
                                 {
                                     Set("coputer_test_question", 4);
                                 })
                            });
                            AddDynamicAction(new
                            {
                                Name = "Интерфейс",
                                c = (Action)(() =>
                                 {
                                     Set("coputer_test_question", 4);
                                 })
                            });
                            AddDynamicAction(new
                            {
                                Name = "Оперативное запоминающее устройство",
                                c = (Action)(() =>
                                 {
                                     int t = (int)Get("correct_questions");
                                     Set("correct_questions", ++t);
                                     Set("coputer_test_question", 4);
                                 })
                            });
                            break;
                        case 4:
                            AddDescription(@"Ваш результат: " + Get("correct_questions") + " / 4");
                            if (Get("correct_questions") < 4)
                            {
                                AddDescription(@"Учитель информатики строго посмотрел на вас");
                            }
                            else
                            {
                                AddDescription(@"Учитель информатики похвалил вас");
                                GetPlayer().Intellect++;
                            }
                            AddDirection(game.location.shkolamain, new
                            {
                                Name = "Выйти из класса",
                                c = (Action)(() =>
                                 {
                                     Set("coputer_test_question", 0);
                                     Set("computer_status", 0);
                                     Set("start_test_computer", 0);
                                 })
                            });
                            AddDynamicAction(new
                            {
                                Name = "Выйти в коридор",
                                Scene = "gorodok/school/shkolamain",
                                c = (Action)(() =>
                                 {
                                     Set("coputer_test_question", 0);
                                     Set("computer_status", 0);
                                     Set("start_test_computer", 0);
                                 })
                            });
                            break;
                    }
                }
            }
        }
    }
}