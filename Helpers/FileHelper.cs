using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Finale.Models;

namespace Finale.Helpers {
    public static class FileHelper {
        public static void SaveGame(in string path, in RecordData data) {
            Console.WriteLine("adasdasdasd" + data.ToString());
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.OpenWrite(path)) {
                formatter.Serialize(stream, data);
            }
        }
        public static RecordData LoadGame(string path) {
            if (!File.Exists(path)) {
                File.Create(path).Close();
                return RecordData.Default();
            }
            RecordData data;
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.OpenRead(path)) {
                data = (RecordData)formatter.Deserialize(stream);
            }

            return data;
        }
        public static void DeleteGame(string path) {
            File.Delete(path);
        }
    }
}
