
using System.IO;
using UnityEngine;

public class JsonManager : MonoBehaviour
{

    [SerializeField]
   private LevelInfo levelInfo;
    private string PathToFile => Path.Combine(Application.persistentDataPath, "levelData.data");

    private void Awake()
    {
        Load();
    }
    [ContextMenu("Save")]
    public void Save()
    {
        string levelInfoJson = JsonUtility.ToJson(levelInfo);
        File.WriteAllText(PathToFile, levelInfoJson);
        Debug.Log("Save");
        
    }

    public void Load()
    {
        if (!File.Exists(PathToFile))
        {
            Debug.LogWarning($"[Load] No existe el archivo en: {PathToFile}");
            return;
        }

        string json = File.ReadAllText(PathToFile);
        JsonUtility.FromJsonOverwrite(json, levelInfo);
        Debug.Log($"[Load] Datos cargados: {json}");

    }

    public void ChangeLevelAndSave(int nuevoNivel)
    {
        levelInfo.level = nuevoNivel;
        Save();
    }

    public LevelInfo GetLevelInfo() => levelInfo;



}
