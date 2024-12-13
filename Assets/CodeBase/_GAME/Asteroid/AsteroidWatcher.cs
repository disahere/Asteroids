using System;
using UnityEngine;

namespace CodeBase._GAME.Asteroid
{
    public class AsteroidWatcher : MonoBehaviour //знаю что костыль, через AsteroidTracker пытался сделать по нормальному, но проблема была с регестрацией, стыдно :(
    {
        public event Action OnAllAsteroidsDestroyed;
        [SerializeField] private float checkInterval = 1f;

        private void Start() => 
            InvokeRepeating(nameof(CheckForAsteroids), checkInterval, checkInterval);

        private void CheckForAsteroids()
        {
            var asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

            if (asteroids.Length != 0) return;
            OnAllAsteroidsDestroyed?.Invoke();

            CancelInvoke(nameof(CheckForAsteroids));
        }
    }
}