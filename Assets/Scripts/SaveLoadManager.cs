using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoadManager { 

    public static void Save(GameData data)
    {
        string fileName = "myData.fun"; 
        string path = Application.streamingAssetsPath;
        string fullPath = System.IO.Path.Combine(path, fileName);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (FileStream fs = new FileStream(fullPath, FileMode.Create))
        {
            binaryFormatter.Serialize(fs, data);
            Debug.Log("data saved!");
        }
    }
    public static GameData Load()
    {
        string fileName = "myData.fun";
        string path = Application.streamingAssetsPath;
        string fullPath = System.IO.Path.Combine(path, fileName);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (FileStream fs = new FileStream(fullPath, FileMode.Open))
        {
            Debug.Log("data loaded!");
            return (GameData)binaryFormatter.Deserialize(fs);

        }
    }
}


