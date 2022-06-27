using System;
namespace MusicIS.Info
{
    [Serializable]
    internal class InfoMusic
    {
        public override string ToString()
        {
            return $"\tНазвание музыки: {Name}\n\tИсполитель: {Artist}\n\tЖанр: {Gener}\n\tДлительность: {Time}\n\tРитм: {Ritm}";
        }

        public string Name { get; set; }
        public string Artist { get; set; }
        public string Gener { get; set; }
        public string Time { get; set; }
        public string Ritm { get; set; }

        public InfoMusic(string name, string artist, string gener, string time, string ritm)
        {
            Name = name;
            Artist = artist;
            Gener = gener;
            Time = time;
            Ritm = ritm;
        }
    }
}