using UnityEngine;
using System.Collections;
using CodeBase._GAME.UI;

namespace CodeBase._GAME.Hero
{
    public class HeroHealth : MonoBehaviour
    {
        [SerializeField] private int startingLives = 3;
        [SerializeField] private float shieldDuration = 3f;
        [SerializeField] private Color shieldColor = new Color(1f, 1f, 1f, 0.5f);
        [SerializeField] private GameUI gameUI;

        private int _currentLives;
        private bool _isShieldActive;
        private SpriteRenderer _spriteRenderer;
        private Color _originalColor;

        private void Awake()
        {
            _currentLives = startingLives;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _originalColor = _spriteRenderer.color;
        }

        private void TakeDamage()
        {
            if (_isShieldActive) return;

            _currentLives--;
            HeroStats.Instance.TakeDamage(1);
            if (_currentLives <= 0)
            {
                gameUI.ShowGameOverPanel();
                Destroy(gameObject);
                return;
            }

            StartCoroutine(ActivateShield());
        }

        private IEnumerator ActivateShield()
        {
            _isShieldActive = true;
            var elapsedTime = 0f;

            while (elapsedTime < shieldDuration)
            {
                _spriteRenderer.color = shieldColor;
                yield return new WaitForSeconds(0.1f);
                _spriteRenderer.color = _originalColor;
                yield return new WaitForSeconds(0.1f);

                elapsedTime += 0.2f;
            }

            _spriteRenderer.color = _originalColor;
            _isShieldActive = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Asteroid")) 
                TakeDamage();
        }
    }
}
