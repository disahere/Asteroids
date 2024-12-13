using CodeBase._GAME.UI;
using CodeBase._GAME.Util;
using UnityEngine;

namespace CodeBase._GAME.Asteroid
{
    public class AsteroidSpawner : MonoBehaviour
    {
        [SerializeField] public LevelSettings levelSettings;
        [SerializeField] private GameObject asteroidPrefab;
        [SerializeField] private GameUI gameUI;

        private void Start() => 
            levelSettings = LevelSettingsManager.GetCurrentLevelSettings();

        private void SpawnAsteroid()
        {
            Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

            Vector2 spawnPosition = new Vector2(
                Random.Range(-screenBounds.x - 1f, screenBounds.x + 1f),
                Random.Range(-screenBounds.y - 1f, screenBounds.y + 1f)
            );

            if (Random.value > 0.5f)
                spawnPosition.x = (Random.value > 0.5f) ? -screenBounds.x - 1f : screenBounds.x + 1f;
            else
                spawnPosition.y = (Random.value > 0.5f) ? -screenBounds.y - 1f : screenBounds.y + 1f;

            var asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
            
            SetupAsteroidMovement(asteroid);
        }

        private void SetupAsteroidMovement(GameObject asteroid)
        {
            var rb = asteroid.GetComponent<Rigidbody2D>();
            var randomDirection = Random.insideUnitCircle.normalized;
            var randomSpeed = Random.Range(levelSettings.minAsteroidSpeed, levelSettings.maxAsteroidSpeed);
            rb.velocity = randomDirection * randomSpeed;
        }

        public void SpawnAsteroids()
        {
            for (int i = 0; i < levelSettings.asteroidCount; i++)
                SpawnAsteroid();
        }
    }
}