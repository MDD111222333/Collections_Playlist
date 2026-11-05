using System;

namespace Collections_Playlist
{
    class Program
    {
        static void Main(string[] args)
        {
            PlaylistManager manager = new PlaylistManager();
            manager.AddSong("A");
            manager.AddSong("B");
            manager.AddSong("C");

            Console.WriteLine("=== Начальное состояние ===");
            manager.PrintPlaylist();

            Console.WriteLine("\nВызываем PlayNext(\"X\"):");
            manager.PlayNext("X");
            manager.PrintPlaylist();

            Console.WriteLine("\nИщем песню 'B' и удаляем её через Remove:");
            var foundB = manager.FindSong("B");
            if (foundB != null)
            {
                manager.RemoveSong("B");
                Console.WriteLine("Песня 'B' успешно удалена.");
            }
            manager.PrintPlaylist();

            Console.WriteLine("\nПоиск несуществующей песни 'Нет такой песни':");
            var missing = manager.FindSong("Нет такой песни");
            Console.WriteLine($"Результат поиска: {(missing == null ? "null" : missing.Value)}");

            Console.WriteLine();
            Console.WriteLine("=== Интерактивный режим работы с плейлистом ===");

            PlaylistManager userPlaylist = new PlaylistManager();
            userPlaylist.AddSong("Трек_1");
            userPlaylist.AddSong("Трек_2");

            while (true)
            {
                try
                {
                    Console.WriteLine("\n1. Добавить песню в конец (AddLast)");
                    Console.WriteLine("2. Вставить следующей (PlayNext)");
                    Console.WriteLine("3. Найти песню (Find)");
                    Console.WriteLine("4. Удалить песню (Remove)");
                    Console.WriteLine("5. Показать плейлист");
                    Console.Write("Выберите действие (или 'stop' для выхода): ");
                    string choice = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(choice) || choice.Trim().ToLower() == "stop")
                    {
                        break;
                    }

                    if (choice == "1")
                    {
                        Console.Write("Введите название песни: ");
                        string song = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(song))
                        {
                            userPlaylist.AddSong(song);
                            Console.WriteLine("Песня добавлена.");
                        }
                    }
                    else if (choice == "2")
                    {
                        Console.Write("Введите название песни для очереди: ");
                        string song = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(song))
                        {
                            userPlaylist.PlayNext(song);
                            Console.WriteLine("Песня добавлена в очередь следом.");
                        }
                    }
                    else if (choice == "3")
                    {
                        Console.Write("Введите название песни для поиска: ");
                        string song = Console.ReadLine();
                        var result = userPlaylist.FindSong(song!);
                        if (result != null)
                        {
                            Console.WriteLine($"Песня найдена: {result.Value}");
                        }
                        else
                        {
                            Console.WriteLine("null (песня не найдена).");
                        }
                    }
                    else if (choice == "4")
                    {
                        Console.Write("Введите название песни для удаления: ");
                        string song = Console.ReadLine();
                        userPlaylist.RemoveSong(song!);
                        Console.WriteLine("Операция удаления выполнена.");
                    }
                    else if (choice == "5")
                    {
                        userPlaylist.PrintPlaylist();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}
