using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using UnityEngine;
using SaveDataVC = SaveDataV1;

public static class SaveLoadSystem
{
    public static int SaveDataVersion { get; } = 1;
    public static SaveDataVC SaveData { get; set; } = new SaveDataVC();

    public static string SaveDirectory
    {
        get
        {
            return $"{Application.persistentDataPath}/Save";
        }
    }

    public static void Init()
    {
    }

    public static void Save()
    {
        Init();
        Save(SaveData, "saveData.json");
    }
    public static void Load()
    {
        SaveData = (SaveDataVC)Load("saveData.json");
    }

    public static void Save(SaveData data, string filename)
    {
        UnityEngine.Debug.Log("Save");
        if (!Directory.Exists(SaveDirectory))
        {
            Directory.CreateDirectory(SaveDirectory);
            UnityEngine.Debug.Log("SaveDirCreated");
        }

        var path = Path.Combine(SaveDirectory, filename);

        using (var writer = new JsonTextWriter(new StreamWriter(path)))
        {
            var serializer = new JsonSerializer();
            serializer.Converters.Add(new Vector3Converter());
            serializer.Converters.Add(new QuaternionConverter());
            serializer.Serialize(writer, data);
        }

        var json = File.ReadAllText(path);

        File.WriteAllText(path, json);
    }

    public static SaveData Load(string filename)
    {
        var path = Path.Combine(SaveDirectory, filename);
        if (!File.Exists(path))
        {
            return null;
        }
        SaveData data = null;
        int version = 0;

        var json = File.ReadAllText(path);

        using (var reader = new JsonTextReader(new StringReader(json)))
        {
            var jObg = JObject.Load(reader);
            version = jObg["Version"].Value<int>();
        }
        using (var reader = new JsonTextReader(new StringReader(json)))
        {
            var serialize = new JsonSerializer();
            switch (version)
            {
                //Add new version case
                case 1:
                    data = serialize.Deserialize<SaveDataV1>(reader);
                    break;
            }

            while (data.Version < SaveDataVersion)
            {
                data = data.VersionUp();
            }
        }

        return data;
    }
}