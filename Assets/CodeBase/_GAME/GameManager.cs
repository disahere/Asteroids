using CodeBase._GAME.Asteroid;
using CodeBase._GAME.UI;
using UnityEngine;

namespace CodeBase._GAME
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private AsteroidSpawner asteroidSpawner;
        [SerializeField] private AsteroidWatcher asteroidWatcher;
        [SerializeField] private GameUI gameUI;

        private void Start() => 
            asteroidSpawner.SpawnAsteroids();
        
        private void OnEnable()
        {
            asteroidWatcher.OnAllAsteroidsDestroyed += HandleAllAsteroidsDestroyed;
        }

        private void OnDisable()
        {
            asteroidWatcher.OnAllAsteroidsDestroyed -= HandleAllAsteroidsDestroyed;
        }
        
        private void HandleAllAsteroidsDestroyed()
        {
            gameUI.ShowLevelCompletePanel();
        }
    }
}