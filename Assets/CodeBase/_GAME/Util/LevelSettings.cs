using UnityEngine;

namespace CodeBase._GAME.Util
{
    [CreateAssetMenu(fileName = "LevelSettings", menuName = "Asteroids/LevelSettings", order = 0)]
    public class LevelSettings : ScriptableObject
    {
        public int asteroidCount = 5;
        public float minAsteroidSpeed = 1f;
        public float maxAsteroidSpeed = 3f;
        public Vector2 spawnAreaSize = new Vector2(10f, 10f);
    }
}