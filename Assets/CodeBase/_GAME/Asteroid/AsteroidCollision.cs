using CodeBase._GAME.Hero;
using UnityEngine;

namespace CodeBase._GAME.Asteroid
{
    public class AsteroidCollision : MonoBehaviour
    {
        [SerializeField] private GameObject smallerAsteroidPrefab;
        [SerializeField] private int piecesToSpawn = 2;
        [SerializeField] private float sizeReductionFactor = 0.5f;

        private bool _canSplit = true;

        public void Split()
        {
            if (!_canSplit)
            {
                HeroStats.Instance.AddScore(50);
                DestroyAsteroid(true);
                return;
            }

            for (int i = 0; i < piecesToSpawn; i++)
            {
                GameObject smallerAsteroid =
                    Instantiate(smallerAsteroidPrefab, transform.position, Quaternion.identity);
                smallerAsteroid.transform.localScale = transform.localScale * sizeReductionFactor;

                var rb = smallerAsteroid.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = Random.insideUnitCircle.normalized * Random.Range(1f, 3f);
                }

                var smallerAsteroidCollision = smallerAsteroid.GetComponent<AsteroidCollision>();
                smallerAsteroidCollision.DisableSplitting();
                
                CheckComponents(smallerAsteroid);
            }

            DestroyAsteroid(true);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                DestroyAsteroid(false);
            }
            else if (other.CompareTag("Bullet"))
            {
                DestroyAsteroid(true);
            }
        }

        private static void CheckComponents(GameObject smallerAsteroid)
        {
            var collider = smallerAsteroid.GetComponent<CircleCollider2D>();
            if (collider != null)
                collider.enabled = true;

            var screenWrapper = smallerAsteroid.GetComponent<ScreenWrapper>();
            if (screenWrapper != null)
                screenWrapper.enabled = true;
        }

        private void DestroyAsteroid(bool isAdd)
        {
            if (isAdd)
                HeroStats.Instance.AddScore(100);
            else
                HeroStats.Instance.AddScore(-50);

            Destroy(gameObject);
        }

        private void DisableSplitting() =>
            _canSplit = false;
    }
}