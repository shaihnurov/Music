using MusicIS.Info;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MusicIS.adminmusic
{
    internal class admusic
    {
        public List<InfoMusic> Musics { get; set; }
        private string _path;
        public admusic(string path)
        {
            _path = path;
            Musics = gMusic();
        }
        public void file()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, Musics);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<InfoMusic> gMusic()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
                {
                    List<InfoMusic> rec = formatter.Deserialize(fs) as List<InfoMusic>;
                    fs.Close();
                    if (rec != null)
                        return rec;
                    else
                        return new List<InfoMusic>();
                }
            }
            catch (SerializationException)
            {
                return new List<InfoMusic>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Add(string name, string artist, string gener, string time, string ritm)
        {
            Musics.Add(new InfoMusic(name, artist, gener, time, ritm));
            try
            {
                file();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}