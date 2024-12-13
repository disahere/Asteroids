using CodeBase._GAME.Util;
using UnityEngine;

namespace CodeBase._GAME.Gun
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private ObjectPool bulletPool;
        [SerializeField] private Transform firePoint;
        [SerializeField] private float fireRate = 0.5f;
        [SerializeField] private float detectionRange = 10f;
        [SerializeField] private LayerMask targetLayer;

        private float _timeSinceLastShot;

        private void FixedUpdate()
        {
            _timeSinceLastShot += Time.deltaTime;

            if (!TargetDetected() || !(_timeSinceLastShot >= fireRate)) return;
            Shoot();
            _timeSinceLastShot = 0f;
        }

        private bool TargetDetected()
        {
            RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.up, detectionRange, targetLayer);
            return hit.collider != null;
        }

        private void Shoot()
        {
            GameObject bullet = bulletPool.Get();
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null) rb.velocity = firePoint.up * 10f;
        }
    }
}