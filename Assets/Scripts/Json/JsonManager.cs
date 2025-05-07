
using System.IO;
using UnityEngine;

public class JsonManager : MonoBehaviour
{

    [SerializeField]
   private LevelInfo levelInfo;
    public void Save()
    {
        string levelInfoJson = JsonUtility.ToJson(levelInfo);
        string path = Path.Combine( Application.persistentDataPath , "/levelData.data");
        File.WriteAllText(path, levelInfoJson);
        Debug.Log(levelInfoJson);
        Debug.Log(path);
    }

    public void Load()
    {
        string path = Path.Combine(Application.persistentDataPath, "/levelData.data");
        string levelInfoJson = File.ReadAllText(path);
        LevelInfo levelInfoLoaded = JsonUtility.FromJson<LevelInfo>(levelInfoJson);
        levelInfo.level = levelInfoLoaded.level;
        
    }

}
