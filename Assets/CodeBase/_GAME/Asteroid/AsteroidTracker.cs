using System;
using UnityEngine;

namespace CodeBase._GAME.Asteroid
{
    public class AsteroidTracker : MonoBehaviour
    {
        public event Action OnAllAsteroidsDestroyed;
        private int _remainingAsteroids;

        public void RegisterBigAsteroids(int bigAsteroidCount) => 
            _remainingAsteroids += bigAsteroidCount;

        public void RegisterChildAsteroids(int count) => 
            _remainingAsteroids += count;

        public void UnregisterAsteroid()
        {
            _remainingAsteroids--;
            ValidateCount();
        }   
        
        public void UnregisterBigAsteroidWithoutSplits()
        {
            _remainingAsteroids -= 3;
            ValidateCount();
        }
        
        private void ValidateCount()
        {
            if (_remainingAsteroids > 0) return;
            _remainingAsteroids = 0;
            CheckForCompletion();
        }

        private void CheckForCompletion()
        {
            if (_remainingAsteroids != 0) return;
            OnAllAsteroidsDestroyed?.Invoke();
        }

        public void ResetTracker() => 
            _remainingAsteroids = 0;
    }
}