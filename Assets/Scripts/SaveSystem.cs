using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void Save(int score, string username) // save as SaveData class
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/" +username+System.DateTime.Now.ToString("yyyy.MM.dd") + ".data";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData (score);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData Load(string username)
    {
        string path = Application.persistentDataPath + "/" + username + System.DateTime.Now.ToString("yyyy.MM.dd") + ".data";
        //Debug.Log(Application.persistentDataPath + "/" + username + System.DateTime.Now.ToString("yyyy.MM.dd") + ".data");
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            //Debug.LogError("Save File not found in" + path);
            return new SaveData(0);
        }
    }
    public static SaveData Load(string username, string Date)
    {
        string path = Application.persistentDataPath + "/" + username + Date + ".data";
        //Debug.Log(Application.persistentDataPath + "/" + username + Date + ".data");
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            //Debug.LogError("Save File not found in" + path);
            return new SaveData(0);
        }
    }
}
