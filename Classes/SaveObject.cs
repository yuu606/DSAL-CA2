using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DSAL_CA1.Classes
{
    internal class SaveObject
    {
        private CinemaState _cinemaState;

        public SaveObject(CinemaState cinemaState)
        {
            _cinemaState = cinemaState;
        }



        public void SaveToFile()
        {
            Stream stream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\..\\..\\Data"));
            saveFileDialog.Filter = "Data Files (*.dat)|*.dat";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((stream = saveFileDialog.OpenFile()) != null)
                {
                    BinaryFormatter f = new BinaryFormatter();
                    #pragma warning disable SYSLIB0011
                    f.Serialize(stream, _cinemaState);
                    stream.Close();
                }
            }
        }

        public CinemaState ReadFromFile()
        {
            string filePath;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\..\\..\\Data"));
            openFileDialog.Filter = "Data Files (*.dat)|*.dat";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;

                BinaryFormatter f = new BinaryFormatter();
                Stream stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read);

                if (stream.Length != 0)
                {
                    _cinemaState = (CinemaState)f.Deserialize(stream);
                }
                stream.Close();
            }
            return _cinemaState;
        }
    }
}
