using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase._GAME.Util
{
    public static class DontDestroyCleaner
    {
        private static readonly string[] ExcludedNames = { "SimpleInput" };
        public static void ClearAll()
        {
            var dontDestroyObjects = GetDontDestroyOnLoadObjects();

            foreach (var obj in dontDestroyObjects)
            {
                if (!ShouldExclude(obj)) 
                    Object.Destroy(obj);
            }
        }
        
        private static bool ShouldExclude(GameObject obj) => 
            ExcludedNames != null && System.Array.Exists(ExcludedNames, name => obj.name == name);

        private static GameObject[] GetDontDestroyOnLoadObjects()
        {
            var temp = new GameObject("Temp");
            Object.DontDestroyOnLoad(temp);
            Scene dontDestroyScene = temp.scene;

            Object.Destroy(temp);

            return dontDestroyScene.GetRootGameObjects();
        }
    }
}