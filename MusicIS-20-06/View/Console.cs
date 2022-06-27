using System;

namespace MusicIS.View
{
    internal class Console
    {

        private adminmusic.admusic musics;

        public Console(string path)
        {
            try
            {
                musics = new adminmusic.admusic(path);
                consolepusk();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        private void consolem()
        {
            System.Console.WriteLine("commands - список команд");
            System.Console.WriteLine("listmusic - информации о музыке");
            System.Console.WriteLine("addmusic - добавить новую музыку");
            System.Console.WriteLine("exit - завершить сеанс");
        }

        public void consolepusk()
        {
            consolem();
            while (true)
            {
                try
                {
                    switch (Consolestart("Введите команду...").ToLower())
                    {
                        case "commands": consolem(); break;
                        case "listmusic": Listmusic(); break;
                        case "addmusic": AddMusic(); break;
                        case "exit": Environment.Exit(0); break;
                        default:
                            System.Console.WriteLine("неверная команда"); break;
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }

        private void AddMusic()
        {
            string name = Consolestart("Укажите название музыки");
            string artist = Consolestart("Укажите имя исполнителя");
            string gener = Consolestart("Укажите жанр");
            string time = Consolestart("Укажите время музыки");
            string ritm = Consolestart("Укажите ритм");
            musics.Add(name, artist, gener, time, ritm);
            System.Console.WriteLine("Музыка успешно добавлена");
            Listmusic();
        }

        private void Listmusic()
        {
            if (musics.Musics.Count == 0)
            {
                System.Console.WriteLine("Информации о музыке отсутствует");
                return;
            }

            foreach (var item in musics.Musics)
            {
                System.Console.WriteLine(item);
            }
        }

        private string Consolestart(string v)
        {
            System.Console.WriteLine(v);
            var s = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(s))
            {
                System.Console.WriteLine("некоректный ввод");
                return Consolestart(v);
            }
            return s.TrimStart().TrimEnd();
        }
    }
}
