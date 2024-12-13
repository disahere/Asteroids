using System.IO;
using UnityEngine;

namespace CodeBase._GAME.Util
{
    [CreateAssetMenu(fileName = "LevelProgress", menuName = "Game/LevelProgress")]
    public class LevelProgress : ScriptableObject
    {
        public int unlockedLevels = 1;

        private static string SavePath =>
            Path.Combine(Application.persistentDataPath, "level_progress.json");

        public void SaveProgress()
        {
            string json = JsonUtility.ToJson(this);
            File.WriteAllText(SavePath, json);
        }

        public void LoadProgress()
        {
            if (File.Exists(SavePath))
            {
                string json = File.ReadAllText(SavePath);
                JsonUtility.FromJsonOverwrite(json, this);
            }
            else
                unlockedLevels = 1;
        }
        
        public bool UnlockNextLevel(int currentLevel)
        {
            if (currentLevel != unlockedLevels) return false;
            unlockedLevels++;
            SaveProgress();
            return true;
        }
    }
}