using System;
using System.Collections.Generic;

namespace Stepic
{
	class Program
	{
		// UNDONE: Доработать имеющийся функционал
		// TODO: Добавить новый функционал
		// HACK: Временное решение, переделать или удалить

		static int status = 1;
		static void Main(string[] args)
		{
			
			Game game = new Game();
            for (;status != 0;)
            {
				game.GamePlay();
			}
			
		}

		// Клас игроки
		public class Player
		{
			// Свойства игрока
			public string Name { get; set; }
			public string Hp { get; set; }
			public string Attack { get; set; }
			public string Weapon { get; set; }
		}

		// Класс игры поля и методы
		public class Game
		{	
			// Массив фраз для вывода
			// UNDONE: Модернизировать код
			private string[] games =
			{

				"Введите имя: ",
				"Введите колличество жизней: ",
				"Введите урон оружия: ",
				"Введите название оружия: ",

			};

			// Метод вывода инофрмации по ходам
			private void Print(string name1, string name2, int attack, int hp)
			{
				Console.WriteLine($"{name1} атакует {name2} и наносит урон {attack}. {name2} осталось жизней {hp}.");
			}


			// Метод вывода информации Конец Игры
			private void GemeOver(string player)
			{
				Console.WriteLine($"Конец игры! {player} побеждает!");
			}

			// Метод атаки
			private int Attack(int hp, int attack)
			{
				return hp -= attack;
			}

			public void GamePlay()
            {
				Random rnd = new Random();
				// Определяем кто первый начнет игру
				Random rndPlay = new Random();
				int play = rndPlay.Next(0, 1);

				//int random = 0;
				Game game = new Game();

				// создаем список и записываем в него значения для игрока 1 и игрока 2
				List<string> users = new List<string> { };
				for (int i = 0; i < 2; i++)
				{
					foreach (var item in game.games)
					{
						Console.Write(item);
						users.Add(Console.ReadLine());
					}
				}

				// Инициализируем объект Игрок 1 и присваиваем полям значения
				var player1 = new Player
				{
					Name = users[0],
					Hp = users[1],
					Attack = users[2],
					Weapon = users[3]
				};

				// Инициализируем объект Игрок 2 и присваиваем полям значения
				var player2 = new Player
				{
					Name = users[4],
					Hp = users[5],
					Attack = users[6],
					Weapon = users[7]
				};

				// Конвертируем жизни и атаку в int
				int hp1 = Convert.ToInt32(player1.Hp);
				int hp2 = Convert.ToInt32(player2.Hp);
				int at1 = Convert.ToInt32(player1.Attack);
				int at2 = Convert.ToInt32(player2.Attack);
				// Счетчик раундов
				int count = 1;

				Console.WriteLine("Начинается бой!");

				// Игровой процесс играет пока не выйдет из цикла
				while (true)
				{

					if (play == 0)
					{
						Console.Write($"Раунд: {count} ");
						// Если атака равна 0, то задать новую силу атаки
						if (at1 == 0)
						{
							at1 = rnd.Next(1, hp2);
							// если жизней меньше 5 то атака равна колличеству жизни, чтобы рандом не завис в цикле
							if (hp2 < 5)
							{
								at1 = hp2;
							}
						}
						// Жизни - вызываем метод Атака и передаем параметры колличество жизней и силу атаки
						hp2 = game.Attack(hp1, at1);
						// Выводим сообщение - результат
						game.Print(player1.Name, player2.Name, at1, hp2);
						// Меняем ход игрока
						play++;
						// Увелисиваем номер раунда
						count++;
						// Урон присваиваем 0
						at1 = 0;
						// Если жизни 0 или меньше, то конец игры
						if (hp1 <= 0)
						{
							game.GemeOver(player1.Name);
							break;
						}
					}
					else
					{
						Console.Write($"Раунд: {count} ");
						if (at2 <= 0)
						{
							at2 = rnd.Next(1, hp1);
							if (hp1 < 5)
							{
								at2 = hp1;
							}
						}
						hp1 = game.Attack(hp1, at2);
						game.Print(player2.Name, player1.Name, at2, hp1);
						play--;
						count++;
						if (hp2 <= 0)
						{
							game.GemeOver(player2.Name);
							break;
						}
						at2 = 0;
					}
				}
				char c;
				Console.WriteLine("Повторим игру? (Для продолжения нажми Y, для выхода нажми Enter)");
				c = char.Parse(Console.ReadLine());
				if (c.ToString().ToLower() == 'y'.ToString())
				{
					game.GamePlay();
				}
				else
				{
					status = 0;
				}

			}
		}
	}
}

    

    
