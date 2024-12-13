using CodeBase._GAME.Asteroid;
using CodeBase._GAME.Util;
using UnityEngine;

namespace CodeBase._GAME.Gun
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float lifeTime = 3f;
        
        private float _timeAlive;

        private void OnEnable() => 
            _timeAlive = 0f;

        private void FixedUpdate()
        {
            _timeAlive += Time.deltaTime;
            if (_timeAlive >= lifeTime) 
                ReturnToPool();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Asteroid")) return;
            collision.GetComponent<AsteroidCollision>()?.Split();
            ReturnToPool();
        }

        private void OnBecameInvisible() => 
            ReturnToPool();

        private void ReturnToPool() => 
            FindObjectOfType<ObjectPool>().ReturnToPool(gameObject);
    }
}